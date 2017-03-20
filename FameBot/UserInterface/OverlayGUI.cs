using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FameBot.UserInterface
{
    public partial class OverlayGUI : Form
    {
        public enum GWL
        {
            ExStyle = -20
        }

        public const int GWL_EXSTYLE = -20;

        public const int WS_EX_LAYERED = 0x80000;

        public const int WS_EX_TRANSPARENT = 0x20;

        public const int LWA_ALPHA = 0x2;

        public const int LWA_COLORKEY = 0x1;

        private readonly Thread DrawingThread;

        private RECT rect;

        public OverlayGUI(IntPtr flashPtr) {
            InitializeComponent();
            GetWindowRect(flashPtr, ref rect);

            Location = new Point(rect.Left, rect.Top);
            Size = new Size(rect.Right - rect.Left, rect.Bottom - rect.Top);
            BackColor = Color.LimeGreen;
            TransparencyKey = Color.LimeGreen;
            FormBorderStyle = FormBorderStyle.None;
            DrawingThread = new Thread(Draw) {IsBackground = true};
            DrawingThread.Start();
        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        protected override void OnShown(EventArgs e) //Click-through-able
        {
            base.OnShown(e);
            int wl = (int) GetWindowLong(Handle, (int) GWL.ExStyle);
            wl = wl | 0x80000 | 0x20;
            SetWindowLong(Handle, (int) GWL.ExStyle, wl);
            //    SetLayeredWindowAttributes(Handle, 0, 255, LWA.Alpha);
        }

        public void Draw() {
            while (true)
            {
                Bitmap buffer = new Bitmap(Width, Height);
                Task.Factory.StartNew(() =>
                {
                    using (Graphics g = Graphics.FromImage(buffer))
                        g.DrawString("Drawing Stuff is cool", new Font(FontFamily.GenericSansSerif, 10.0f), new SolidBrush(Color.White), 25, rect.Bottom - 25);
                    Invoke(new Action(() => { BackgroundImage = buffer; }));
                });
                Thread.Sleep(100); //This isn't really an ESP so there's no need to draw every 10 ms or so.
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public readonly int Left;
            public readonly int Top;
            public readonly int Right;
            public readonly int Bottom;
        }
    }
}