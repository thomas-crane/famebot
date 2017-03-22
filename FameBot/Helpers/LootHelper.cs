﻿namespace FameBot.Helpers
{
    internal class LootHelper
    {
        public static string BagTypeToString(short ObjectType) {
            switch (ObjectType)
            {
                case 1280:
                    return "Normal";
                case 1283:
                case 1287:
                    return "Purple";
                case 1286:
                    return "Pink";
                case 1288:
                    return "Egg";
                case 1289:
                    return "Cyan";
                case 1291:
                    return "Blue";
                case 1292:
                case 1294:
                case 1295:
                    return "White";
                case 1296:
                    return "Red";
            }
            return null;
        }
    }
}