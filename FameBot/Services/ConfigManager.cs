using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FameBot.Data.Models;
using System.Xml.Serialization;
using System.Xml;

namespace FameBot.Services
{
    public static class ConfigManager
    {
        public static Configuration GetConfiguration()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Plugins", "famebot_config.xml");

            if (!File.Exists(path))
            {
                Configuration cfg = new Configuration()
                {
                    AutonexusThreshold = 0.45f,
                    TickCountThreshold = 10,
                    TeleportDistanceThreshold = 15f,
                    FollowDistanceThreshold = 1.5f,
                    AutoConnect = true,
                    FindClustersNearCenter = true,
                    Epsilon = 8f,
                    MinPoints = 5,
                    EscapeIfNoTargets = true
                };
                WriteXML(cfg);
                return cfg;
            } else
            {
                return ReadXML();
            }
        }

        public static void WriteXML(Configuration cfg)
        {
            XmlSerializer xmlS = new XmlSerializer(typeof(Configuration));
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Plugins", "famebot_config.xml");

            using (FileStream file = File.Open(path, FileMode.Create, FileAccess.Write))
            {
                xmlS.Serialize(file, cfg);
            }
        }

        public static Configuration ReadXML()
        {
            XmlSerializer xmlS = new XmlSerializer(typeof(Configuration));
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Plugins", "famebot_config.xml");

            Configuration config = new Configuration();

            using (FileStream file = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                config = (Configuration)xmlS.Deserialize(file);
            }
            return config;
        }
    }
}
