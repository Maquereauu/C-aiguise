using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_aiguisé.Source
{
    internal class MathHelper
    {
        public static int Mod(int a, int b)
        {
            int c = a % b;
            if ((c < 0 && b > 0) || (c > 0 && b < 0))
            {
                c += b;
            }
            return c;
        }
    }
}
