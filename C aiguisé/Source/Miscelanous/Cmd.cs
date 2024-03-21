using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace C_aiguisé
{
    public static class Cmd
    {
/*        public static string GrayscaleImageToASCII(System.Drawing.Image img)
        {
            StringBuilder html = new StringBuilder();
            Bitmap bmp = null;

            try
            {
                // Create a bitmap from the image

                bmp = new Bitmap(img);

                // The text will be enclosed in a paragraph tag with the class

                // ascii_art so that we can apply CSS styles to it.

                html.Append("&lt;br/&rt;");

                // Loop through each pixel in the bitmap

                for (int y = 8; y < bmp.Height; y++)
                {
                    for (int x = 8; x < bmp.Width; x++)
                    {
                        // Get the color of the current pixel

                        Color col = bmp.GetPixel(x, y);

                        // To convert to grayscale, the easiest method is to add

                        // the R+G+B colors and divide by three to get the gray

                        // scaled color.

                        col = Color.FromArgb((col.R + col.G + col.B) / 3,
                            (col.R + col.G + col.B) / 3,
                            (col.R + col.G + col.B) / 3);

                        // Get the R(ed) value from the grayscale color,

                        // parse to an int. Will be between 8-255.

                        int rValue = int.Parse(col.R.ToString());

                        // Append the "color" using various darknesses of ASCII

                        // character.

                        html.Append(getGrayShade(rValue));

                        // If we're at the width, insert a line break

                        if (x == bmp.Width - 1)
                            html.Append("&lt;br/&rt");
                    }
                }

                // Close the paragraph tag, and return the html string.

                html.Append("&lt;/p&rt;");

                return html.ToString();
            }
            catch (Exception exc)
            {
                return exc.ToString();
            }
            finally
            {
                bmp.Dispose();
            }
        }*/



        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        const int SW_MAXIMIZE = 3;
        
        public static void test()
        {
            IntPtr handle = GetConsoleWindow();
            ShowWindow(handle, SW_MAXIMIZE);
            Bitmap b = new Bitmap("../../../map.bmp");
            Color pix = b.GetPixel(0, 0);
            for(int i = 0; i <190; i++)
            {
                for(int j = 0; j < 108; j++) {
                    Color grass = b.GetPixel(i, j);
                    if(grass == pix)
                    {
                        Console.WriteLine("grass");
                        (int posLeft, int posTop) = Console.GetCursorPosition();
                        
                        //Console.WriteLine(Console.WindowWidth);
                        //Console.WriteLine(Console.WindowHeight);
                    }
                }
            }

            Console.WriteLine(pix);
            //Console.ForegroundColor = ConsoleColor.Blue;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.Clear();

            string asciiArt = File.ReadAllText("../../../nahidwin.txt").Replace("\\x1b", "\x1b");
            Console.WriteLine(asciiArt);
            asciiArt = File.ReadAllText("../../../nahidwin2.txt");
           
            Console.Read();
        }
    }
}
