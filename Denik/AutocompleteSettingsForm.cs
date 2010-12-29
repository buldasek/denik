using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Denik
{
    public partial class AutocompleteSettingsForm : Form
    {
        public AutocompleteSettingsForm()
        {
            InitializeComponent();

            btnRecipient.Visible = false;
            setGridContent("IncomeNote", "OutcomeNote");
        }

        //{"IncomeNote", "IncomeName", "IncomeFor", "OutcomeNote",
        //                                                "OutcomeName", "OutcomeFor", "OutcomeRecipient"};
        private void setGridContent(string incomeVariant, string outcomeVariant)
        {
            gridAC.Rows.Clear();
            string[] hints;
            if (rbIncome.Checked)
                hints = Settings.Settings.getHints(incomeVariant);
            else
                hints = Settings.Settings.getHints(outcomeVariant);

            if (hints.Length < 1)
                return;

            gridAC.Rows.Add(hints.Length);
            for (int i = 0; i < hints.Length; i++)
                gridAC[0, i].Value = hints[i];
        }

        private void btnNote_Click(object sender, EventArgs e)
        {
            setGridContent("IncomeNote", "OutcomeNote");
        }

        private void btnName_Click(object sender, EventArgs e)
        {
            setGridContent("IncomeName", "OutcomeName");
        }

        private void btnContent_Click(object sender, EventArgs e)
        {
            setGridContent("IncomeFor", "OutcomeFor");
        }

        private void btnRecipient_Click(object sender, EventArgs e)
        {
            setGridContent("OutcomeRecipient", "OutcomeRecipient");
        }

        private void rbIncome_CheckedChanged(object sender, EventArgs e)
        {
            if (rbIncome.Checked)
                btnRecipient.Visible = false;
            else
                btnRecipient.Visible = true;
            setGridContent("IncomeNote", "OutcomeNote");
        }
    }
}
