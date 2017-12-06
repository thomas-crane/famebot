using FameBot.Data.Enums;
using Lib_K_Relay.Networking.Packets.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FameBot.Data.Models
{
    public class LootBag
    {
        public LootBagType BagType { get; set; }
        public int ObjectId { get; set; }
        public Location Position { get; set; }
        public int[] Contents { get; set; }

        public LootBag(int objectId, Location position)
        {
            ObjectId = objectId;
            Position = position;
            Contents = new int[8] { -1, -1, -1, -1, -1, -1, -1, -1 };
        }

        public void Parse(StatData[] statData)
        {
            foreach (StatData data in statData)
            {
                if (data.Id >= 8 && data.Id <= 15)
                {
                    Contents[data.Id - 8] = data.IntValue;
                }
            }
        }

        public int this[int index]
        {
            get
            {
                return Contents[index];
            }
            set
            {
                Contents[index] = value;
            }
        }
    }
}
