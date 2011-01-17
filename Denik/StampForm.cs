using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Denik
{
    public partial class StampForm : Form
    {
        public StampForm()
        {
            InitializeComponent();
            edStamp.Lines = Settings.Settings.SettingsHolder.Stamp;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (edStamp.Lines.Length > 6)
            {
                MessageBox.Show("Razítko může mít maximálně 6 řádek.", "Pozor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Settings.Settings.SettingsHolder.Stamp = edStamp.Lines;

            Close();
        }
    }
}
