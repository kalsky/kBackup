using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kBackup.Classes
{
    class FileSystem
    {
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

        /// <summary>
        /// Saves collection of content locally.
        /// </summary>
        /// <param name="articles">Collection of articles.</param>
        /// <param name="htmlContent">Html content of the article.</param>
        /// <returns>Returns True if article saved successfully, False if article not saved.</returns>
        private static bool SaveArticle(ZApiModel.ArticleCollection articles, StringBuilder htmlContent)
        {
            foreach (var article in articles.articles ?? articles.topics)
            {
                ////Write article heading and content into text file and save as html
                //ArticleId = article.id.ToString();
                //htmlContent.AppendLine("<h1>" + article.title + "</h1>");
                //htmlContent.AppendLine(article.body);

                //try
                //{
                //    Directory.CreateDirectory(BackupFolder);
                //    File.WriteAllText(BackupFolder + @"\" + ArticleId + ".html", htmlContent.ToString(), Encoding.UTF8);

                //    //Log the backed up resource in the backup log
                //    using (var sw = File.AppendText(BackupFolder + @"\BackupLog.txt"))
                //    {
                //        sw.WriteLine("article_" + (article.section_id.ToString() ?? ArticleId) + ": " + (article.html_url ?? "https://" + Domain + ".zendesk.com/entries/" + ArticleId));
                //    }

                //    GetImageList(htmlContent, article, article.section_id);
                //}
                //catch (UnauthorizedAccessException)
                //{
                //    //Occurs when user selects a directory from the folder browser dialog that the user does not have access to
                //    MessageBox.Show(Form.ActiveForm,
                //        @"You do not have access to the selected directory, please select Backup and try again.");
                //    return false;
                //}

                //htmlContent.Clear();
            }
            return true;
        }
    }
}
