using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Denik
{
    public partial class ExperimentalForm : Form
    {
        public ExperimentalForm()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Bitmap im = new Bitmap("dokladstabulkou.bmp");
            g.TranslateTransform(0, im.Width);

            g.RotateTransform(-90);
            g.DrawImage(im, 0, 0, im.Width, im.Height);
            g.DrawLine(new Pen(Color.Black), 0, 0, 0, 100);
            g.DrawLine(new Pen(Color.Black), 0, 0, 100, 0);
            g.RotateTransform(90);

            g.TranslateTransform(0, -im.Width);

            //g.TranslateTransform(im.Width, 0);
            //g.RotateTransform(this.hScrollBar1.Value - 180);
            StringFormat DrawFormat = new StringFormat();
            DrawFormat.Alignment = StringAlignment.Center;
            DrawFormat.LineAlignment = StringAlignment.Center;
            //g.DrawString("hello word", new Font(FontFamily.GenericMonospace, 10), new SolidBrush(Color.Black), new Point(00, 00));
            //for (int i = 0; i < im.Width; i += 10)
            //{
            //    g.DrawLine(new Pen(Color.Black), 0, i, 10, i);
            //    g.DrawString(i.ToString(), new Font(FontFamily.GenericMonospace, 10), new SolidBrush(Color.Black), new Point(10, i), DrawFormat);
            //}

            //for (int i = 0; i < im.Height; i += 10)
            //{
            //    g.DrawLine(new Pen(Color.Black), i, 0, i, 10);
            //    if (i % 50 == 0)

            //        g.DrawString(i.ToString(), new Font(FontFamily.GenericMonospace, 10), new SolidBrush(Color.Black), new Point(i, 10), DrawFormat);
            //}

            Font defaultTextFont = new Font(FontFamily.GenericMonospace, 10, FontStyle.Bold);
            Brush textBrush = new SolidBrush(Color.Black);
            StringFormat LeftAlText = new StringFormat();
            LeftAlText.Alignment = StringAlignment.Near;
            StringFormat CenterAlText = new StringFormat();
            CenterAlText.Alignment = StringAlignment.Center;
            
            g.DrawString("Výdajový pokladní doklad", new Font(FontFamily.GenericSerif, 13, FontStyle.Bold), textBrush, new Point(260, 15), LeftAlText);
            g.DrawString("číslo", defaultTextFont, textBrush, new Point(260, 45), LeftAlText);
            g.DrawString("ze dne", defaultTextFont, textBrush, new Point(260, 60), LeftAlText);

            g.DrawString("Vyplaceno: ", defaultTextFont, textBrush, new Point(10, 88), LeftAlText);
            g.DrawString("Částka: ", new Font(FontFamily.GenericMonospace, 13, FontStyle.Bold), textBrush, new Point(10, 105), LeftAlText);
            g.DrawString("Slovy: ", defaultTextFont, textBrush, new Point(10, 125), LeftAlText);
            g.DrawString("Účel platby: ", defaultTextFont, textBrush, new Point(10, 142), LeftAlText);

            g.DrawString("Podpis pokladníka", defaultTextFont, textBrush, new Point(85, 200), CenterAlText);
            g.DrawString("Podpis příjemce", defaultTextFont, textBrush, new Point(250, 200), CenterAlText);
            g.DrawString("Příjemce hotovosti", defaultTextFont, textBrush, new Point(423, 200), CenterAlText);

            CenterAlText.LineAlignment = StringAlignment.Center;
            g.DrawString("Text", defaultTextFont, textBrush, new Point(70, 224), CenterAlText);
            g.DrawString("Účt. předpis (Má dáti-účet)", defaultTextFont, textBrush, new Point(255, 224), CenterAlText);
            g.DrawString("Kč", defaultTextFont, textBrush, new Point(437, 224), CenterAlText);

            LeftAlText.LineAlignment = StringAlignment.Center;
            g.DrawString("Schválil:", defaultTextFont, textBrush, new Point(10, 317), LeftAlText);
            g.DrawString("Zaúčtoval:", defaultTextFont, textBrush, new Point(195, 317), LeftAlText);
            g.DrawString("Dne:", defaultTextFont, textBrush, new Point(383, 317), LeftAlText);

            
        }

        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.label1.Text = NumberConvertor.ConvertIntToWord(decimal.ToInt32(this.numericUpDown1.Value));
        }
    }
}