using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FameBot.Data.Events
{
    public class FameUpdateEventArgs : EventArgs
    {
        private int fame;
        private int fameGoal;
        public int Fame
        {
            get { return fame; }
        }
        public int FameGoal
        {
            get { return fameGoal; }
        }

        public FameUpdateEventArgs(int fame, int fameGoal) : base()
        {
            this.fame = fame;
            this.fameGoal = fameGoal;
        }
    }
}
