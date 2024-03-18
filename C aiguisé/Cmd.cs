using System;
using System.Runtime.InteropServices;
using System.Text;

namespace C_aiguisé
{
    public static class Cmd
    {
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        const int SW_MAXIMIZE = 3;

        public static void test()
        {
            IntPtr handle = GetConsoleWindow();
            ShowWindow(handle, SW_MAXIMIZE);

            Console.OutputEncoding = Encoding.UTF8;
            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.Clear();

            string asciiArt = File.ReadAllText("../../../nahidwin.txt");
            Console.WriteLine(asciiArt);
            asciiArt = File.ReadAllText("../../../nahidwin2.txt");
/*            Console.WriteLine(asciiArt);*/
            Console.Read();
        }
    }
}
