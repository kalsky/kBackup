//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// C# File
// Name:        Scheduler.cs
// Created:     19-Sep-16
// Orig Author: fstubner
// Last Author: fstubner
// AUTHOR       DATE        BUG/FEATURE       DESCRIPTION
// 
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Windows.Forms;
using kBackup.Classes;
using kBackup.Forms;
using kBackup.Properties;
using Quartz;
using Quartz.Impl;

namespace RenewalManager.Classes
{
    /// <summary>
    /// Implementation of the ITriggerListener interface.
    /// </summary>
    internal class TriggerListener : ITriggerListener
    {
        //private static readonly Form MainForm = Settings.Default.mainForm;
        public string Name => "TriggerListener";

        public void TriggerFired(ITrigger trigger, IJobExecutionContext context)
        {
        }

        public bool VetoJobExecution(ITrigger trigger, IJobExecutionContext context)
        {
            return false;
        }

        public void TriggerComplete(ITrigger trigger, IJobExecutionContext context, SchedulerInstruction triggerInstructionCode)
        {
            //var form = (Main)MainForm;
            //if (trigger.Key.ToString() != "IDG.IdgJob") return;
            //RunOnUiThread(form.LoadGridView);
            //RunOnUiThread(form.LoadLogFile);
        }

        public void TriggerMisfired(ITrigger trigger)
        {
        }

        public static void RunOnUiThread(Action action)
        {
            //var form = (Main) MainForm;
            //if (form.InvokeRequired)
            //{
            //    form.Invoke(action);
            //}
            //else
            //{
            //    action();
            //}
        }
    }

    /// <summary>
    /// Implementation of the IJob interface.
    /// </summary>
    public class IdgJob : IJob
    {
        //private readonly ZendeskApi _zdapi = new ZendeskApi();

        /// <summary>
        /// Executes function for the daily check for expired licenses.
        /// </summary>
        public void Execute(IJobExecutionContext context)
        {
            //_zdapi.GetOrgs(false, false);
        }
    }

    /// <summary>
    /// Handles the scheduling of the daily check for expired licenses.
    /// </summary>
    public class JobScheduler
    {
        private static IScheduler _scheduler;

        /// <summary>
        /// Schedules the job.
        /// </summary>
        public static void Start()
        {
            _scheduler = StdSchedulerFactory.GetDefaultScheduler();
            _scheduler.Start();

            var job = JobBuilder.Create<IdgJob>().Build();
            var scheduleTrigger = TriggerBuilder.Create().
                WithIdentity("IdgJob", "IDG").
                //WithCronSchedule("0 " + Settings.Default.intervalMins + " " + Settings.Default.intervalHours + " 1/" + Settings.Default.intervalDays + " * ? *").
                StartAt(DateTime.UtcNow).
                WithPriority(1).
                Build(); // every minute = "0 0/1 * 1/1 * ? *" DateTime.UtcNow  every day at midnight = "0 0 0 1/1 * ? *" DateTime.Today.AddDays(1) 
            //"0 0 0 1/1 * ? *"
            //"0 " + Settings.Default.intervalMins + " " + Settings.Default.intervalHours + " 1/" + Settings.Default.intervalDays + " * ? *"
            _scheduler.ScheduleJob(job, scheduleTrigger);
            _scheduler.ListenerManager.AddTriggerListener(new TriggerListener());
        }

        /// <summary>
        /// Stops the scheduled job.
        /// </summary>
        public static void Stop()
        {
            _scheduler?.Shutdown();
        }
    }
}