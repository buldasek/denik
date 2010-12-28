using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Denik
{

    public class FastDataGridView : DataGridView
    {
        public FastDataGridView()
        {
            DoubleBuffered = true;
        }
        protected override void OnCursorChanged(EventArgs e)
        {
            base.OnCursorChanged(e);
            bool bDefault = Cursor == Cursors.Default;
            DoubleBuffered = bDefault;
        }
    }

    //public class IntegerEdit : TextBox
    //{
    //    public void setInt(int value)
    //    {
    //        // todo udelat z toho peknej string
    //    }
    //}
}