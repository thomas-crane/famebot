﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib_K_Relay.Networking.Packets.DataObjects;

namespace FameBot.Data.Models
{
    public class Rock
    {
        public int ObjectId { get; set; }
        public Location Location { get; set; }

        public Rock(int objectId, Location location)
        {
            ObjectId = objectId;
            Location = location;
        }
    }
}
