using System;
using System.Threading;
using System.Windows;

namespace SingleInstanceApp
{
    public partial class App
    {
        private static readonly Mutex _singleInstanceMutex =
            new Mutex(true, "{40D7FB99-C91E-471C-9E34-5D4A455E35E1}");

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            if (_singleInstanceMutex.WaitOne(TimeSpan.Zero, true))
            {
                Current.MainWindow = new MainWindow();
                Current.MainWindow.Show();
                Current.MainWindow.Activate();

                _singleInstanceMutex.ReleaseMutex();
            }
            else
            {
                NativeMethod.PostMessage(
                    NativeMethod.BroadcastHandle,
                    NativeMethod.ReactivationMessage,
                    IntPtr.Zero,
                    IntPtr.Zero);

                Current.Shutdown();
            }
        }
    }
}
