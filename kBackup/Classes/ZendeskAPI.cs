﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
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
        /// Collection of retrieved articles.
        /// </summary>
        public class ArticlesCollection
        {
            public List<Article> Articles { get; set; }
            public string Next_Page { get; set; }
        }

        /// <summary>
        /// Article properties.
        /// </summary>
        public class Article
        {
            public int Id { get; set; }
            public string Url { get; set; }
            public string Title { get; set; }
            public string Body { get; set; }
            public string Section_Id { get; set; }
            public string html_url { get; set; }
        }

        /// <summary>
        /// Retrieves all articles, associated images and logs the URL's of the retrieved resources to a log file in the root of the backup.
        /// </summary>
        /// <returns>
        /// True if no error occurs and all articles are retrieved successfully. 
        /// False if an exception occurs.
        /// </returns>
        public static bool GetArticles()
        {
            //Create web request with appropriate Authorisation header.
            var request = (HttpWebRequest)WebRequest.Create("https://" + Domain + ".zendesk.com/api/v2/help_center/articles.json" + Query + PageNumber + "&per_page=100");
            request.Headers["Authorization"] = GetAuthHeader(Email, Password);
            request.ContentType = "application/json";
            request.Accept = "application/json, application/xml, text/json, htmlContent/x-json, htmlContent/javascript, htmlContent/xml";
            request.Method = nameof(Method.GET);
            request.ContentLength = 0;

            try
            {
                //Get web request response and seralize into json object
                var resp = (HttpWebResponse)request.GetResponse();
                var rdr = new StreamReader(resp.GetResponseStream());
                var tmp = rdr.ReadToEnd();
                var articles = new JavaScriptSerializer().Deserialize<ArticlesCollection>(tmp);
                var htmlContent = new StringBuilder();
                
                foreach (var article in articles.Articles)
                {
                    //Write article heading and content into text file and save as html
                    ArticleId = article.Id.ToString();
                    htmlContent.AppendLine("<h1>" + article.Title + "</h1>");
                    htmlContent.AppendLine(article.Body);

                    try
                    {
                        Directory.CreateDirectory(BackupFolder);
                        File.WriteAllText(BackupFolder + @"\" + ArticleId + ".html", htmlContent.ToString(), Encoding.UTF8);

                        //Log the backed up resource in the backup log
                        using (var sw = File.AppendText(BackupFolder + @"\BackupLog.txt"))
                        {
                            sw.WriteLine("article_" + article.Section_Id + ": " + article.html_url);
                        }

                        //Get list of images associated to the article
                        var urls = GetImageUrls(htmlContent.ToString());
                        var urlList = urls as IList<string> ?? urls.ToList();
                        if (urlList.Any())
                        {
                            if (!Directory.Exists(BackupFolder + "\\images"))
                            {
                                Directory.CreateDirectory(BackupFolder + "\\images");
                            }

                            //Download and save image to \images sub folder of backup root
                            foreach (var url in urlList)
                            {
                                var str = url.Substring(url.LastIndexOf("/", StringComparison.Ordinal));
                                var fullFileName = str.Split(Convert.ToChar("."));
                                var fileName = fullFileName[0].Trim(Convert.ToChar("/"));
                                if (!DownloadImage(url, BackupFolder + "\\images\\" + ArticleId + "_" + fileName))
                                    continue;

                                //Log the backed up resource in the backup log
                                using (var sw = File.AppendText(BackupFolder + @"\BackupLog.txt"))
                                {
                                    sw.WriteLine("image_" + article.Section_Id + ": " + url);
                                }
                            }
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                        //Occurs when user selects a directory from the folder browser dialog that the user does not have access to
                        MessageBox.Show(Form.ActiveForm, @"You do not have access to the selected directory, please select Backup and try again.");
                        return false;
                    }

                    htmlContent.Clear();
                }

                //Pagination of article api endpoint
                if (articles.Next_Page != null)
                {
                    PageNumber++;
                    GetArticles();
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

                    case (HttpStatusCode)429:
                        MessageBox.Show(Form.ActiveForm, @"You have hit the rate limit.");
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
                var rdr = new StreamReader(resp.GetResponseStream());
                var tmp = rdr.ReadToEnd();

                //Check that the user credentials provided matched a valid user account.
                if (tmp.Contains("Anonymous user") && tmp.Contains("invalid@example.com"))
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
        /// Downloads image from provided uri.
        /// </summary>
        /// <param name="uri">Uri of the image to be downloaded.</param>
        /// <param name="filePathName">Location where the image file will be saved to.</param>
        /// <returns>
        /// 
        /// </returns>
        private static bool DownloadImage(string uri, string filePathName)
        {
            //Create web request with appropriate Authorisation header.
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.Headers["Authorization"] = GetAuthHeader(Email, Password);
            HttpWebResponse response;

            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception)
            {
                return false;
            }

            // Check that the remote file was found and that the ContentType is correct.
            try
            {
                if ((response.StatusCode == HttpStatusCode.OK || 
                        response.StatusCode == HttpStatusCode.Moved ||
                        response.StatusCode == HttpStatusCode.Redirect) &&
                        response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase))
                {

                    //Check that file does not already exist, if it does then incrememnt filename.
                    var fileType = "." + response.ContentType.Split(Convert.ToChar("/"))[1];
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

        #region Deprecated

        /// <summary>
        /// Outdated function, previously used to validate user credentials.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        /// 
        public static bool GetUser(string email)
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
                GetArticles();
            }
            return false;
        }

        #endregion
    }
}