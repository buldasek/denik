using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//
// todo - zrusen tisk na jednu stranku obojiho, pri tisku na dve stranky zjistit jestli
// nejde zjistit aktualni stranku

namespace Denik
{
    public partial class outcomeForm : inoutParentForm
    {
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
            dataRec.Type = Record.RecordType.Expense;
            dataRec.PayedTo = cbOther.Text;

            Settings.Settings.addHint("OutcomeNote", dataRec.NoteToNumber);
            Settings.Settings.addHint("OutcomeName", dataRec.CustName);
            Settings.Settings.addHint("OutcomeFor", dataRec.Content);
            Settings.Settings.addHint("OutcomeRecipient", dataRec.PayedTo);
            
            return true;
        }

        public outcomeForm(Record dataRecord)
        {
            InitializeComponent();

            dataRec = dataRecord;

            cbNoteToNumber.Text = dataRec.NoteToNumber;
            edDate.Text = dataRec.Date;
            edMoney.Text = dataRec.Cost.ToString();        //todo kontrola konverze
            cbFrom.Text = dataRec.CustName;
            cbContent.Text = dataRec.Content;
            edNote.Text = dataRec.Note;
            cbOther.Text = dataRec.PayedTo;

            string[] hintList;
            hintList = Settings.Settings.getHints("OutcomeNote");
            foreach (string item in hintList)
                cbNoteToNumber.Items.Add(item);
            hintList = Settings.Settings.getHints("OutcomeName");
            foreach (string item in hintList)
                cbFrom.Items.Add(item);
            hintList = Settings.Settings.getHints("OutcomeFor");
            foreach (string item in hintList)
                cbContent.Items.Add(item);
            hintList = Settings.Settings.getHints("OutcomeRecipient");
            foreach (string item in hintList)
                cbOther.Items.Add(item);
            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (finishOK() != true)
                return;
            Printer printer = new Printer();
            printer.printOutcomeOne(dataRec);

            DialogResult = DialogResult.OK;
            Close();
        }


        private void btnPrintTwice_Click(object sender, EventArgs e)
        {
            if (finishOK() != true)
                return;
            Printer printer = new Printer();
            printer.printOutcomeTwiceTwoPage(dataRec);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            if (finishOK() != true)
                return;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Close();
        }
    }
}
