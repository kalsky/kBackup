using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using kBackup.Properties;
using Image = System.Drawing.Image;

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
        /// Public enum defining availabe portal types.
        /// </summary>
        public enum PortalType
        {
            HelpCenter = 0,
            WebPortal = 1
        }

        #endregion

        #region Public Methods








        #endregion

        #region Private Methods





        #endregion

        #region Deprecated




        #endregion

        #region WIP





        #endregion
    }
}