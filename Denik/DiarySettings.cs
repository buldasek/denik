using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Denik
{
    public partial class DiarySettings : Form
    {
        Diary m_diary;

        public DiarySettings(Diary diary)
        {
            InitializeComponent();

            ndIncomeCount.Value = diary.InitTypeCounts[(int)Record.RecordType.Income];
            ndOutcomeCount.Value = diary.InitTypeCounts[(int)Record.RecordType.Expense];
            edInitRemain.Text = MoneyConvertor.MoneyToStr(diary.InitRemain);
            edRemainLimit.Text = MoneyConvertor.MoneyToStr(diary.RemainLimit);
            edWarnLimit.Text = MoneyConvertor.MoneyToStr(diary.RemainWarning);
            edDiaryHeader.Text = diary.Name;

            m_diary = diary;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int initTypeCountsIn = decimal.ToInt32(ndIncomeCount.Value);
            int initTypeCountsOut = decimal.ToInt32(ndOutcomeCount.Value);
            int initRemain, remainWarning, remainLimit;
            
            try
            {
                initRemain = (int)MoneyConvertor.StrToMoney(edInitRemain.Text, int.MaxValue);
                remainWarning = (int)MoneyConvertor.StrToMoney(edWarnLimit.Text, int.MaxValue);
                remainLimit = (int)MoneyConvertor.StrToMoney(edRemainLimit.Text, int.MaxValue);
            }
            catch
            {
                MessageBox.Show("Nevyhovující částky.");
                return;
            }

            m_diary.InitTypeCounts[(int)Record.RecordType.Income] = initTypeCountsIn;
            m_diary.InitTypeCounts[(int)Record.RecordType.Expense] = initTypeCountsOut;
            m_diary.Name = edDiaryHeader.Text;
            m_diary.InitRemain = initRemain;
            m_diary.RemainWarning = remainWarning;
            m_diary.RemainLimit = remainLimit;

            m_diary.StoreChanges();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
