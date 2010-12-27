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