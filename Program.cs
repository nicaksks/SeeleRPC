using SeeleRichPresence.Discord;
using System.Runtime.InteropServices;

namespace Seele
{
    class Program
    {
        readonly static IntPtr handle = GetConsoleWindow();
        [DllImport("kernel32.dll")] static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")] static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        static void Main()
        {
            ShowWindow(handle, 0);
            SeeleRPC.Start();
        }
    }
}
