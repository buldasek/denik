using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Denik
{
    public partial class InputBox : Form
    {
        public DialogResult Result;
        public InputBox()
        {
            InitializeComponent();
            InputText = "Jméno šablony";
            
        }

        public string InputText
        {
             get { return inputText.Text; }
            set { inputText.Text = value; }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (Text.Equals(""))
            {
                Result = DialogResult.Cancel;
            }
            else
            {
                Result = DialogResult.OK;
            }
            Close();
        }
    }
}
