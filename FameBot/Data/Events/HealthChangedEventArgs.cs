using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FameBot.Data.Events
{
    public class HealthChangedEventArgs : EventArgs
    {
        private float health;
        public float Health
        {
            get { return health; }
        }

        public HealthChangedEventArgs(float health) : base()
        {
            this.health = health;
        }
    }
}
