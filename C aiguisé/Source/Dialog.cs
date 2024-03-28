using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_aiguisé
{
    class Dialog
    {
        private string _dialog;

        public string _mDialog
        {
            get { return _dialog; }
            set { _dialog = value; }
        }
        public Dialog(string dialog)
        {
            _dialog = dialog;
        }

        public void Display((int, int) position)
        {
            Console.SetCursorPosition(position.Item1, position.Item2);
            Console.Write(_dialog);
        }
    }
}
