using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_aiguisé
{
    static class DialogManager
    {
        private static List<Dialog> _dialog = new List<Dialog>();
        private static Dialog _currentDialog = new Dialog("");

        public static List<Dialog> _mDialog
        {
            get { return _dialog; }
            set { _dialog = value; }
        }

        public static Dialog _mCurrentDialog
        {
            get { return _currentDialog; }
            set { _currentDialog = value; }
        }

        public static void Display((int, int) position)
        {
            _currentDialog.Display(position);
        }

        public static void SetDialog()
        {

        }
        
        public static void AddDialog(Dialog dialog)
        {
            _dialog.Add(dialog);
        }
        public static void AddDialog(List<Dialog> dialog)
        {
            for (int i = 0; i < dialog.Count; i++)
            {
                _dialog.Add(dialog[i]);
            }
        }
    }
}
