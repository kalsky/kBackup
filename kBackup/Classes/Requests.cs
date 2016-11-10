using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml;
using Bunifu.Framework.UI;
using kBackup.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace kBackup.Classes
{
    class Requests
    {
        public bool UserValidated { get; set; }

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
        /// 
        /// </summary>
        /// <param name="apiUrl"></param>
        /// <returns></returns>
        public static bool GetCollections(string apiUrl)
        {
            try
            {
                Get(apiUrl);
            }
            catch (WebException ex)
            {
                if (ex.Response == null) return false;

                if (ex.Message == "The operation has timed out")
                {
                    Thread.Sleep(30000);
                    GetCollections(apiUrl);
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
        /// Retrieves all articles, associated images and logs the URL's of the retrieved resources to a log file in the root of the backup.
        /// </summary>
        /// <returns>
        /// True if no error occurs and all articles are retrieved successfully. 
        /// False if an exception occurs.
        /// </returns>
        public static bool GetArticles(BunifuDropdown portal)
        {
            //Sets the correct API string for the request.
            string apiUrl;
            if (portal.selectedIndex == 0)
            {
                apiUrl = "https://" + ZendeskApi.Domain + ".zendesk.com/api/v2/help_center/articles.json" + ZendeskApi.Query + ZendeskApi.PageNumber + "&per_page=100";
            }
            else
            {
                apiUrl = "https://" + ZendeskApi.Domain + ".zendesk.com/api/v2/topics.json" + ZendeskApi.Query + ZendeskApi.PageNumber + "&per_page=100";
            }

            //Create web request with appropriate Authorisation header. .zendesk.com/api/v2/help_center/articles.json .zendesk.com/api/v2/help_center/en-us/articles.json
            var request = (HttpWebRequest)WebRequest.Create(apiUrl);
            request.Headers["Authorization"] = GetAuthHeader(ZendeskApi.Email, ZendeskApi.Password);
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
                    var deserializer = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue };
                    var articles = deserializer.Deserialize<ZApiModel.ArticleCollection>(tmp);
                    var htmlContent = new StringBuilder();

                    //if (!SaveArticle(articles, htmlContent)) return false;

                    //Pagination of article api endpoint
                    if (articles.next_page != null)
                    {
                        //Thread.Sleep(5000);
                        ZendeskApi.PageNumber++;
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
        /// Outdated function, previously used to validate user credentials.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="portal"></param>
        /// <returns></returns>
        public static bool GetUser(string email, BunifuDropdown portal)
        {
            //var request = (HttpWebRequest)WebRequest.Create("https://" + Domain + ".zendesk.com/api/v2/users.json" + Query + PageNumber);

            //request.Method = nameof(Requests.Method.GET);
            //request.Credentials = new NetworkCredential(Email, Password);
            //request.ContentLength = 0;

            //var resp = (HttpWebResponse)request.GetResponse();
            //var rdr = new StreamReader(resp.GetResponseStream());
            //var tmp = rdr.ReadToEnd();
            //var deserializer = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue };
            //var users = deserializer.Deserialize<ZApiModel.UserCollection>(tmp);

            //foreach (var user in users.users)
            //{
            //    if (!string.Equals(user.email, Email, StringComparison.CurrentCultureIgnoreCase)) continue;
            //    DownloadImage(user.photo.content_url, Directory.GetCurrentDirectory() + user.photo.file_name, 0);

            //    if (Settings.Default.pbAvatar.InvokeRequired)
            //    {
            //        Settings.Default.pbAvatar.BeginInvoke((MethodInvoker)delegate { Settings.Default.pbAvatar.ImageLocation = user.photo.content_url; });
            //    }
            //    else
            //    {
            //        Image srcImage = Image.FromFile(@"C:\Git\kBackup\kBackup\bin\Debug2.png.png");
            //        Image dstImage = CropToCircle(srcImage, Color.Transparent);
            //        Settings.Default.pbAvatar.Image = dstImage;
            //    }
            //}

            //if (users.next_page == null) return false;
            //PageNumber++;
            //GetArticles(portal);
            return false;
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
            var request = (HttpWebRequest)WebRequest.Create("https://" + ZendeskApi.Domain + ".zendesk.com/api/v2/users/me.json");
            request.Headers["Authorization"] = GetAuthHeader(ZendeskApi.Email, ZendeskApi.Password);
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

        public static string GetUserData()
        {
            try
            {
                // Read existing json data
                var jsonData = string.Empty;
                //if (File.Exists(Settings.Default.dataFolder + "\\kbackup\\user\\profile.json"))
                //{
                //    jsonData = File.ReadAllText(Settings.Default.dataFolder + "\\kbackup\\user\\profile.json");
                //}
                //else
                //{
                //Create web request with appropriate Authorisation header. 
                var request =(HttpWebRequest) WebRequest.Create(string.Format(Settings.Default.userApi, Settings.Default.domain));
                request.Headers["Authorization"] = GetAuthHeader(Settings.Default.email, Settings.Default.password);
                request.ContentType = "application/json";
                request.Accept ="application/json, application/xml, text/json, htmlContent/x-json, htmlContent/javascript, htmlContent/xml";
                request.Method = nameof(Method.GET);
                request.ContentLength = 0;
                request.Timeout = 10000;

                //Get web request response and seralize into json object
                using (var resp = (HttpWebResponse) request.GetResponse())
                {
                    var rdr = new StreamReader(resp.GetResponseStream());
                    var tmp = rdr.ReadToEnd();
                    var user = new JavaScriptSerializer().Deserialize<ZApiModel.UserCollection>(tmp);

                    if (user.user.email == "invalid@example.com" && user.user.name == "Anonymous user")
                    {
                        MessageBox.Show(Form.ActiveForm,@"The username or password you have entered is incorrect, please try again.");
                        return "error";
                    }

                    // Update json data string
                    jsonData = JsonConvert.SerializeObject(user);
                    File.WriteAllText(Settings.Default.dataFolder + "\\kbackup\\user\\profile.json", jsonData);
                }
            }
                //}
            catch (WebException ex)
            {
                if (ex.Message == "The operation has timed out")
                {
                    Thread.Sleep(30000);
                    GetUserData();
                }

                switch (((HttpWebResponse) ex.Response).StatusCode)
                {
                    case HttpStatusCode.Forbidden:
                        MessageBox.Show(Form.ActiveForm,
                            @"Uh oh, it looks like you do not have have access to the resources you are trying to back up. Please ensure you have Admin privileges on your Zendesk account and try again.",
                            @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return "403";

                    case HttpStatusCode.BadRequest:
                        MessageBox.Show(Form.ActiveForm, @"bad request", @"Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return "400";

                    case HttpStatusCode.NotFound:
                        MessageBox.Show(Form.ActiveForm, @"The Zendesk domain you are requesting does not exist.",
                            @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return "404";

                    case (HttpStatusCode) .429:
                        MessageBox.Show(Form.ActiveForm, @"You have hit the rate limit.", @"Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return "429";
                }
            }
            catch (Exception e)
            {
                //Catch all
                MessageBox.Show(Form.ActiveForm, @"The general exception was hit: " + e.Message);
            }
            return string.Empty;
        }

        public void GetCategoryData()
        {
        }

        public void GetSectionData()
        {
        }

        public void GetArticleData()
        {
        }

        public void GetArticleCommentData()
        {
        }

        public void GetTopicData()
        {
        }

        public void GetPostData()
        {
        }

        public void GetPostCommentData()
        {
        }

        /// <summary>
        /// Retrieves all articles, associated images and logs the URL's of the retrieved resources to a log file in the root of the backup.
        /// </summary>
        /// <returns>
        /// True if no error occurs and all articles are retrieved successfully. 
        /// False if an exception occurs.
        /// </returns>
        public static string Get(string apiUrl)
        {
            //Create web request with appropriate Authorisation header. .zendesk.com/api/v2/help_center/articles.json .zendesk.com/api/v2/help_center/en-us/articles.json
            var request = (HttpWebRequest)WebRequest.Create(apiUrl);
            //request.Headers["Authorization"] = GetAuthHeader(Email, Password);
            request.ContentType = "application/json";
            request.Accept = "application/json, application/xml, text/json, htmlContent/x-json, htmlContent/javascript, htmlContent/xml";
            request.Method = nameof(Requests.Method.GET);
            request.ContentLength = 0;
            request.Timeout = 10000;

            //Get web request response and seralize into json object
            using (var resp = (HttpWebResponse)request.GetResponse())
            {
                var rdr = new StreamReader(resp.GetResponseStream());
                return rdr.ReadToEnd();
                //var deserializer = new JavaScriptSerializer { MaxJsonLength = int.MaxValue };
                //var articles = deserializer.Deserialize<ZApiModel.ArticleCollection>(tmp);
            }
        }

        /// <summary>
        /// Posts data to specified api url.
        /// </summary>
        /// <param name="apiUrl">Api url to post data to.</param>
        /// <param name="content">Json formatted string data.</param>
        /// <returns>
        /// True: When the request completed successfully.
        /// False: When the request does not complete successfully. 
        /// </returns>
        public static bool Post(string apiUrl, string content)
        {
            try
            {
                // Create a request using a URL that can receive a post. 
                WebRequest request = WebRequest.Create(apiUrl);
                // Set the Method property of the request to POST.
                request.Method = nameof(Requests.Method.POST);
                //request.Headers["Authorization"] = GetAuthHeader(Email, Password);
                // Create POST data and convert it to a byte array.
                string postData = content;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/json";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                // Get the response.
                WebResponse response = request.GetResponse();
                // Display the status.
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                // Get the stream containing content returned by the server.
                dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Display the content.
                Console.WriteLine(responseFromServer);
                // Clean up the streams.
                reader.Close();
                dataStream.Close();
                response.Close();
            }

            catch (WebException ex)
            {
                if (ex.Message == "The operation has timed out")
                {
                    Thread.Sleep(30000);
                    Post(apiUrl, content);
                }

                switch (((HttpWebResponse)ex.Response).StatusCode)
                {
                    case HttpStatusCode.Forbidden:
                        MessageBox.Show(Form.ActiveForm, @"Uh oh, it looks like you do not have have access to the portal you are trying to upload to. Please ensure you have Admin privileges on your Zendesk account and try again.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// Posts data to specified api url.
        /// </summary>
        /// <param name="apiUrl">Api url to post data to.</param>
        /// <param name="content">Json formatted string data.</param>
        /// <returns>
        /// True: When the request completed successfully.
        /// False: When the request does not complete successfully. 
        /// </returns>
        public static bool Update(string apiUrl, string content)
        {
            try
            {
                // Create a request using a URL that can receive a post. 
                WebRequest request = WebRequest.Create(apiUrl);
                // Set the Method property of the request.
                request.Method = nameof(Requests.Method.PUT);
                //request.Headers["Authorization"] = GetAuthHeader(Email, Password);
                // Create POST data and convert it to a byte array.
                string postData = content;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/json";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                // Get the response.
                WebResponse response = request.GetResponse();
                // Display the status.
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                // Get the stream containing content returned by the server.
                dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Display the content.
                Console.WriteLine(responseFromServer);
                // Clean up the streams.
                reader.Close();
                dataStream.Close();
                response.Close();
            }

            catch (WebException ex)
            {
                if (ex.Message == "The operation has timed out")
                {
                    Thread.Sleep(30000);
                    Post(apiUrl, content);
                }

                switch (((HttpWebResponse)ex.Response).StatusCode)
                {
                    case HttpStatusCode.Forbidden:
                        MessageBox.Show(Form.ActiveForm, @"Uh oh, it looks like you do not have have access to the portal you are trying to upload to. Please ensure you have Admin privileges on your Zendesk account and try again.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// Get's a list of images from the html content of the article.
        /// </summary>
        /// <param name="htmlContent">Html content of the article.</param>
        /// <param name="article">Article to check for img html elements.</param>
        private static void GetImageList(StringBuilder htmlContent, ZApiModel.Article article, long sectionId)
        {
            ////Get list of images associated to the article
            //var urls = (from Match m in Regex.Matches(htmlContent.ToString(), "<img.+?src=[\"'](.+?)[\"'].+?>", RegexOptions.IgnoreCase | RegexOptions.Multiline) select m.Groups[1].Value).ToList();
            //var urlList = urls as IList<string> ?? urls.ToList();
            //if (!urlList.Any()) return;
            //if (!Directory.Exists(BackupFolder + "\\images"))
            //{
            //    Directory.CreateDirectory(BackupFolder + "\\images");
            //}

            //StartImageDownload(urlList, article, sectionId);
        }

        /// <summary>
        /// Starts the download of the image from the particular article.
        /// </summary>
        /// <param name="urlList">List of img url's from article.</param>
        /// <param name="article">Article which contains the image that will be downloaded.</param>
        private static void StartImageDownload(IEnumerable<string> urlList, ZApiModel.Article article, long sectionId)
        {
            //Download and save image to \images sub folder of backup root
            foreach (var url in urlList)
            {
                //var str = url.Substring(url.LastIndexOf("/", StringComparison.Ordinal));
                //var fullFileName = str.Split(Convert.ToChar("."));
                //var fileName = RemoveInvalidFilePathCharacters(fullFileName[0].Trim(Convert.ToChar("/")), "_");

                //if (!DownloadImage(url, BackupFolder + "\\images\\" + ArticleId + "_" + fileName, sectionId))
                //    continue;

                ////Log the backed up resource in the backup log
                //using (var sw = File.AppendText(BackupFolder + @"\BackupLog.txt"))
                //{
                //    sw.WriteLine("image_" + (article.section_id.ToString() ?? ArticleId) + ": " + url);
                //}
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
        private static bool DownloadImage(string uri, string filePathName, long sectionId)
        {
            if (uri.Contains("base64"))
            {
                var fp = filePathName.Substring(0, filePathName.LastIndexOf(Convert.ToChar(@"\")) + 20);
                var encString = uri.Split(Convert.ToChar(","));
                byte[] decodedString = Convert.FromBase64String(encString[1]);

                using (var stream = new MemoryStream(decodedString, 0, decodedString.Length))
                {
                    Image image = Image.FromStream(stream);
                    //fp = RemoveInvalidFilePathCharacters(fp, "_");
                    image.Save(fp + ".png", ImageFormat.Png);
                }
            }
            else
            {
                if (!uri.Contains("http://") && !uri.Contains("https://") && !uri.Contains("//") && !uri.Contains("////"))
                {
                    //uri = "https://" + Domain + ".zendesk.com" + uri;
                }

                if (uri.Contains("////"))
                {
                    uri = uri.Replace("////", "http://");
                }

                var imgUri = new Uri(uri, UriKind.RelativeOrAbsolute);

                //Create web request with appropriate Authorisation header.
                var request = (HttpWebRequest)WebRequest.Create(imgUri);
                //request.Headers["Authorization"] = Requests.GetAuthHeader(Email, Password);
                request.Timeout = 10000;

                try
                {
                    HttpWebResponse response;
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
            return true;
        }
    }
}
