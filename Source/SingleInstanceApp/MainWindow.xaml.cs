using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace SingleInstanceApp
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            RegisterWndProcCallback();
        }

        private void RegisterWndProcCallback()
        {
            var handle = new WindowInteropHelper(this).EnsureHandle();
            var hock = new HwndSourceHook(WndProc);
            var source = HwndSource.FromHwnd(handle);

            source.AddHook(hock);
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == NativeMethod.ReactivationMessage)
                ReactivateMainWindow();

            return IntPtr.Zero;
        }

        private void ReactivateMainWindow()
        {
            if (WindowState == WindowState.Minimized)
                WindowState = WindowState.Normal;

            Topmost = !Topmost;
            Topmost = !Topmost;
        }

        private void OnAmRoLogoPreviewMouseDown(object sender, MouseButtonEventArgs e)
                => Process.Start(new ProcessStartInfo("https://github.com/AmRo045") { UseShellExecute = true });
    }
}
