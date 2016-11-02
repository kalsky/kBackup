//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// C# File
// Name:        Mailer.cs
// Created:     19-Sep-16
// Orig Author: fstubner
// Last Author: fstubner
// AUTHOR       DATE        BUG/FEATURE       DESCRIPTION
// 
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
using kBackup.Properties;

namespace RenewalManager.Classes
{
    internal class Mailer
    {
        private readonly Logging _logging = new Logging();

        #region Properties

        public readonly StringCollection SelectedSupportTemplates = new StringCollection();
        public readonly StringCollection SelectedLicenseTemplates = new StringCollection();

        #endregion

        #region Public Methods

        /// <summary>
        /// Sends email with provided details.
        /// </summary>
        /// <param name="mailReceiver">Recipient email</param>
        /// <param name="mailSubject">Email subject</param>
        /// <param name="mailBody">Email body</param>
        /// <param name="lastChance">Indicates whether it should retry sending the email</param>
        /// <param name="isException">Specifies whether an exception email is being sent or not.</param>
        public void Send(string mailReceiver, string mailSubject, StringBuilder mailBody, bool lastChance, bool isException)
        {
            try
            {
                //var firstTime = true;
                //var recipients = mailReceiver.Split(Convert.ToChar(";"));
                //foreach (var emailAddress in recipients)
                //{
                //    if (emailAddress.Trim() == string.Empty) continue;
                //    var message = new MailMessage { From = new MailAddress(Settings.Default.mailSenderEmail) };
                //    message.To.Add(emailAddress.Trim());
                //    message.Subject = mailSubject;
                //    message.Body = mailBody.ToString();
                //    message.ReplyToList.Add(new MailAddress(Settings.Default.mailSenderEmail));

                //    if (Settings.Default.enableHtmlInEmails)
                //    {
                //        message.IsBodyHtml = true;
                //    }

                //    if (firstTime)
                //    {
                //        if (!isException)
                //        {
                //            foreach (var email in Settings.Default.renewalCCEmail.Split(Convert.ToChar(";")))
                //            {
                //                if (email.Trim() != string.Empty)
                //                {
                //                    message.Bcc.Add(email.Trim());
                //                }
                //            }
                //        }
                //    }
                    
                //    message.Priority = MailPriority.High;
                //    var mySmtpClient = new SmtpClient(Settings.Default.mailServer, Settings.Default.mailServerPort)
                //    {
                //        Credentials = new NetworkCredential(Settings.Default.mailSenderEmail, Settings.Default.mailSenderPassword)
                //    };
                //    mySmtpClient.Send(message);
                //    firstTime = false;
                //}
            }
            catch (SmtpFailedRecipientsException e)
            {
                ExceptionNotification("Send", e.Message + ": " + e.StackTrace);
                _logging.LogException("Send", string.Empty, e.Message + ": " + e.StackTrace);
            }
            catch (SmtpException ex)
            {
                _logging.LogException("Send", string.Empty, ex.Message + ": " + ex.StackTrace);
            }
            catch (Exception exc)
            {
                _logging.LogException("Send", "Sending email failed.", exc.Message + ": " + exc.StackTrace);
                if (!lastChance)
                {
                    Send(mailReceiver, mailSubject, mailBody, true, false);
                    _logging.LogException("Send", "Attempting to resend message.", exc.Message + ": " + exc.StackTrace);
                }
                else
                {
                    _logging.LogException("Send", "Sending email failed after retry.", exc.Message + ": " + exc.StackTrace);
                }
            }
        }

        /// <summary>
        /// Loads the text from template.
        /// </summary>
        public StringBuilder LoadHtmlTemplate(string customerName, int daysTillRenewal, string applicationUrl,
                                              string licenseExpiryDate, string template)
        {
            var templateDir = Directory.GetCurrentDirectory() + @"\Templates\";
            if (!File.Exists(templateDir + template))
            {
                return null;
            }
            var sr = new StreamReader(templateDir + template);
            var sb = new StringBuilder();
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                sb.AppendLine(line);
            }

            sb = sb.Replace("�", "'");
            sb = sb.Replace("[CUSTOMERNAME]", customerName);
            sb = sb.Replace("[DAYSTILLRENEWAL]", daysTillRenewal.ToString());
            sb = sb.Replace("[APPLICATIONURL]", applicationUrl);
            sb = sb.Replace("[LICENSEEXPIRYDATE]", licenseExpiryDate);

            return sb;
        }

        /// <summary>
        /// Used to notify compucal of support 
        /// </summary>
        public void ExceptionNotification(string methodName, string exceptionText)
        {
            var localIp = string.Empty;
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIp = ip.ToString();
                }
            }

            var sb = new StringBuilder();
            sb.AppendLine("The method " + methodName + " threw the following exeption: " + exceptionText);
            //Send(Settings.Default.exceptionContact, @"RenewalManager - An Exeption occurred on machine " +
            //     Environment.MachineName + " with IP " + localIp, sb, false, true);
        }

        #endregion
    }
}