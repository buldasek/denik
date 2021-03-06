﻿using System;
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
        MainForm m_parentMain;
       // private Record m_record;
        private Denik.Record createDataRec(Denik.Record initRecord) {
                        //todo pridat do seznamu
            Denik.Record result = initRecord;
          
            try
            {
                result.Cost = MoneyConvertor.StrToMoney(edMoney.Text, MaxValue-1);        //todo kontrola konverze
                if (result.Cost < 0 || result.Cost >= MaxValue)
                    throw new Exception();
            }
            catch
            {
                MessageBox.Show("Částka musí být celé číslo menší než "+(MaxValue-1).ToString()+".", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            result.NoteToNumber = cbNoteToNumber.Text;
            result.Date = edDate.Text;
            result.CustName = cbFrom.Text;
            result.Content = cbContent.Text;
            result.Note = edNote.Text;
            result.Type = Record.RecordType.Income;
            return result;
        }


        private bool finishOK()
        {
            Denik.Record record = createDataRec(dataRec);
            if (record == null)
            {
                return false;
            }
            dataRec = record;

            //Settings.Settings.SettingsHolder.addHint("IncomeNote", dataRec.NoteToNumber);
            Settings.Settings.SettingsHolder.addHint("IncomeName", dataRec.CustName);
            Settings.Settings.SettingsHolder.addHint("IncomeFor", dataRec.Content);

            return true; 
        }

        public incomeForm(Record dataRecord, MainForm parentMain)
        {
            InitializeComponent();
            m_parentMain = parentMain;

            Result = InOutFormResult.Cancel;

            lbHeader.Text = lbHeader.Text + " " + dataRecord.OverallID.ToString();

            dataRec = dataRecord;
            cbNoteToNumber.Text = dataRec.NoteToNumber;
            edDate.Text = dataRec.Date;
            edMoney.Text = MoneyConvertor.MoneyToStr(dataRec.Cost);        //todo kontrola konverze
            cbFrom.Text = dataRec.CustName;
            cbContent.Text = dataRec.Content;
            edNote.Text = dataRec.Note;

            string[] hintList;
            /*hintList = Settings.Settings.SettingsHolder.getHints("IncomeNote");
            foreach (string item in hintList)
                cbNoteToNumber.Items.Add(item);*/
            hintList = Settings.Settings.SettingsHolder.getHints("IncomeName");
            foreach (string item in hintList)
                cbFrom.Items.Add(item);
            hintList = Settings.Settings.SettingsHolder.getHints("IncomeFor");
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

            Printer printer = new Printer();
            printer.PrintIncome(dataRec);
            Result = InOutFormResult.PrintOnce;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Result = InOutFormResult.Cancel;
            
            Close();
        }

        private void asTemplate_Click(object sender, EventArgs e)
        {
            InputBox inputBox = new InputBox();
            inputBox.ShowDialog();
            if (inputBox.Result != DialogResult.OK)
            {
                return;
            }
            Denik.Record template = createDataRec(dataRec);
            if (template != null)
            {
                Settings.Settings.SettingsHolder.addTemplate(inputBox.InputText, template);
            }
            Settings.Settings.Store();
            m_parentMain.LoadSettings();
        }
    }
}
