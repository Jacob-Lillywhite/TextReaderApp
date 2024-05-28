using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TextReader.Input;
using TextReader.Windows;

namespace TextReader
{
    internal static class NativeMethods
    {
        // Import the necessary functions from user32.dll for creating a global hotkey.
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool RegisterHotKey(IntPtr hWnd, int id, KeyModifiers fsModifiers, Keys vk);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, PreserveSig = false)]
        internal static extern void DwmSetWindowAttribute(IntPtr hwnd,
                                                DWMWINDOWATTRIBUTE attribute,
                                                ref int pvAttribute,
                                                uint cbAttribute);
    }
}
