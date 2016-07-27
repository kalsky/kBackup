using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace kBackup.Classes
{
    /// <summary>
    /// This class will be used to automate the retrieval of cached content using 
    /// Google Web Cache automating the process described here:
    /// https://support.zendesk.com/hc/en-us/community/posts/209397608-Deleted-your-Help-Center-content-Not-to-worry-
    /// </summary>
    class Crawler
    {
        #region WIP
        
        //This class will be used 
        public static string UrlPrefix { get; set; } = "http://webcache.googleusercontent.com/search?q=cache:";
        public List<string> DomainUrls = new List<string> { String.Empty };
        public List<string> CategoryUrls = new List<string>();
        public List<string> SectionUrls = new List<string>();
        public List<string> ArticleUrls = new List<string>();

        public void Crawl()
        {
            //GetLinks("<section class=\"category\">", DomainUrls, CategoryUrls);
            //GetLinks("<section class=\"section\">", CategoryUrls, SectionUrls);
            //GetLinks("<ul class=\"article-list\">", SectionUrls, ArticleUrls);

            foreach (var article in ArticleUrls)
            {
                //      Request html content of url;
                //      Get content between < h1 ></ h1 >
                //      Get content between < div class="content-body article-body""></div>
                //      Save content to.html file to folder destination
            }
        }

        //public List<string> GetLinks(Regex regex, List<string> listToCrawl, List<string> listToPopulate)
        public static void GetLinks()
        {
            //foreach (var url in listToCrawl)
            //{
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(UrlPrefix + "fail2reap.compucalcalibrations.com");
                request.UserAgent = "Cached Content Crawler";
                var response = request.GetResponse();
                var stream = response.GetResponseStream();
                var reader = new StreamReader(stream);
                var htmlText = reader.ReadToEnd();
            }
            catch (WebException ex)
            {
                switch (((HttpWebResponse)ex.Response).StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        MessageBox.Show(Form.ActiveForm, @"bad request");
                        break;
                    case HttpStatusCode.NotFound:
                        MessageBox.Show(Form.ActiveForm, @"The Zendesk domain you are requesting does not exist.");
                        break;
                        //case 429:
                        //    MessageBox.Show(Form.ActiveForm, "bad request");
                        //    return;

                }
            }

            //var matchedObjects = new Regex(regex);
            //foreach (var item in matchedObjects.GetGroupNames())
            //{
            //    listToPopulate.Add(item);
            //}

            //}
            //return listToPopulate;
        }

        public static bool ValidateUrl()
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(UrlPrefix + "fail2reap.compucalcalibrations.com");
                request.UserAgent = "Cached Content Crawler";
                var response = request.GetResponse();
                var stream = response.GetResponseStream();
                var reader = new StreamReader(stream);
                var htmlText = reader.ReadToEnd();
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
                        //case 429:
                        //    MessageBox.Show(Form.ActiveForm, "bad request");
                        //    return;

                }
            }
            return true;
        }

        #endregion

    }
}
