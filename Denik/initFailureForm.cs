using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Denik
{
    public partial class initFailureForm : Form
    {
        public enum InitFailureResults
        {
            Cancel = 0,
            Open = 1,
            New = 2,
        }

        public InitFailureResults Result { set; get; }

        public initFailureForm()
        {
            InitializeComponent();
            Result = InitFailureResults.Cancel;


        }

        //Veprovina...

        private void btnClose_Click(object sender, EventArgs e)
        {
            //DialogResult = DialogResult.Cancel;
            Result = InitFailureResults.Cancel;
            Close();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            //DialogResult = DialogResult.Retry;
            Result = InitFailureResults.Open;
            Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ////DialogResult = DialogResult.
            Result = InitFailureResults.New;
            Close();
        }
    }
}
