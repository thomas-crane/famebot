using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FameBot.Data.Enums;

namespace FameBot.Data.Events
{
    public class KeyEventArgs : EventArgs
    {
        private Key key;
        public Key Key
        {
            get { return key; }
        }

        public KeyEventArgs(Key key) : base()
        {
            this.key = key;
        }
    }
}
