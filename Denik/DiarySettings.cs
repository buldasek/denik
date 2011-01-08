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
            edInitRemain.Text = diary.InitRemain.ToString();
            edRemainLimit.Text = diary.RemainLimit.ToString();
            edWarnLimit.Text = diary.RemainWarning.ToString();
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
                m_diary.InitRemain = int.Parse(edInitRemain.Text);
                m_diary.RemainWarning = int.Parse(edWarnLimit.Text);
                m_diary.RemainLimit = int.Parse(edRemainLimit.Text);
            }
            catch
            {
                MessageBox.Show("Wrong number");
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
