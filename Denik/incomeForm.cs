using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Denik
{
    public partial class incomeForm : inoutParentForm
    {
       // private Record m_record;

        private bool finishOK()
        {
            //todo pridat do seznamu
            dataRec.NoteToNumber = cbNoteToNumber.Text;
            dataRec.Date = edDate.Text;
            try
            {
                dataRec.Cost = Int64.Parse(edMoney.Text);        //todo kontrola konverze
                if (dataRec.Cost < 0)
                    throw new Exception();
            }
            catch
            {
                MessageBox.Show("Nesprávná částka.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return false;
            }
            dataRec.CustName = cbFrom.Text;
            dataRec.Content = cbContent.Text;
            dataRec.NoteToNumber = edNote.Text;
            dataRec.Type = Record.RecordType.Income;
            

            return true; 
        }

        public incomeForm(Record dataRecord)
        {
            InitializeComponent();

            dataRec = dataRecord;
            cbNoteToNumber.Text = dataRec.NoteToNumber;
            edDate.Text = dataRec.Date;
            edMoney.Text = dataRec.Cost.ToString();        //todo kontrola konverze
            cbFrom.Text = dataRec.CustName;
            cbContent.Text = dataRec.Content;
            edNote.Text = dataRec.Note;
            //cbOther.Text = dataRec.PayedTo;

        }

        public Record getDataRec()
        {
            return dataRec;
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            if (finishOK() != true)
                return;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (finishOK() != true)
                return;

            Printer printer = new Printer();
            printer.print(dataRec);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Close();
        }

    }

    public class inoutParentForm : Form
    {
        private Record m_record;

        protected Record dataRec
        {
            get { return m_record; }
            set { m_record = value; }
        }
        
    }
}
