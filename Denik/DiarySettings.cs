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
            m_diary.InitTypeCounts[(int)Record.RecordType.Income] = decimal.ToInt32(ndIncomeCount.Value);
            m_diary.InitTypeCounts[(int)Record.RecordType.Expense] = decimal.ToInt32(ndOutcomeCount.Value);
            m_diary.Name = edDiaryHeader.Text;
            try
            {
                m_diary.InitRemain = (int)MoneyConvertor.StrToMoney(edInitRemain.Text, int.MaxValue);
                m_diary.RemainWarning = (int)MoneyConvertor.StrToMoney(edWarnLimit.Text, int.MaxValue);
                m_diary.RemainLimit = (int)MoneyConvertor.StrToMoney(edRemainLimit.Text, int.MaxValue);
            }
            catch
            {
                MessageBox.Show("Nevyhovující částky.");
                return;
            }

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
