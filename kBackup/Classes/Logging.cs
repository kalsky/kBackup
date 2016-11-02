//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// C# File
// Name:        Logging.cs
// Created:     19-Sep-16
// Orig Author: fstubner
// Last Author: fstubner
// AUTHOR       DATE        BUG/FEATURE       DESCRIPTION
// 
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using kBackup.Properties;

namespace RenewalManager.Classes
{
    internal class Logging
    {
        #region Enums

        /// <summary>
        /// Contains the entry types used for logging.
        /// </summary>
        public enum LogEntry
        {
            Error,
            Info
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a log file at the location specified.
        /// </summary>
        public void CreateLogFile()
        {
            //if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\Logs")) Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Logs");
            //Settings.Default.logFilePath = Directory.GetCurrentDirectory() + "\\Logs\\LogFile.txt";
            //Settings.Default.Save();
            //LogTrace("CreateLogFile", "Log File Created.");
        }

        /// <summary>
        ///     Reads a file at the specified location and returns it's contents as a list of strings.
        /// </summary>
        /// <param name="filePath">The path of the file to read the contents of.</param>
        /// <returns>A list object which contains the contents of the file.</returns>
        public List<string> GetResultLines(string filePath)
        {
            var returnedResults = new List<string>();
            if (!File.Exists(filePath)) return returnedResults;
            var lineLIst = new List<string>();
            using (var streamRead = new StreamReader(filePath))
            {
                string line;
                while ((line = streamRead.ReadLine()) != null)
                {
                    lineLIst.Add(line);
                }
            }
            return lineLIst;
        }

        /// <summary>
        ///     Reads a file at the specified location and returns it's contents as a StringBuilder object.
        /// </summary>
        /// <param name="filePath">The path of the file to read the contents of.</param>
        /// <returns>A Stringbuilder object which contains the contents of the file.</returns>
        public StringBuilder GetResultText(string filePath)
        {
            var returnedResults = new StringBuilder();
            if (!File.Exists(filePath)) return returnedResults;
            var streamRead = new StreamReader(filePath);
            var returnedString = streamRead.ReadToEnd();
            returnedResults.Append(returnedString);
            return returnedResults;
        }

        /// <summary>
        ///     Appends the results passed in, to the log file.
        /// </summary>
        /// <param name="results">The results to add to the log file.</param>
        public void LogResult(StringBuilder results)
        {
            WriteToLog(results, LogEntry.Info, false);
        }

        /// <summary>
        ///     Logs a trace message to the log file.
        /// </summary>
        /// <param name="methodCalled">The method that was called.</param>
        /// <param name="actionText">The action the method is carrying out.</param>
        /// <remarks></remarks>
        public void LogTrace(string methodCalled, string actionText)
        {
            WriteToLog(methodCalled, actionText, string.Empty, LogEntry.Info, false);
        }

        /// <summary>
        ///     Logs an exception message to the log file.
        /// </summary>
        /// <param name="methodCalled">The method that was called.</param>
        /// <param name="actionText">The action the method is carrying out.</param>
        /// <param name="exceptionText">The exception message.</param>
        /// <remarks></remarks>
        public void LogException(string methodCalled, string actionText, string exceptionText)
        {
            WriteToLog(methodCalled, actionText, exceptionText, LogEntry.Error, false);
        }

        #endregion

        #region Private Methods

        /// <summary>
        ///     This Sub will log text in the following format: dd-MM-yyyy HH:mm:ss - Results into a text file.
        /// </summary>
        /// <param name="results">The results of the method.</param>
        /// <param name="entryType">Type of entry.</param>
        /// <param name="lastChance">Flag to retry current action if exception is thrown.</param>
        private void WriteToLog(StringBuilder results, LogEntry entryType, bool lastChance)
        {
            try
            {
                //if (Settings.Default.logFilePath == string.Empty)
                //{
                //    CreateLogFile();
                //}

                //// this sub will record all actions taken in a log file.
                //using (var logWriter = File.AppendText(Settings.Default.logFilePath))
                //{
                //    logWriter.WriteLine(DateTime.Now.ToString("[" + Settings.Default.dateTimeFormat + "]") + "[" + entryType.ToString().ToUpper() + "]" + " - " + results);
                //}
            }
            catch (Exception ex)
            {
                if (!lastChance)
                {
                    WriteToLog(results, entryType, true);
                }
                else
                {
                    var mailer = new Mailer();
                    mailer.ExceptionNotification("WriteToLog", ex.Message + ": " + ex.StackTrace);
                }
            }
        }

        /// <summary>
        ///     This Sub will log text in the following format: dd-MM-yyyy HH:mm:ss - ActionText ExceptionText
        ///     E.g. 19-05-2015 16:53:11 - SQL Server Instance 'SQLEXPRESS' was selected.
        ///     into a text file.
        /// </summary>
        /// <param name="methodCalled">The method that was called.</param>
        /// <param name="actionText">This parameter is used to define the action message.</param>
        /// <param name="exceptionText">This parameter is used to define any exception messages.</param>
        /// <param name="entryType">Type of entry.</param>
        /// <param name="lastChance">Flag to retry current action if exception is thrown.</param>
        private void WriteToLog(string methodCalled, string actionText, string exceptionText, LogEntry entryType, bool lastChance)
        {
            try
            {
                //if (Settings.Default.logFilePath == string.Empty)
                //{
                //    CreateLogFile();
                //}

                // this sub will record all actions taken in a log file.
                //using (var logWriter = File.AppendText(Settings.Default.logFilePath))
                //{
                //    logWriter.WriteLine(DateTime.Now.ToString("[" + Settings.Default.dateTimeFormat + "]") + "[" + entryType.ToString().ToUpper() + "]" + " - " + methodCalled + ": " + actionText + exceptionText);
                //}
            }
            catch (Exception ex)
            {
                if (!lastChance)
                {
                    WriteToLog(methodCalled, actionText, exceptionText, entryType, true);
                }
                else
                {
                    var mailer = new Mailer();
                    mailer.ExceptionNotification("WriteToLog", ex.Message + ": " + ex.StackTrace);
                }
            }
        }

        #endregion
    }
}