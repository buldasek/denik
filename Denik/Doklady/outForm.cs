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
                if (dataRec.Cost < 0 || dataRec.Cost >= MaxValue)
                    throw new Exception();
            }
            catch
            {
                MessageBox.Show("Částka musí být celé číslo menší než "+(MaxValue-1).ToString()+"."
                                , "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            dataRec.CustName = cbFrom.Text;
            dataRec.Content = cbContent.Text;
            dataRec.Note = edNote.Text;
            dataRec.Type = Record.RecordType.Expense;
            dataRec.PayedTo = cbOther.Text;

            //Settings.Settings.SettingsHolder.addHint("OutcomeNote", dataRec.NoteToNumber);
            Settings.Settings.SettingsHolder.addHint("OutcomeName", dataRec.CustName);
            Settings.Settings.SettingsHolder.addHint("OutcomeFor", dataRec.Content);
            Settings.Settings.SettingsHolder.addHint("OutcomeRecipient", dataRec.PayedTo);
            
            return true;
        }

        public outcomeForm(Record dataRecord)
        {
            InitializeComponent();

            Result = InOutFormResult.Cancel;

            dataRec = dataRecord;

            lbHeader.Text = lbHeader.Text + " " + dataRecord.TypeID.ToString();

            cbNoteToNumber.Text = dataRec.NoteToNumber;
            edDate.Text = dataRec.Date;
            edMoney.Text = dataRec.Cost.ToString();        //todo kontrola konverze
            cbFrom.Text = dataRec.CustName;
            cbContent.Text = dataRec.Content;
            edNote.Text = dataRec.Note;
            cbOther.Text = dataRec.PayedTo;

            string[] hintList;
           // hintList = Settings.Settings.SettingsHolder.getHints("OutcomeNote");
            //foreach (string item in hintList)
               // cbNoteToNumber.Items.Add(item);
            hintList = Settings.Settings.SettingsHolder.getHints("OutcomeName");
            foreach (string item in hintList)
                cbFrom.Items.Add(item);
            hintList = Settings.Settings.SettingsHolder.getHints("OutcomeFor");
            foreach (string item in hintList)
                cbContent.Items.Add(item);
            hintList = Settings.Settings.SettingsHolder.getHints("OutcomeRecipient");
            foreach (string item in hintList)
                cbOther.Items.Add(item);
            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (finishOK() != true)
                return;

            Printer printer = new Printer();
            printer.printOutcomeOne(dataRec);
            Result = InOutFormResult.PrintOnce;
            Close();
        }


        private void btnPrintTwice_Click(object sender, EventArgs e)
        {
            if (finishOK() != true)
                return;

            Printer printer = new Printer();
            printer.printOutcomeTwiceTwoPage(dataRec);
            Result = InOutFormResult.PrintTwice;
            
            Close();
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            if (finishOK() != true)
                return;

            Result = InOutFormResult.OK;
            
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Result = InOutFormResult.Cancel;
            
            Close();
        }
    }
}
