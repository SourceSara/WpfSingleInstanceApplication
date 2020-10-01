using System;
using System.Runtime.InteropServices;

namespace SingleInstanceApp
{
    public static class NativeMethod
    {
        public static IntPtr BroadcastHandle => (IntPtr)0xffff;
        public static int ReactivationMessage => RegisterWindowMessage("WM_SHOWME");

        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);
    }
}