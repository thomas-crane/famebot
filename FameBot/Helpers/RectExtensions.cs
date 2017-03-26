using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using FameBot.Data.Models;

namespace FameBot.Helpers
{
    public static class RectExtensions
    {
        public static Size GetSize(this RECT rect)
        {
            return new Size(rect.Right - rect.Left, rect.Bottom - rect.Top);
        }
    }
}
