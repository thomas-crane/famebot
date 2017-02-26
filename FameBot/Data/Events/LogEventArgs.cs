using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FameBot.Data.Events
{
    public class LogEventArgs : EventArgs
    {
        private string message;
        private DateTime timestamp;

        public string Message
        {
            get { return message; }
        }
        public DateTime Timestamp
        {
            get { return timestamp; }
        }
        public string TimestampString
        {
            get { return ("[" + timestamp.ToString("HH:mm:ss") + "]"); }
        }

        public string MessageWithTimestamp
        {
            get { return (TimestampString + " " + message); }
        }

        public LogEventArgs(string message)
        {
            this.message = message;
            timestamp = DateTime.Now;
        }
    }
}
