using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace WindowsServiceExample.Worker
{
    public class TimeLog
    {
        public TimeLog()
        {
            _Delay = 10000;
            _Stopped = false;
            _ResetEvent = new ManualResetEvent(false);
        }

        private ManualResetEvent _ResetEvent;

        private readonly object _ThreadLock = new object();

        private bool _Stopped;

        public bool Stopped
        {
            get
            {
                lock (_ThreadLock)
                {
                    return _Stopped;
                }
            }
            set
            {
                lock (_ThreadLock)
                {
                    _Stopped = value;
                    _ResetEvent.Set();
                }
            }
        }

        private int _Delay;

        public int Delay
        {
            get
            {
                lock (_ThreadLock)
                {
                    return _Delay;
                }
            }
            set
            {
                lock (_ThreadLock)
                {
                    _Delay = value;
                }
            }
        }

        private string _File;

        public string File
        {
            get
            {
                lock (_ThreadLock)
                {
                    return _File;
                }
            }
            set
            {
                lock (_ThreadLock)
                {
                    _File = value;
                }
            }
        }

        public void Work()
        {
            while (!Stopped)
            {
                string file = File;
                string content = DateTime.Now.ToString("HH:mm:ss.fff") + Environment.NewLine;
                try
                {
                    System.IO.File.AppendAllText(file, content);
                }
                catch
                { }

                if (_ResetEvent.WaitOne(Delay))
                    break;
            }
        }
    }
}
