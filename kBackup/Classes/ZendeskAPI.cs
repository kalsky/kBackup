using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace kBackup.Classes
{
    public class ZendeskApi
    {
        #region Public Properties

        public static string FirstName { get; set; } = string.Empty;
        public static string Email { get; set; } = string.Empty;
        public static string Password { get; set; } = string.Empty;
        public static string Domain { get; set; } = string.Empty;
        public static string Query { get; set; } = string.Empty;
        public static string BackupFolder { get; set; } = string.Empty;
        public static string ArticleId { get; set; } = string.Empty;
        public static int PageNumber = 1;

        #endregion

        #region Enums

        /// <summary>
        /// Public enum defining web methods.
        /// </summary>
        public enum Method
        {
            GET,
            POST,
            PUT
        }

        /// <summary>
        /// Public enum defining availabe portal types.
        /// </summary>
        public enum PortalType
        {
            HelpCenter = 0,
            WebPortal = 1
        }

        #endregion

        #region Supporting Classes

        /// <summary>
        /// Collection of retrieved articles or topics.
        /// </summary>
        public class ContentCollection
        {
            public List<Content> Articles { get; set; }
            public List<Content> Topics { get; set; }

            [JsonPropertyAttribute("NextPage")]
            public string Next_Page { get; set; }
        }

        /// <summary>
        /// Content properties.
        /// </summary>
        public class Content
        {
            [JsonPropertyAttribute("Id")]
            public int id { get; set; }

            [JsonPropertyAttribute("Url")]
            public string html_url { get; set; }

            [JsonPropertyAttribute("Title")]
            public string title { get; set; }

            [JsonPropertyAttribute("Body")]
            public string body { get; set; }

            [JsonPropertyAttribute("SectionId")]
            public string section_id { get; set; }

            [JsonPropertyAttribute("ForumId")]
            public string forum_id { get; set; }
        }

        /// <summary>
        /// Collection of retrieved users.
        /// </summary>
        public class UsersCollection
        {
            public List<User> Users { get; set; }
            public string NextPage { get; set; }
        }

        /// <summary>
        /// User properties.
        /// </summary>
        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Retrieves all articles, associated images and logs the URL's of the retrieved resources to a log file in the root of the backup.
        /// </summary>
        /// <returns>
        /// True if no error occurs and all articles are retrieved successfully. 
        /// False if an exception occurs.
        /// </returns>
        public static bool GetArticles(ComboBox portal)
        {
            //Sets the correct API string for the request.
            string apiUrl;
            if (portal.SelectedIndex == 0)
            {
                apiUrl = "https://" + Domain + ".zendesk.com/api/v2/help_center/articles.json" + Query + PageNumber + "&per_page=100";
            }
            else
            {
                apiUrl = "https://" + Domain + ".zendesk.com/api/v2/topics.json" + Query + PageNumber + "&per_page=100";
            }

            //Create web request with appropriate Authorisation header. .zendesk.com/api/v2/help_center/articles.json .zendesk.com/api/v2/help_center/en-us/articles.json
            var request = (HttpWebRequest)WebRequest.Create(apiUrl);
            request.Headers["Authorization"] = GetAuthHeader(Email, Password);
            request.ContentType = "application/json";
            request.Accept = "application/json, application/xml, text/json, htmlContent/x-json, htmlContent/javascript, htmlContent/xml";
            request.Method = nameof(Method.GET);
            request.ContentLength = 0;
            request.Timeout = 10000;

            try
            {
                //Get web request response and seralize into json object
                using (var resp = (HttpWebResponse)request.GetResponse())
                {
                    var rdr = new StreamReader(resp.GetResponseStream());
                    var tmp = rdr.ReadToEnd();
                    var deserializer = new JavaScriptSerializer { MaxJsonLength = int.MaxValue };
                    var articles = deserializer.Deserialize<ContentCollection>(tmp);
                    var htmlContent = new StringBuilder();

                    if (!SaveArticle(articles, htmlContent)) return false;

                    //Pagination of article api endpoint
                    if (articles.Next_Page != null)
                    {
                        //Thread.Sleep(5000);
                        PageNumber++;
                        GetArticles(portal);
                    }
                }
            }

            catch (WebException ex)
            {
                if (ex.Message == "The operation has timed out")
                {
                    Thread.Sleep(30000);
                    GetArticles(portal);
                }

                switch (((HttpWebResponse)ex.Response).StatusCode)
                {
                    case HttpStatusCode.Forbidden:
                        MessageBox.Show(Form.ActiveForm, @"Uh oh, it looks like you do not have have access to the resources you are trying to back up. Please ensure you have Admin privileges on your Zendesk account and try again.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;

                    case HttpStatusCode.BadRequest:
                        MessageBox.Show(Form.ActiveForm, @"bad request", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;

                    case HttpStatusCode.NotFound:
                        MessageBox.Show(Form.ActiveForm, @"The Zendesk domain you are requesting does not exist.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;

                    case (HttpStatusCode).429:
                        MessageBox.Show(Form.ActiveForm, @"You have hit the rate limit.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                }
            }
            catch (Exception e)
            {   //Catch all
                MessageBox.Show(Form.ActiveForm, @"The general exception was hit: " + e.Message);
            }
            return true;
        }

        /// <summary>
        /// Validates that a user with the provided credentials exists and that the user has access to required resources.
        /// </summary>
        /// <returns>
        /// True if the user credentials exist and the user has access to required resources.
        /// False if the user credentials do not exist or the user does not have access to the required resources.
        /// </returns>
        public static bool ValidateUser()
        {
            //Create web request with appropriate Authorisation header.
            var request = (HttpWebRequest)WebRequest.Create("https://" + Domain + ".zendesk.com/api/v2/users/me.json");
            request.Headers["Authorization"] = GetAuthHeader(Email, Password);
            request.ContentType = "application/json";
            request.Accept = "application/json, application/xml, text/json, htmlContent/x-json, htmlContent/javascript, htmlContent/xml";
            request.Method = nameof(Method.GET);
            request.ContentLength = 0;

            try
            {
                //Get web request response.
                var resp = (HttpWebResponse)request.GetResponse();
                var rdr = new StreamReader(resp.GetResponseStream() ?? Stream.Null);
                var tmp = rdr.ReadToEnd();

                //Check that the user credentials provided matched a valid user account.
                if (tmp.Contains("Anonymous user") || tmp.Contains("invalid@example.com"))
                {
                    MessageBox.Show(Form.ActiveForm, @"The username or password you have entered is incorrect, please try again.");
                    return false;
                }
            }

            catch (WebException ex)
            {
                switch (((HttpWebResponse)ex.Response).StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        MessageBox.Show(Form.ActiveForm, @"bad request");
                        return false;

                    case HttpStatusCode.NotFound:
                        MessageBox.Show(Form.ActiveForm, @"The Zendesk domain you are requesting does not exist.");
                        return false;

                    case HttpStatusCode.Unauthorized:
                        MessageBox.Show(Form.ActiveForm, @"The User you are trying to use either does not exist or does not have access to this resource.");
                        return false;

                }
            }

            return true;
        }

        /// <summary>
        /// Creates Authorization header using username and password provided.
        /// </summary>
        /// <param name="userName">Username of the user requesting authorization to the API endpoint.</param>
        /// <param name="password">Password of the user requesting authorization to the API endpoint.</param>
        /// <returns>
        /// Returns Authorization header based on username and password provided.
        /// </returns>
        public static string GetAuthHeader(string userName, string password)
        {
            var auth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{userName}:{password}"));
            return $"Basic {auth}";
        }

        /// <summary>
        /// Replaces any illegal characters in a file name with a chosen character.
        /// </summary>
        /// <param name="filename">The file name that should be cleaned.</param>
        /// <param name="replaceChar">The character to replace illegal characters with.</param>
        /// <returns></returns>
        public static string RemoveInvalidFilePathCharacters(string filename, string replaceChar)
        {
            var regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            var r = new Regex($"[{Regex.Escape(regexSearch)}]");
            return r.Replace(filename, replaceChar);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Saves collection of content locally.
        /// </summary>
        /// <param name="articles">Collection of articles.</param>
        /// <param name="htmlContent">Html content of the article.</param>
        /// <returns>Returns True if article saved successfully, False if article not saved.</returns>
        private static bool SaveArticle(ContentCollection articles, StringBuilder htmlContent)
        {
            foreach (var article in articles.Articles ?? articles.Topics)
            {
                //Write article heading and content into text file and save as html
                ArticleId = article.id.ToString();
                htmlContent.AppendLine("<h1>" + article.title + "</h1>");
                htmlContent.AppendLine(article.body);

                try
                {
                    Directory.CreateDirectory(BackupFolder);
                    File.WriteAllText(BackupFolder + @"\" + ArticleId + ".html", htmlContent.ToString(), Encoding.UTF8);

                    //Log the backed up resource in the backup log
                    using (var sw = File.AppendText(BackupFolder + @"\BackupLog.txt"))
                    {
                        sw.WriteLine("article_" + (article.section_id ?? ArticleId) + ": " +
                                     (article.html_url ?? "https://" + Domain + ".zendesk.com/entries/" + ArticleId));
                    }

                    GetImageList(htmlContent, article, article.section_id);
                }
                catch (UnauthorizedAccessException)
                {
                    //Occurs when user selects a directory from the folder browser dialog that the user does not have access to
                    MessageBox.Show(Form.ActiveForm,
                        @"You do not have access to the selected directory, please select Backup and try again.");
                    return false;
                }

                htmlContent.Clear();
            }
            return true;
        }

        /// <summary>
        /// Get's a list of images from the html content of the article.
        /// </summary>
        /// <param name="htmlContent">Html content of the article.</param>
        /// <param name="article">Article to check for img html elements.</param>
        private static void GetImageList(StringBuilder htmlContent, Content article, string sectionId)
        {
            //Get list of images associated to the article
            var urls = GetImageUrls(htmlContent.ToString());
            var urlList = urls as IList<string> ?? urls.ToList();
            if (!urlList.Any()) return;
            if (!Directory.Exists(BackupFolder + "\\images"))
            {
                Directory.CreateDirectory(BackupFolder + "\\images");
            }

            StartImageDownload(urlList, article, sectionId);
        }

        /// <summary>
        /// Starts the download of the image from the particular article.
        /// </summary>
        /// <param name="urlList">List of img url's from article.</param>
        /// <param name="article">Article which contains the image that will be downloaded.</param>
        private static void StartImageDownload(IEnumerable<string> urlList, Content article, string sectionId)
        {
            //Download and save image to \images sub folder of backup root
            foreach (var url in urlList)
            {
                var str = url.Substring(url.LastIndexOf("/", StringComparison.Ordinal));
                var fullFileName = str.Split(Convert.ToChar("."));
                var fileName = RemoveInvalidFilePathCharacters(fullFileName[0].Trim(Convert.ToChar("/")), "_");

                if (!DownloadImage(url, BackupFolder + "\\images\\" + ArticleId + "_" + fileName, sectionId))
                    continue;

                //Log the backed up resource in the backup log
                using (var sw = File.AppendText(BackupFolder + @"\BackupLog.txt"))
                {
                    sw.WriteLine("image_" + (article.section_id ?? ArticleId) + ": " + url);
                }
                //Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Downloads image from provided uri.
        /// </summary>
        /// <param name="uri">Uri of the image to be downloaded.</param>
        /// <param name="filePathName">Location where the image file will be saved to.</param>
        /// <returns>
        /// 
        /// </returns>
        private static bool DownloadImage(string uri, string filePathName, string sectionId)
        {
            if (!uri.Contains("http://") && !uri.Contains("https://") && !uri.Contains("//") && !uri.Contains("////"))
            {
                uri = "https://" + Domain + ".zendesk.com" + uri;
            }

            if (uri.Contains("////"))
            {
                uri = uri.Replace("////", "http://");
            }

            var imgUri = new Uri(uri, UriKind.RelativeOrAbsolute);

            //Create web request with appropriate Authorisation header.
            var request = (HttpWebRequest)WebRequest.Create(imgUri);
            request.Headers["Authorization"] = GetAuthHeader(Email, Password);
            request.Timeout = 10000;
            HttpWebResponse response;

            try
            {
                using (response = (HttpWebResponse)request.GetResponse())
                {
                    // Check that the remote file was found and that the ContentType is correct.
                    try
                    {
                        if ((response.StatusCode == HttpStatusCode.OK ||
                             response.StatusCode == HttpStatusCode.Moved ||
                             response.StatusCode == HttpStatusCode.Redirect) &&
                             response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase) ||
                             response.ContentType.StartsWith("text", StringComparison.OrdinalIgnoreCase))
                        {

                            //Check that file does not already exist, if it does then incrememnt filename.
                            var fileType = "." + response.ContentType.Split(Convert.ToChar("/"))[1];

                            if (fileType.Contains(Convert.ToChar(";")))
                            {
                                return false;
                            }

                            var fileIncrement = 0;
                            while (File.Exists(filePathName + fileType))
                            {
                                fileIncrement++;
                                filePathName = filePathName + " - " + fileIncrement;
                            }

                            //Write web request response stream to file.
                            using (var inputStream = response.GetResponseStream())
                            using (Stream outputStream = File.OpenWrite(filePathName + fileType))
                            {
                                var buffer = new byte[4096];
                                var bytesRead = 0;
                                do
                                {
                                    if (inputStream != null) bytesRead = inputStream.Read(buffer, 0, buffer.Length);
                                    outputStream.Write(buffer, 0, bytesRead);
                                } while (bytesRead != 0);
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
            catch (WebException ex)
            {
                if (ex.Message == "The operation has timed out")
                {
                    //Log the backed up resource in the backup log
                    //using (var sw = File.AppendText(BackupFolder + @"\BackupLog.txt"))
                    //{
                    //    sw.WriteLine("Error: Connection Timeout for article_" + (sectionId ?? ArticleId) + ": " + (uri ?? "https://" + Domain + ".zendesk.com/entries/" + ArticleId));
                    //}
                    //Thread.Sleep(60000);
                    //DownloadImage(uri, filePathName, sectionId);
                }
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks html content for img elements and extracts these.
        /// </summary>
        /// <param name="htmlContent">Html content to check for img elements.</param>
        /// <returns>
        /// Enumerable string array containing all image URLs associated with the html content.
        /// </returns>
        private static IEnumerable<string> GetImageUrls(string htmlContent)
        {
            return (from Match m in Regex.Matches(htmlContent, "<img.+?src=[\"'](.+?)[\"'].+?>", RegexOptions.IgnoreCase | RegexOptions.Multiline) select m.Groups[1].Value).ToList();
        }

        #endregion

        #region Deprecated

        /// <summary>
        /// Outdated function, previously used to validate user credentials.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="portal"></param>
        /// <returns></returns>
        public static bool GetUser(string email, ComboBox portal)
        {
            var request = (HttpWebRequest)WebRequest.Create("https://" + Domain + ".zendesk.com/api/v2/users.json" + Query + PageNumber);

            request.Method = nameof(Method.GET);
            request.Credentials = new NetworkCredential(Email, Password);
            request.ContentLength = 0;

            var resp = (HttpWebResponse)request.GetResponse();
            var rdr = new StreamReader(resp.GetResponseStream());
            var tmp = rdr.ReadToEnd();
            var users = new JavaScriptSerializer().Deserialize<UsersCollection>(tmp);

            foreach (var user in users.Users)
            {
                if (user.Email == email)
                {
                    return true;
                }
            }

            if (users.NextPage != null)
            {
                PageNumber++;
                GetArticles(portal);
            }
            return false;
        }

        #endregion
    }
}