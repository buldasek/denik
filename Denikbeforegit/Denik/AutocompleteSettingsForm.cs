using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Denik
{
    public partial class AutocompleteSettingsForm : Form
    {
        public AutocompleteSettingsForm()
        {
            InitializeComponent();

            rbIncome.Checked = true;
            tabControls.TabPages.Remove(tabNote); //maybe will be used in future
            onFormTypeChanged();
            ///tabControls.TabPages.Remove(tabRecipient);
            //setGridContent("IncomeNote", "OutcomeNote");
        }

        private void setGridContent(DataGridView grid, string incomeVariant, string outcomeVariant)
        {
            grid.Rows.Clear();
            string[] hints;
            if (rbIncome.Checked)
                hints = Settings.Settings.SettingsHolder.getHints(incomeVariant);
            else
                hints = Settings.Settings.SettingsHolder.getHints(outcomeVariant);

            if (hints.Length < 1)
                return;

            grid.Rows.Add(hints.Length);
            for (int i = 0; i < hints.Length; i++)
                grid[0, i].Value = hints[i];
        }

        private void deleteSelected(DataGridView grid, string incomeVariant, string outcomeVariant)
        {
            String hiClass;
            if (rbIncome.Checked)
                hiClass = incomeVariant;
            else 
                hiClass = outcomeVariant;

            foreach (DataGridViewRow row in  grid.SelectedRows)
            {
                Settings.Settings.SettingsHolder.removeHint(hiClass, (string)(grid[0, row.Index/*grid.SelectedRows[0].Index*/].Value));

                grid.Rows.Remove(grid.SelectedRows[0]);
            }
        }
          
        private void onFormTypeChanged()
        {
            if (rbIncome.Checked)
            {
                if (tabControls.TabPages.Contains(tabRecipient))
                    tabControls.TabPages.Remove(tabRecipient);
            }
            else
            {
                if (!tabControls.TabPages.Contains(tabRecipient))
                    tabControls.TabPages.Add(tabRecipient);
            }

            //setGridContent(gridNote, "IncomeNote", "OutcomeNote");
            setGridContent(gridName, "IncomeName", "OutcomeName");
            setGridContent(gridFor, "IncomeFor", "OutcomeFor");
            setGridContent(gridRecipient, "OutcomeRecipient", "OutcomeRecipient");
            gridName.KeyUp += new KeyEventHandler(gridKeyUpHandler);
            gridFor.KeyUp += new KeyEventHandler(gridKeyUpHandler);
            gridRecipient.KeyUp += new KeyEventHandler(gridKeyUpHandler);
        }

        private void gridKeyUpHandler(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (!(sender is FastDataGridView))
            {
                return;
            }
            FastDataGridView grid = (FastDataGridView)sender;
            char c = Convert.ToChar(e.KeyCode); 
            for (int i = 0; i < grid.RowCount; i++)
            {
                if (grid[0, i].Value.ToString().StartsWith(c.ToString(), StringComparison.CurrentCultureIgnoreCase)) {
                    grid.CurrentCell = grid[0, i];
                    break;
                }
            }
        }

        private void btnNote_Click(object sender, EventArgs e)
        {
            //setGridContent("IncomeNote", "OutcomeNote");
        }

        private void btnName_Click(object sender, EventArgs e)
        {
            //setGridContent("IncomeName", "OutcomeName");
        }

        private void btnContent_Click(object sender, EventArgs e)
        {
            //setGridContent("IncomeFor", "OutcomeFor");
        }

        private void btnRecipient_Click(object sender, EventArgs e)
        {
            //setGridContent("OutcomeRecipient", "OutcomeRecipient");
        }

        private void rbIncome_CheckedChanged(object sender, EventArgs e)
        {
            onFormTypeChanged();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            /*if (tabControls.SelectedTab == tabNote)
                deleteSelected(gridNote, "IncomeNote", "OutcomeNote");
            else 
             * */
            if (tabControls.SelectedTab == tabName)
                deleteSelected(gridName, "IncomeName", "OutcomeName");
            else if (tabControls.SelectedTab == tabFor)
                deleteSelected(gridFor, "IncomeFor", "OutcomeFor");
            else if (tabControls.SelectedTab == tabRecipient)
                deleteSelected(gridRecipient, "OutcomeRecipient", "OutcomeRecipient");
            else
                Debug.Assert(false);
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gridNote_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gridName_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gridFor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
