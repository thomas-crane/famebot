using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace FameBot.UserInterface
{
    public partial class OverlayGUI : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        public OverlayGUI(IntPtr flashPtr)
        {
            InitializeComponent();

            RECT rect = new RECT();
            GetWindowRect(flashPtr, ref rect);

            this.Location = new Point(rect.Left, rect.Top);
            this.Size = new Size(rect.Right - rect.Left, rect.Bottom - rect.Top);
            this.BackColor = Color.LimeGreen;
            //this.TransparencyKey = Color.LimeGreen;
            this.FormBorderStyle = FormBorderStyle.None;
        }
    }
}
