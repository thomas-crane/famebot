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
        private bool value;
        public Key Key
        {
            get { return key; }
        }
        public bool Value
        {
            get { return value; }
        }

        public KeyEventArgs(Key key, bool value) : base()
        {
            this.key = key;
            this.value = value;
        }
    }
}
