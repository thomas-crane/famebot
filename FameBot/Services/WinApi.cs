using System;
using FameBot.Data.Models;
using System.Runtime.InteropServices;

namespace FameBot.Services
{
    public static class WinApi
    {
        // Get the focused window.
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetForegroundWindow();
        // Send a message to a specific process via the handle.
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        // Gets the positions of the corners of a window via the MainWindowHandle.
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);
        // Converts a point in screen space to a point relative to hWnd's window.
        [DllImport("user32.dll")]
        public static extern bool ScreenToClient(IntPtr hWnd, ref POINT lpPoint);
    }
}
