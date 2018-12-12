using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace WindowsServiceExample
{
    [DesignerCategory("")]
    public partial class ServiceTimeLog : ServiceBase
    {
        public ServiceTimeLog()
        {
            // Do some initialization like InitializeComponent();
        }

        private Thread Thread;

        private Worker.TimeLog Worker;

        protected override void OnStart(string[] args)
        {
            this.Worker = new Worker.TimeLog();
            this.Worker.File = Common.GetBasePath() + "Time.log";
            this.Thread = new Thread(this.Worker.Work) { IsBackground = true };
            this.Thread.Start();
        }

        protected override void OnStop()
        {
            this.Worker.Stopped = true;
            this.Thread.Join();
        }
    }
}
