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
            dataRec.NoteToNumber = edNote.Text;
            dataRec.Type = Record.RecordType.Expense;
            dataRec.PayedTo = cbOther.Text;

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
            edNote.Text = dataRec.NoteToNumber;
            cbOther.Text = dataRec.PayedTo;

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
