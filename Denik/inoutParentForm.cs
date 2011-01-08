using System;
using System.Drawing;
using System.Xml;
using System.Windows.Forms;
using Settings;
using System.Diagnostics;

namespace Denik
{
    public class inoutParentForm : Form
    {
        public enum InOutFormResult
        {
            Cancel = 0,
            OK = 1,
            PrintOnce = 2,
            PrintTwice = 3,
        };

        public InOutFormResult Result { set; get; }

        private Record m_record;
        static private Printer m_globalFormPrinter = new Printer();

        protected Record dataRec
        {
            get { return m_record; }
            set { m_record = value; }
        }
        
        static public Printer printer
        {
            get { return m_globalFormPrinter; }
        }
    }
}