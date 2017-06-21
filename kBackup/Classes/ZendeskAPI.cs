using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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
        //public static int PageNumber = 1;

        #endregion

        #region Private Properties
        private static Dictionary<Int64, string> _topics;

        private static Dictionary<string, User> _users;

        private static List<string> relevantSections = new List<string>() {
                "206818767","206818467","206817447","206817387","206818427","206818007","206817507","206817467","206817487",
                "206817547","206817527","206818367","206817567","206817587","206817647","206817667","206818727" };

        private static List<string> relevantTopics = new List<string>() {
                "201245327","201245347","201245307","201245407","201245387","201245367","201245207","201245447","201245107","201245127","201245147","201245047" };

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
            public List<Content> Posts { get; set; }
            public List<Content> Topics { get; set; }
            public List<Content> Sections { get; set; }

            public List<Content> Comments { get; set; }

            [JsonPropertyAttribute("ArticleAttachments")]
            public List<Content> Article_attachments { get; set; }

            [JsonPropertyAttribute("NextPage")]
            public string Next_Page { get; set; }
        }

        /// <summary>
        /// Content properties.
        /// </summary>
        public class Content
        {
            [JsonPropertyAttribute("Id")]
            public Int64 Id { get; set; }

            [JsonPropertyAttribute("Url")]
            public string Html_url { get; set; }

            [JsonPropertyAttribute("Title")]
            public string Title { get; set; }

            [JsonPropertyAttribute("Body")]
            public string Body { get; set; }

            [JsonPropertyAttribute("Details")]
            public string Details { get; set; }

            [JsonPropertyAttribute("SectionId")]
            public Int64 Section_id { get; set; }

            [JsonPropertyAttribute("ForumId")]
            public string Forum_id { get; set; }

            //for posts
            [JsonPropertyAttribute("CreatedAt")]
            public string Created_at { get; set; }

            [JsonPropertyAttribute("AuthorId")]
            public string Author_id { get; set; }

            [JsonPropertyAttribute("CommentCount")]
            public Int64 Comment_Count { get; set; }

            [JsonPropertyAttribute("TopicId")]
            public Int64 Topic_id { get; set; }

            //for topics
            [JsonPropertyAttribute("Position")]
            public Int64 Position { get; set; }

            [JsonPropertyAttribute("Name")]
            public string Name { get; set; }

            //for sections
            [JsonPropertyAttribute("CategoryId")]
            public string Category_id { get; set; }

            //for comments
            [JsonPropertyAttribute("PostId")]
            public string Post_id { get; set; }

            //for attachments
            [JsonPropertyAttribute("ContentUrl")]
            public string Content_Url { get; set; }

            [JsonPropertyAttribute("FileName")]
            public string File_name { get; set; }

            [JsonPropertyAttribute("ContentType")]
            public string Content_type { get; set; }
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
            [JsonPropertyAttribute("Id")]
            public Int64 Id { get; set; }
            [JsonPropertyAttribute("Name")]
            public string Name { get; set; }
            [JsonPropertyAttribute("Email")]
            public string Email { get; set; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Get list of topics
        /// </summary>
        /// <param name="portal"></param>
        /// <returns></returns>
        public static bool GetTopics(int PageNumber)
        {
            string apiUrl = "https://" + Domain + ".zendesk.com/api/v2/community/topics.json" + Query + PageNumber + "&per_page=100";
            var request = (HttpWebRequest)WebRequest.Create(apiUrl);
            request.Headers["Authorization"] = GetAuthHeader(Email, Password);
            request.ContentType = "application/json";
            request.Accept = "application/json, application/xml, text/json, htmlContent/x-json, htmlContent/javascript, htmlContent/xml";
            request.Method = nameof(Method.GET);
            request.ContentLength = 0;
            request.Timeout = 10000;
            request.AutomaticDecompression = DecompressionMethods.GZip;

            var resp = (HttpWebResponse)request.GetResponse();
            var rdr = new StreamReader(resp.GetResponseStream());
            var tmp = rdr.ReadToEnd();
            resp.Close();
            var topics = new JavaScriptSerializer().Deserialize<ContentCollection>(tmp); //TODO: use specific collection
            if (_topics == null)
                _topics = new Dictionary<long, string>();
            var topicsMapFilePath = ZendeskApi.BackupFolder + "\\topics.csv";

            Directory.CreateDirectory(BackupFolder);

            foreach (var topic in topics.Topics)
            {
                if (relevantTopics.Contains(topic.Id.ToString()))
                {
                    File.AppendAllText(topicsMapFilePath, topic.Id + "," + topic.Name + "\r\n");
                    if (topic.Position == 0)
                    {
                        Directory.CreateDirectory(ZendeskApi.BackupFolder + "\\Posts\\" + topic.Id.ToString());
                        _topics.Add(topic.Id, ZendeskApi.BackupFolder + "\\Posts\\" + topic.Id.ToString());
                    }
                    else if (_topics.ContainsKey(topic.Id))
                    {
                        Directory.CreateDirectory(_topics[topic.Id] + "\\" + topic.Id.ToString());
                        _topics.Add(topic.Id, _topics[topic.Id] + "\\" + topic.Id.ToString());
                    }
                    else
                    {
                        int i = 0;
                        //handle cases where the parent folders do not exist yet
                    }
                }
                else
                {
                    File.AppendAllText(topicsMapFilePath, topic.Id + " (skipped)," + topic.Name + "\r\n");
                }
            }

            if (topics.Next_Page != null)
            {
                PageNumber++;
                GetTopics(PageNumber);
            }
            return false;
        }

        /// <summary>
        /// Get list of sections
        /// </summary>
        /// <returns></returns>
        public static bool GetSections(int PageNumber)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            string apiUrl = "https://" + Domain + ".zendesk.com/api/v2/help_center/sections.json" + Query + PageNumber + "&per_page=100";
            var request = (HttpWebRequest)WebRequest.Create(apiUrl);
            request.Headers["Authorization"] = GetAuthHeader(Email, Password);
            request.ContentType = "application/json";
            request.Accept = "application/json, application/xml, text/json, htmlContent/x-json, htmlContent/javascript, htmlContent/xml";
            request.Method = nameof(Method.GET);
            request.ContentLength = 0;
            request.Timeout = 15000;
            request.AutomaticDecompression = DecompressionMethods.GZip;

            var resp = (HttpWebResponse)request.GetResponse();
            var rdr = new StreamReader(resp.GetResponseStream());
            var tmp = rdr.ReadToEnd();
            resp.Close();
            var sections = new JavaScriptSerializer().Deserialize<ContentCollection>(tmp); //TODO: use specific collection
            if (_topics == null)
                _topics = new Dictionary<long, string>();
            var topicsMapFilePath = ZendeskApi.BackupFolder + "\\sections.csv";

            Directory.CreateDirectory(BackupFolder);

            foreach (var section in sections.Sections)
            {
                if (relevantSections.Contains(section.Id.ToString()))
                {
                    File.AppendAllText(topicsMapFilePath, section.Id + "," + section.Name + "\r\n");
                    if (section.Category_id == "")
                    {
                        Directory.CreateDirectory(ZendeskApi.BackupFolder + "\\Articles\\" + section.Id.ToString());
                        _topics.Add(section.Id, ZendeskApi.BackupFolder + "\\Articles\\" + section.Id.ToString());
                    }
                    else if (_topics.ContainsKey(section.Id))
                    {
                        Directory.CreateDirectory(_topics[section.Id] + "\\" + section.Id.ToString());
                        _topics.Add(section.Id, _topics[section.Id] + "\\" + section.Id.ToString());
                    }
                    else
                    {
                        Directory.CreateDirectory(ZendeskApi.BackupFolder + "\\Articles\\" + section.Category_id + "\\" + section.Id.ToString());
                        _topics.Add(section.Id, ZendeskApi.BackupFolder + "\\Articles\\" + section.Category_id + "\\" + section.Id.ToString());
                    }
                }
                else
                {
                    File.AppendAllText(topicsMapFilePath, section.Id + " (skipped)," + section.Name + "\r\n");
                }
            }

            if (sections.Next_Page != null)
            {
                PageNumber++;
                GetSections(PageNumber);
            }
            return false;
        }

        /// <summary>
        /// Retrieves all posts, associated images and logs the URL's of the retrieved resources to a log file in the root of the backup.
        /// </summary>
        /// <returns>
        /// True if no error occurs and all articles are retrieved successfully. 
        /// False if an exception occurs.
        /// </returns>
        public static bool GetPosts(ComboBox portal, int PageNumber)
        {
            //Sets the correct API string for the request.
            string apiUrl;
            if (portal.SelectedIndex == 0)
            {
                apiUrl = "https://" + Domain + ".zendesk.com/api/v2/community/posts.json" + Query + PageNumber + "&per_page=100";
            }
            else
            {
                return false;
            }

            //Create web request with appropriate Authorisation header. .zendesk.com/api/v2/help_center/articles.json .zendesk.com/api/v2/help_center/en-us/articles.json
            var request = (HttpWebRequest)WebRequest.Create(apiUrl);
            request.Headers["Authorization"] = GetAuthHeader(Email, Password);
            request.ContentType = "application/json";
            request.Accept = "application/json, application/xml, text/json, htmlContent/x-json, htmlContent/javascript, htmlContent/xml";
            request.Method = nameof(Method.GET);
            request.ContentLength = 0;
            request.Timeout = 10000;
            request.AutomaticDecompression = DecompressionMethods.GZip;

            try
            {
                //Get web request response and seralize into json object
                using (var resp = (HttpWebResponse)request.GetResponse())
                {
                    var rdr = new StreamReader(resp.GetResponseStream());
                    var tmp = rdr.ReadToEnd();
                    resp.Close();
                    var deserializer = new JavaScriptSerializer { MaxJsonLength = int.MaxValue };
                    var posts = deserializer.Deserialize<ContentCollection>(tmp);
                    var htmlContent = new StringBuilder();

                    if (!SavePosts(posts, htmlContent)) return false;

                    //Pagination of article api endpoint
                    if (posts.Next_Page != null)
                    {
                        //Thread.Sleep(5000);
                        PageNumber++;
                        GetPosts(portal, PageNumber);
                    }
                }              
            }

            catch (WebException ex)
            {
                if (ex.Message == "The operation has timed out")
                {
                    Console.Write("sleep 30, get posts");
                    Thread.Sleep(30000);
                    return GetPosts(portal, PageNumber);
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
        public static bool GetArticles(ComboBox portal, int PageNumber)
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
            request.AutomaticDecompression = DecompressionMethods.GZip;

            try
            {
                //Get web request response and seralize into json object
                using (var resp = (HttpWebResponse)request.GetResponse())
                {
                    var rdr = new StreamReader(resp.GetResponseStream());
                    var tmp = rdr.ReadToEnd();
                    resp.Close();
                    var deserializer = new JavaScriptSerializer { MaxJsonLength = int.MaxValue };
                    var articles = deserializer.Deserialize<ContentCollection>(tmp);
                    var htmlContent = new StringBuilder();

                    if (!SaveArticles(articles, htmlContent)) return false;

                    //Pagination of article api endpoint
                    if (articles.Next_Page != null)
                    {
                        //Thread.Sleep(5000);
                        PageNumber++;
                        GetArticles(portal, PageNumber);
                    }
                }
            }

            catch (WebException ex)
            {
                if (ex.Message == "The operation has timed out")
                {
                    Console.Write("sleep 30, get articles");
                    Thread.Sleep(30000);
                    return GetArticles(portal, PageNumber);
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
        /// Retrieves all comments of an article
        /// </summary>
        /// <returns>
        /// True if no error occurs and all articles are retrieved successfully. 
        /// False if an exception occurs.
        /// </returns>
        private static bool GetArticleComments(string article_id, string save_to)
        {
            //Sets the correct API string for the request.
            string apiUrl = apiUrl = "https://" + Domain + ".zendesk.com/api/v2/help_center/articles/" + article_id + "/comments.json" + "?per_page=100";

            //Create web request with appropriate Authorisation header. .zendesk.com/api/v2/help_center/articles.json .zendesk.com/api/v2/help_center/en-us/articles.json
            var request = (HttpWebRequest)WebRequest.Create(apiUrl);
            request.Headers["Authorization"] = GetAuthHeader(Email, Password);
            request.ContentType = "application/json";
            request.Accept = "application/json, application/xml, text/json, htmlContent/x-json, htmlContent/javascript, htmlContent/xml";
            request.Method = nameof(Method.GET);
            request.ContentLength = 0;
            request.Timeout = 10000;
            request.AutomaticDecompression = DecompressionMethods.GZip;

            try
            {
                //Get web request response and seralize into json object
                using (var resp = (HttpWebResponse)request.GetResponse())
                {
                    var rdr = new StreamReader(resp.GetResponseStream());
                    var tmp = rdr.ReadToEnd();
                    resp.Close();
                    var deserializer = new JavaScriptSerializer { MaxJsonLength = int.MaxValue };
                    var comments = deserializer.Deserialize<ContentCollection>(tmp);
                    var htmlContent = new StringBuilder();

                    if (!SavePostComments(article_id, comments, htmlContent, save_to)) return false;

                    //Pagination of article api endpoint
                    if (comments.Next_Page != null)
                    {
                        //Thread.Sleep(5000);
                        return false; //too many comments?
                    }
                }
            }

            catch (WebException ex)
            {
                if (ex.Message == "The operation has timed out")
                {
                    Console.Write("sleep 30, get article comments");
                    Thread.Sleep(30000);
                    return GetArticleComments(article_id, save_to);
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
        /// Retrieves all attachments of an article
        /// </summary>
        /// <returns>
        /// True if no error occurs and all articles are retrieved successfully. 
        /// False if an exception occurs.
        /// </returns>
        private static bool GetArticleAttachments(string article_id, string save_to)
        {
            //Sets the correct API string for the request.
            string apiUrl = apiUrl = "https://" + Domain + ".zendesk.com/api/v2/help_center/articles/" + article_id + "/attachments/block.json" + "?per_page=100";

            //Create web request with appropriate Authorisation header. .zendesk.com/api/v2/help_center/articles.json .zendesk.com/api/v2/help_center/en-us/articles.json
            var request = (HttpWebRequest)WebRequest.Create(apiUrl);
            request.Headers["Authorization"] = GetAuthHeader(Email, Password);
            request.ContentType = "application/json";
            request.Accept = "application/json, application/xml, text/json, htmlContent/x-json, htmlContent/javascript, htmlContent/xml";
            request.Method = nameof(Method.GET);
            request.ContentLength = 0;
            request.Timeout = 10000;
            request.AutomaticDecompression = DecompressionMethods.GZip;

            try
            {
                //Get web request response and seralize into json object
                using (var resp = (HttpWebResponse)request.GetResponse())
                {
                    var rdr = new StreamReader(resp.GetResponseStream());
                    var tmp = rdr.ReadToEnd();
                    resp.Close();
                    var deserializer = new JavaScriptSerializer { MaxJsonLength = int.MaxValue };
                    var attachments = deserializer.Deserialize<ContentCollection>(tmp);
                    var htmlContent = new StringBuilder();
                    if (attachments.Article_attachments.Count>0)
                        if (!SaveArticleAttachments(article_id, attachments, save_to)) return false;

                }
            }

            catch (WebException ex)
            {
                if (ex.Message == "The operation has timed out")
                {
                    Console.Write("sleep 30, get article attachments");
                    Thread.Sleep(30000);
                    return GetArticleAttachments(article_id, save_to);
                }
                else
                {
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
            request.AutomaticDecompression = DecompressionMethods.GZip;

            try
            {
                //Get web request response.
                var resp = (HttpWebResponse)request.GetResponse();
                var rdr = new StreamReader(resp.GetResponseStream() ?? Stream.Null);
                var tmp = rdr.ReadToEnd();
                resp.Close();

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
        private static bool SaveArticles(ContentCollection articles, StringBuilder htmlContent)
        {
            foreach (var article in articles.Articles ?? articles.Topics)
            {
                if (relevantSections.Contains(article.Section_id.ToString())==false)
                {
                    continue;
                }

                //Write article heading and content into text file and save as html
                ArticleId = article.Id.ToString();
                htmlContent.AppendLine("<h1>" + article.Title + "</h1>");
                htmlContent.AppendLine(article.Body);

                try
                {
                    Directory.CreateDirectory(BackupFolder);
                    string htmlContentWithFixedImageURL = ReplaceImageURLsInHTML(htmlContent.ToString(), article, _topics[article.Section_id]);
                    string filepath = _topics[article.Section_id] + @"\" + RemoveInvalidFilePathCharacters((article.Title + " (" + ArticleId + ")").Trim(Convert.ToChar("/")), "_").TrimStart(Convert.ToChar("_")) + ".html";
                    if (filepath.Length >= 260)
                        filepath = _topics[article.Section_id] + @"\" + ArticleId + ".html";
                    File.WriteAllText(filepath, htmlContentWithFixedImageURL.ToString(), Encoding.UTF8);

                    //Log the backed up resource in the backup log
                    using (var sw = File.AppendText(BackupFolder + @"\BackupLog.txt"))
                    {
                        sw.WriteLine("article_" + RemoveInvalidFilePathCharacters(article.Title.Trim(Convert.ToChar("/")), "_").TrimStart(Convert.ToChar("_")) + " (" + (article.Section_id.ToString() ?? ArticleId) + "): " + (article.Html_url ?? "https://" + Domain + ".zendesk.com/entries/" + ArticleId));
                    }

                    using (var sw = File.AppendText(BackupFolder + @"\Articles.csv"))
                    {
                        sw.WriteLine(ArticleId + "," + article.Created_at + "," + article.Author_id + "," + article.Title + "," + filepath);
                    }

                    GetArticleComments(ArticleId, _topics[article.Section_id]);

                    GetArticleAttachments(ArticleId, _topics[article.Section_id]);

                    //GetImageList(htmlContent, article, article.Section_id);
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
        /// Retrieves all comments of a post
        /// </summary>
        /// <returns>
        /// True if no error occurs and all articles are retrieved successfully. 
        /// False if an exception occurs.
        /// </returns>
        private static bool GetPostComments(string post_id, string save_to)
        {
            //Sets the correct API string for the request.
            string apiUrl = "https://" + Domain + ".zendesk.com/api/v2/community/posts/" + post_id + "/comments.json" + "?per_page=100";

            //Create web request with appropriate Authorisation header. .zendesk.com/api/v2/help_center/articles.json .zendesk.com/api/v2/help_center/en-us/articles.json
            var request = (HttpWebRequest)WebRequest.Create(apiUrl);
            request.Headers["Authorization"] = GetAuthHeader(Email, Password);
            request.ContentType = "application/json";
            request.Accept = "application/json, application/xml, text/json, htmlContent/x-json, htmlContent/javascript, htmlContent/xml";
            request.Method = nameof(Method.GET);
            request.ContentLength = 0;
            request.Timeout = 10000;
            request.AutomaticDecompression = DecompressionMethods.GZip;

            try
            {
                //Get web request response and seralize into json object
                using (var resp = (HttpWebResponse)request.GetResponse())
                {
                    var rdr = new StreamReader(resp.GetResponseStream());
                    var tmp = rdr.ReadToEnd();
                    resp.Close();
                    var deserializer = new JavaScriptSerializer { MaxJsonLength = int.MaxValue };
                    var comments = deserializer.Deserialize<ContentCollection>(tmp);
                    var htmlContent = new StringBuilder();

                    if (!SavePostComments(post_id, comments, htmlContent, save_to)) return false;

                    //Pagination of article api endpoint
                    if (comments.Next_Page != null)
                    {
                        //Thread.Sleep(5000);
                        return false; //too many comments?
                    }
                }
            }

            catch (WebException ex)
            {
                if (ex.Message == "The operation has timed out")
                {
                    Console.Write("sleep 30, get post comments");
                    Thread.Sleep(30000);
                    return GetPostComments(post_id, save_to);
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
        /// Saves collection of content locally.
        /// </summary>
        /// <param name="posts">Collection of posts.</param>
        /// <param name="htmlContent">Html content of the posts.</param>
        /// <returns>Returns True if post saved successfully, False if post not saved.</returns>
        private static bool SavePosts(ContentCollection posts, StringBuilder htmlContent)
        {
            foreach (var post in posts.Posts ?? posts.Topics)
            {
                if (relevantTopics.Contains(post.Topic_id.ToString())==false)
                {
                    continue;
                }

                //Write article heading and content into text file and save as html
                ArticleId = post.Id.ToString();
                htmlContent.AppendLine("<h1>" + post.Title + "</h1>");
                htmlContent.AppendLine(post.Details);

                try
                {
                    Directory.CreateDirectory(_topics[post.Topic_id]);
                    string htmlContentWithFixedImageURL = ReplaceImageURLsInHTML(htmlContent.ToString(), post, _topics[post.Topic_id]);
                    string filepath = _topics[post.Topic_id] + @"\" + RemoveInvalidFilePathCharacters((post.Title + " (" + ArticleId + ")").Trim(Convert.ToChar("/")), "_").TrimStart(Convert.ToChar("_")) + ".html";
                    if (filepath.Length >= 260)
                        filepath = _topics[post.Topic_id] + @"\" + ArticleId + ".html";
                    File.WriteAllText(filepath, htmlContentWithFixedImageURL.ToString(), Encoding.UTF8);

                    //Log the backed up resource in the backup log
                    using (var sw = File.AppendText(BackupFolder + @"\BackupLog.txt"))
                    {
                        sw.WriteLine("post_" + RemoveInvalidFilePathCharacters(post.Title.Trim(Convert.ToChar("/")), "_").TrimStart(Convert.ToChar("_")) + " (" + (post.Section_id.ToString() ?? ArticleId) + "): " + (post.Html_url ?? "https://" + Domain + ".zendesk.com/entries/" + ArticleId));
                    }

                    GetUser(post.Author_id);

                    using (var sw = File.AppendText(BackupFolder + @"\Posts.csv"))
                    {
                        sw.WriteLine(ArticleId + "," + post.Created_at + "," + post.Author_id + "," + post.Title + "," + filepath);
                    }

                    if (post.Comment_Count>0)
                    {
                        GetPostComments(ArticleId, _topics[post.Topic_id]);
                    }

                    //GetImageList(htmlContent, post, post.Section_id);
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
        /// Saves collection of content locally.
        /// </summary>
        /// <param name="posts">Collection of posts.</param>
        /// <param name="htmlContent">Html content of the posts.</param>
        /// <returns>Returns True if post saved successfully, False if post not saved.</returns>
        private static bool SavePostComments(string post_id, ContentCollection posts, StringBuilder htmlContent, string save_to)
        {
            int comments = posts.Comments.Count;
            foreach (var comment in posts.Comments)
            {
                //Write article heading and content into text file and save as html
                string commentId = comment.Id.ToString();
                htmlContent.AppendLine(comment.Body);

                try
                {
                    string htmlContentWithFixedImageURL = ReplaceImageURLsInHTML(htmlContent.ToString(), comment, save_to);
                    string filepath = save_to + @"\comment_" + post_id + "_" + comments.ToString() + ".html";
                    
                    //if (filepath.Length >= 260)
                    //    filepath = _topics[comment.Topic_id] + @"\" + commentId + ".html";
                    File.WriteAllText(filepath, htmlContentWithFixedImageURL.ToString(), Encoding.UTF8);

                    //Log the backed up resource in the backup log
                    using (var sw = File.AppendText(BackupFolder + @"\BackupLog.txt"))
                    {
                        sw.WriteLine("comment_" + comments.ToString() + " (" + commentId + "): " + (comment.Html_url ?? "https://" + Domain + ".zendesk.com/entries/" + commentId));
                    }

                    GetUser(comment.Author_id);

                    using (var sw = File.AppendText(BackupFolder + @"\Comments.csv"))
                    {
                        sw.WriteLine(post_id + "," + comments.ToString() + "," + commentId + "," + comment.Created_at + "," + comment.Author_id + "," + filepath);
                    }

                    comments--;

                    //GetImageList(htmlContent, post, post.Section_id);
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
        /// Saves collection of content locally.
        /// </summary>
        /// <param name="posts">Collection of posts.</param>
        /// <param name="htmlContent">Html content of the posts.</param>
        /// <returns>Returns True if post saved successfully, False if post not saved.</returns>
        private static bool SaveArticleAttachments(string post_id, ContentCollection posts, string save_to)
        {
            int attachments = posts.Article_attachments.Count;
            foreach (var att in posts.Article_attachments)
            {
                //Write article heading and content into text file and save as html
                string commentId = att.Id.ToString();
                try
                {
                    string filepath = save_to + "\\" + att.File_name;

                    //if (filepath.Length >= 260)
                    //    filepath = _topics[comment.Topic_id] + @"\" + commentId + ".html";
                    string uri = att.Content_Url;
                    if (uri.Contains("qualisystemscom.zendesk.com"))
                    {
                        uri = uri.Replace("qualisystemscom.zendesk.com", "support.quali.com");
                    }
                    if (!DownloadImage(uri, filepath))
                        continue;

                    using (var sw = File.AppendText(BackupFolder + @"\Attachments.csv"))
                    {
                        sw.WriteLine(post_id + "," + attachments.ToString() + "," + filepath + "," + att.File_name + "," + att.Content_type);
                    }

                    attachments--;

                    //GetImageList(htmlContent, post, post.Section_id);
                }
                catch (UnauthorizedAccessException)
                {
                    //Occurs when user selects a directory from the folder browser dialog that the user does not have access to
                    MessageBox.Show(Form.ActiveForm,
                        @"You do not have access to the selected directory, please select Backup and try again.");
                    return false;
                }
            }
            return true;
        }

        private static String ConvertImageURLToBase64(String url)
        {
            StringBuilder _sb = new StringBuilder();

            Byte[] _byte = GetImage(url);

            if (_byte != null)
            {
                _sb.Append(Convert.ToBase64String(_byte, 0, _byte.Length));
                return _sb.ToString();
            }
            else
                return url;
        }

        private static byte[] GetImage(string uri)
        {
            Stream stream = null;
            byte[] buf;

            try
            {
                if (!uri.Contains("http://") && !uri.Contains("https://") &&
                    !uri.StartsWith("http://") && !uri.StartsWith("https://") &&
                    !uri.Contains("//") && !uri.Contains("////"))
                {
                    uri = "https://" + Domain + ".zendesk.com" + uri;
                }

                if (uri.Contains("////"))
                {
                    uri = uri.Replace("////", "http://");
                }

                if (uri.Contains(Domain) == false)
                    return null;

                WebProxy myProxy = new WebProxy();
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
                req.Headers["Authorization"] = GetAuthHeader(Email, Password);

                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                stream = response.GetResponseStream();

                using (BinaryReader br = new BinaryReader(stream))
                {
                    int len = (int)(response.ContentLength);
                    buf = br.ReadBytes(len);
                    br.Close();
                }

                stream.Close();
                response.Close();
            }
            catch (Exception exp)
            {
                buf = null;
            }

            return (buf);
        }

        /// <summary>
        /// Replaces the image src values to match the image names and location in the backup.
        /// </summary>
        /// <param name="htmlContent">Html content of the article.</param>
        /// <param name="article">Article to check for img html elements.</param>
        private static string ReplaceImageURLsInHTML(string htmlContent, Content article, string save_to)
        {
            //Get list of images associated to the article
            var urls = GetImageUrls(htmlContent.ToString());
            var urlList = urls as IList<string> ?? urls.ToList();
            if (!urlList.Any()) return htmlContent;

            bool useBase64 = false;

            if (useBase64)
            {
                //Directory.CreateDirectory(_topics[article.Topic_id] + "\\images");
                foreach (var url in urlList)
                {
                    if (url.IndexOf(";base64,") > 0)
                        continue;

                    string base64 = ConvertImageURLToBase64(url);
                    if (base64 != url)
                    {
                        string ext = url.Substring(url.Length - 6).ToLower();
                        if (ext.EndsWith(".jpg") || ext.EndsWith(".jpeg"))
                            base64 = "data:image/jpeg;base64," + base64;
                        else if (ext.EndsWith(".png"))
                            base64 = "data:image/png;base64," + base64;
                        else if (ext.EndsWith(".gif"))
                            base64 = "data:image/gif;base64," + base64;
                        else if (ext.EndsWith(".bmp"))
                            base64 = "data:image/bmp;base64," + base64;
                        else
                            continue;

                        htmlContent = htmlContent.Replace(url, base64);
                    }
                }
            }
            else
            {
                string images_folder = save_to + "\\images";
                Directory.CreateDirectory(images_folder);
                int cur = 0;
                foreach (var url in urlList)
                {
                    cur++;
                    var str = url.Substring(url.LastIndexOf("/", StringComparison.Ordinal) + 1);
                    var fullFileName = str.Substring(str.IndexOf("=") + 1);
                    if (url.Contains("base64") || fullFileName.Length == 0)
                        fullFileName = "image" + cur.ToString() + ".png";

                    if (!DownloadImage(url, images_folder + "\\" + ArticleId + "_" + RemoveInvalidFilePathCharacters(fullFileName, "_")))
                        continue;

                    htmlContent = htmlContent.Replace(url, "images\\" + ArticleId + "_" + RemoveInvalidFilePathCharacters(fullFileName, "_"));

                    //Log the backed up resource in the backup log 
                    using (var sw = File.AppendText(BackupFolder + @"\BackupLog.txt"))
                    {
                        sw.WriteLine("image_" + cur.ToString() + ": " + url);
                    }

                    using (var sw = File.AppendText(BackupFolder + @"\Images.csv"))
                    {
                        // article id, file path, url in file
                        sw.WriteLine(ArticleId + "," + images_folder + "\\" + ArticleId + "_" + RemoveInvalidFilePathCharacters(fullFileName, "_"), "\\images\\" + ArticleId + "_" + RemoveInvalidFilePathCharacters(fullFileName, "_"));
                    }
                }
            }

            return htmlContent;
        }

        /// <summary>
        /// Get's a list of images from the html content of the article.
        /// </summary>
        /// <param name="htmlContent">Html content of the article.</param>
        /// <param name="article">Article to check for img html elements.</param>
        //private static void GetImageList(StringBuilder htmlContent, Content article, string sectionId)
        //{
        //    //Get list of images associated to the article
        //    var urls = GetImageUrls(htmlContent.ToString());
        //    var urlList = urls as IList<string> ?? urls.ToList();
        //    if (!urlList.Any()) return;
        //    if (!Directory.Exists(_topics[article.Topic_id] + "\\images"))
        //    {
        //        Directory.CreateDirectory(_topics[article.Topic_id] + "\\images");
        //    }

        //    StartImageDownload(urlList, article, sectionId);
        //}

        ///// <summary>
        ///// Starts the download of the image from the particular article.
        ///// </summary>
        ///// <param name="urlList">List of img url's from article.</param>
        ///// <param name="article">Article which contains the image that will be downloaded.</param>
        //private static void StartImageDownload(IEnumerable<string> urlList, Content article, string sectionId)
        //{
        //    //Download and save image to \images sub folder of backup root
        //    int cur = 0;
        //    foreach (var url in urlList)
        //    {
        //        cur++;
        //        var str = url.Substring(url.LastIndexOf("/", StringComparison.Ordinal)+1);
        //        var fullFileName = str.Substring(str.IndexOf("=") + 1);
        //        if (url.Contains("base64") || fullFileName.Length == 0)
        //            fullFileName = "image" + cur.ToString() + ".png";

        //        if (!DownloadImage(url, _topics[article.Topic_id] + "\\images\\" + ArticleId + "_" + RemoveInvalidFilePathCharacters(fullFileName, "_"), sectionId))
        //            continue;

        //        //Log the backed up resource in the backup log 
        //        using (var sw = File.AppendText(BackupFolder + @"\BackupLog.txt"))
        //        {
        //            sw.WriteLine("image_" + (article.Section_id ?? ArticleId) + ": " + url);
        //        }
        //        //Thread.Sleep(1000);
        //    }
        //}

        /// <summary>
        /// Downloads image from provided uri.
        /// </summary>
        /// <param name="uri">Uri of the image to be downloaded.</param>
        /// <param name="filePathName">Location where the image file will be saved to.</param>
        /// <returns>
        /// 
        /// </returns>
        private static bool DownloadImage(string uri, string filePathName)
        {

            using (var sw = File.AppendText(BackupFolder + @"\urlLog.txt"))
            {
                sw.WriteLine("Before: " + uri);
            }

            if (uri.Contains("base64"))
            {
                var fp = filePathName;
                var encString = uri.Split(Convert.ToChar(","));
                byte[] decodedString = Convert.FromBase64String(encString[1]);

                using (var stream = new MemoryStream(decodedString, 0, decodedString.Length))
                {
                    Image image = Image.FromStream(stream);
                    //fp = RemoveInvalidFilePathCharacters(fp, "_");
                    image.Save(fp, ImageFormat.Png);
                }
            }
            else
            {
                if (uri.StartsWith("//") && !uri.StartsWith("////"))
                {
                    uri = "https:" + uri;
                }

                if (!uri.Contains("http://") && !uri.Contains("https://") &&
                    !uri.StartsWith("http://") && !uri.StartsWith("https://") &&
                    !uri.Contains("//") && !uri.Contains("////"))
                {
                    uri = "https://" + Domain + ".zendesk.com" + uri;
                }

                if (uri.Contains("////"))
                {
                    uri = uri.Replace("////", "http://");
                }

                if (uri.Contains("qs-srv-confluence:8090"))
                {
                    //uri = uri.Replace("qs-srv-confluence:8090", "confluence.quali.com");
                    return false;
                }

                if (uri.Contains("support.qualisystems.com"))
                {
                    uri = uri.Replace("support.qualisystems.com", "qualisystemscom.zendesk.com");
                }

                if (uri.Contains("community.qualisystems.com"))
                {
                    uri = uri.Replace("community.qualisystems.com", "qualisystemscom.zendesk.com");
                }

                using (var sw = File.AppendText(BackupFolder + @"\urlLog.txt"))
                {
                    sw.WriteLine("After: " + uri);
                }

                var imgUri = new Uri(uri, UriKind.RelativeOrAbsolute);

                //Create web request with appropriate Authorisation header.
                var request = (HttpWebRequest)WebRequest.Create(imgUri);
                request.Headers["Authorization"] = GetAuthHeader(Email, Password);
                request.Timeout = 15000;
                

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
                                 response.ContentType.StartsWith("text", StringComparison.OrdinalIgnoreCase) ||
                                 response.ContentType.StartsWith("application", StringComparison.OrdinalIgnoreCase))
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
                                using (Stream outputStream = File.OpenWrite(filePathName /*+ fileType*/))
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
                    response.Close();
                }
                catch (WebException ex)
                {
                    if (ex.Message == "The operation has timed out")
                    {
                        Console.Write("sleep 30, download file");
                        Thread.Sleep(30000);
                        return DownloadImage(uri, filePathName);
                    }
                    return false;
                }
                return true;
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
        /// Get list of users. (need more credentials)
        /// </summary>
        /// <returns></returns>
        public static bool GetUsers(int PageNumber)
        {
            var request = (HttpWebRequest)WebRequest.Create("https://" + Domain + ".zendesk.com/api/v2/users.json" + Query + PageNumber);

            request.Headers["Authorization"] = GetAuthHeader(Email, Password);
            request.ContentType = "application/json";
            request.Accept = "application/json, application/xml, text/json, htmlContent/x-json, htmlContent/javascript, htmlContent/xml";
            request.Method = nameof(Method.GET);
            request.ContentLength = 0;
            request.Timeout = 10000;
            request.AutomaticDecompression = DecompressionMethods.GZip;

            var resp = (HttpWebResponse)request.GetResponse();
            var rdr = new StreamReader(resp.GetResponseStream());
            var tmp = rdr.ReadToEnd();
            resp.Close();
            var users = new JavaScriptSerializer().Deserialize<UsersCollection>(tmp);

            foreach (var user in users.Users)
            {
                var topicsMapFilePath = ZendeskApi.BackupFolder + "\\users.csv";

                File.AppendAllText(topicsMapFilePath, user.Id + "," + user.Name + "," + user.Email + "\r\n");
            }

            if (users.NextPage != null)
            {
                PageNumber++;
                GetUsers(PageNumber);
            }
            return false;
        }

        /// <summary>
        /// Get user details
        /// </summary>
        /// <returns></returns>
        public static User GetUser(string userid)
        {
            if (_users == null)
                _users = new Dictionary<string, User>();

            if (_users.ContainsKey(userid))
                return _users[userid];
            
            var request = (HttpWebRequest)WebRequest.Create("https://" + Domain + ".zendesk.com/api/v2/users/" + userid + ".json");

            request.Headers["Authorization"] = GetAuthHeader(Email, Password);
            request.ContentType = "application/json";
            request.Accept = "application/json, application/xml, text/json, htmlContent/x-json, htmlContent/javascript, htmlContent/xml";
            request.Method = nameof(Method.GET);
            request.ContentLength = 0;
            request.Timeout = 10000;
            request.AutomaticDecompression = DecompressionMethods.GZip;

            var resp = (HttpWebResponse)request.GetResponse();
            var rdr = new StreamReader(resp.GetResponseStream());
            var tmp = rdr.ReadToEnd();
            resp.Close();
            tmp = tmp.Substring(0, tmp.Length - 1).Replace("{\"user\":", "");
            var user = new JavaScriptSerializer().Deserialize<User>(tmp);
            
            var topicsMapFilePath = ZendeskApi.BackupFolder + "\\users.csv";
            Directory.CreateDirectory(BackupFolder);
            File.AppendAllText(topicsMapFilePath, user.Id + "," + user.Name + "," + user.Email + "\r\n");
            _users[userid] = user;

            return user;
        }

        #endregion
    }
}