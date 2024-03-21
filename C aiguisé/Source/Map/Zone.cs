using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_aiguisé
{
    public class Zone
    {
        private string _sprit;

        public Zone (string sprit)
        {
            _sprit = sprit;
        }

        public void Display()
        {
            string asciiArt = File.ReadAllText(_sprit);
            Console.WriteLine(asciiArt);
        }

    }
}