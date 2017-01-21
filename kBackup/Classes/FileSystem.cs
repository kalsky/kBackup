using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using kBackup.Properties;
using Newtonsoft.Json;
using Quartz.Util;

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

        public static void SaveSettings()
        {

        }

        public static void LoadSettings()
        {

        }

        public void LoadData()
        {

        }

        private void ReadUserData()
        {
            // Read existing json data
            var jsonData = File.ReadAllText(Settings.Default.dataFolder + "\\user\\profile.json");

            // De-serialize to object or create new list
            var employeeList = JsonConvert.DeserializeObject<List<ZApiModel.UserCollection>>(jsonData) ?? new List<ZApiModel.UserCollection>();

            //add to list here
            if (employeeList.Count <= 0)
            {
                //add entry here
            }
            
            // Update json data string
            jsonData = JsonConvert.SerializeObject(employeeList);
            File.WriteAllText(Settings.Default.dataFolder + "\\user\\profile.json", jsonData);
        }

        public async Task<ZApiModel.CategoryCollection> ReadCategoryData()
        {

            string jsonData;
            using (var reader = File.OpenText(Settings.Default.dataFolder + "\\kBackup\\data\\json\\categories.json"))
            {
                jsonData = await reader.ReadToEndAsync();
                // Do something with fileText...
            }

            // De-serialize to object or create new list
            var categories = JsonConvert.DeserializeObject<ZApiModel.CategoryCollection>(jsonData); //?? new List<ZApiModel.CategoryCollection>();

            ////add to list here
            //if (categories.Count <= 0)
            //{
            //    //add entry here
            //}

            return categories;

            //// Update json data string
            //jsonData = JsonConvert.SerializeObject(categories);
            //File.WriteAllText(Settings.Default.dataFolder + "\\user\\profile.json", jsonData);
        }

        private void ReadSectionData()
        {
        }

        private void ReadArticleData()
        {
        }

        private void ReadArticleCommentData()
        {
        }

        private void ReadTopicData()
        {
        }

        private void ReadPostData()
        {
        }

        private void ReadPostCommentData()
        {
        }

        /// <summary>
        ///     Decrypts a string based on a supplied password using AES Decryption.
        /// </summary>
        /// <param name="input">The input string to be decrypted.</param>
        /// <param name="password">The password to decrypt the input string with.</param>
        /// <returns>Returns the decrypted value.</returns>
        /// <remarks>Used for decryption of Registry path in web.config file.</remarks>
        public string AES_Decrypt(string input, string password)
        {

            RijndaelManaged aes = new RijndaelManaged();
            string decrypted = string.Empty;
            try
            {
                byte[] hash = new byte[32];
                // Gets the hash value of byte array of the string Password
                byte[] temp = new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(password));
                Array.Copy(temp, 0, hash, 0, 16);
                Array.Copy(temp, 0, hash, 15, 16);
                // Sets the encryption key
                aes.Key = hash;
                aes.Mode = CipherMode.ECB;
                ICryptoTransform desDecrypter = aes.CreateDecryptor();
                byte[] buffer = Convert.FromBase64String(input);
                // Decrypts the string
                decrypted = Encoding.ASCII.GetString(desDecrypter.TransformFinalBlock(buffer, 0, buffer.Length));
                // Return decrypted string
                return decrypted;
            }
            catch (Exception e)
            {

            }
            return string.Empty;
        }

        /// <summary>
        ///     Encrypts a string based on a supplied password using AES Encryption.
        /// </summary>
        /// <param name="input">The input string to be encrypted.</param>
        /// <param name="password">The password to encrypt the input string with.</param>
        /// <returns>Returns the encrypted value.</returns>
        /// <remarks>Used for encryption of Registry path in web.config file.</remarks>
        public string AES_Encrypt(string input, string password)
        {
            RijndaelManaged aesEncryption = new RijndaelManaged();
            MD5CryptoServiceProvider md5HashCryptoSp = new MD5CryptoServiceProvider();
            string encrypted = string.Empty;
            try
            {
                byte[] hash = new byte[32];
                // Gets the hash value of byte array of the string Password
                byte[] temp = md5HashCryptoSp.ComputeHash(Encoding.ASCII.GetBytes(password));
                Array.Copy(temp, 0, hash, 0, 16);
                Array.Copy(temp, 0, hash, 15, 16);
                // Sets the encryption keyw
                aesEncryption.Key = hash;
                aesEncryption.Mode = CipherMode.ECB;
                // Encrypts the string
                ICryptoTransform desEncrypter = aesEncryption.CreateEncryptor();
                // Gets bytes from input string
                byte[] buffer = Encoding.ASCII.GetBytes(input);
                // Encrypt the input string
                encrypted = Convert.ToBase64String(desEncrypter.TransformFinalBlock(buffer, 0, buffer.Length));
                // Return encrypted string
                return encrypted;
            }
            catch (Exception e)
            {

            }
            return string.Empty;
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
