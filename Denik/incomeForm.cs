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
            dataRec.Note = edNote.Text;
            dataRec.Type = Record.RecordType.Income;

            Settings.Settings.addHint("IncomeNote", dataRec.NoteToNumber);
            Settings.Settings.addHint("IncomeName", dataRec.CustName);
            Settings.Settings.addHint("IncomeFor", dataRec.Content);

            return true; 
        }

        public incomeForm(Record dataRecord)
        {
            InitializeComponent();

            Result = InOutFormResult.Cancel;

            lbHeader.Text = lbHeader.Text + " " + dataRecord.TypeID.ToString();

            dataRec = dataRecord;
            cbNoteToNumber.Text = dataRec.NoteToNumber;
            edDate.Text = dataRec.Date;
            edMoney.Text = dataRec.Cost.ToString();        //todo kontrola konverze
            cbFrom.Text = dataRec.CustName;
            cbContent.Text = dataRec.Content;
            edNote.Text = dataRec.Note;

            string[] hintList;
            hintList = Settings.Settings.getHints("IncomeNote");
            foreach (string item in hintList)
                cbNoteToNumber.Items.Add(item);
            hintList = Settings.Settings.getHints("IncomeName");
            foreach (string item in hintList)
                cbFrom.Items.Add(item);
            hintList = Settings.Settings.getHints("IncomeFor");
            foreach (string item in hintList)
                cbContent.Items.Add(item);

        }

        public Record getDataRec()
        {
            return dataRec;
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            if (finishOK() != true)
                return;

            Result = InOutFormResult.OK;
            
            Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (finishOK() != true)
                return;

            Result = InOutFormResult.PrintOnce;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Result = InOutFormResult.Cancel;
            
            Close();
        }

    }


}
