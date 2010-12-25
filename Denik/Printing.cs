using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Diagnostics;


namespace Denik
{
    class NumberConvertor   //todo move to different file
    {
        static private string[] numbers1to19 = { "", "jedna", "dva", "tři", "čtyři", "pět"
            , "šest", "sedm", "osm", "devět", "deset", "jedenáct", "dvanáct",
            "třináct", "čtrnáct", "patnáct", "šestnáct", "sedmnáct", "osmnáct", "devatenáct"};

        static private string[] numbersDecades = {"", "", "dvacet", "třicet", "čtyřicet", "padesát", "šedesát"
                                                  ,"sedmdesát", "osmdesát", "devadesát"};
        static private string[] numberHundreds = {"", "sto", "dvěstě", "třista", "čtyřista", "pětset", "šestset",
                                                  "sedmset", "osmset", "devětset"};

        static public string ConvertIntToString(int value)
        {
            Debug.Assert(value < 1000000);

            string result = "";
            if (value == 0)
                return "nula";

            if (value > 1000)
            {
                int thousands  = value /1000;
                result = numberHundreds[thousands / 100];
                string tensRes;
                int tens = thousands % 100;
                if (tens!=0)
                {
                    if (2<=thousands && thousands<=4)
                    {
                        result = result + numbers1to19[thousands % 10] + "tisíce";
                    }
                    else if (1 == thousands)
                    {
                        result = result + "jedentisíc";
                    }
                    else if (tens <= 19)
                    {
                        result = result + numbers1to19[tens] + "tisíc";
                    }
                    else
                    {
                        result = result + numbersDecades[tens / 10] + numbers1to19[tens % 10] + "tisíc";
                    }
                }
                else
                {
                    result= result + "tisíc";
                }
            }

            int restThous = value % 1000;
            result = result + numberHundreds[restThous / 100];
            restThous = restThous % 100;
            if (restThous >= 20)
                result = result + numbersDecades[restThous / 10] + numbers1to19[restThous % 10];
            else
                result = result + numbers1to19[restThous];

            return result;

        }


    }


    class Printer
    {
        //private static PrintDialog m_printDialog = new PrintDialog();
        private static PrintDocument m_printDoc = new PrintDocument();
        private Record m_recToPrint;

        public void print(Record rcToPrint)
        {
            m_printDoc.DocumentName = "Tisk deniku...";
            m_printDoc.PrintPage += new PrintPageEventHandler(OnPrintPage);
            m_printDoc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("PaperA55", 583, 827);
            m_recToPrint = rcToPrint;
            //PrintDialog m_printDialog = new PrintDialog();

            //m_printDialog.Document = printDoc;
            //m_printDialog.ShowDialog();
            // Send print message
            try { m_printDoc.Print(); }
            catch (Exception) { MessageBox.Show("ajajaj printing"); }
        }
        //
        // Event Handler
        //
        private void OnPrintPage(object sender, PrintPageEventArgs ppea)
        {
            Graphics g = ppea.Graphics;
            
            Bitmap im = new Bitmap("dokladstabulkou.bmp");

            g.DrawImage(im, 0, 0, g.VisibleClipBounds.Width,g.VisibleClipBounds.Height);
            g.RotateTransform(90);

            g.TranslateTransform(0, -g.VisibleClipBounds.Height);
            g.ScaleTransform((g.VisibleClipBounds.Width) / im.Height, (g.VisibleClipBounds.Height) / im.Width);

            StringFormat DrawFormat = new StringFormat();
            DrawFormat.Alignment = StringAlignment.Center;
            DrawFormat.LineAlignment = StringAlignment.Center;
            g.DrawString("hello word", new Font(FontFamily.GenericMonospace, 10), new SolidBrush(Color.Black), new Point(00, 00));
            for (int i = 0; i < im.Width; i += 10)
            {
                g.DrawLine(new Pen(Color.Black), 0, i, 10, i);
                g.DrawString(i.ToString(), new Font(FontFamily.GenericMonospace, 10), new SolidBrush(Color.Black), new Point(10, i), DrawFormat);
            }

            for (int i = 0; i < im.Height; i += 10)
            {
                g.DrawLine(new Pen(Color.Black), i, 0, i, 10);
                if (i % 50 == 0)

                    g.DrawString(i.ToString(), new Font(FontFamily.GenericMonospace, 10), new SolidBrush(Color.Black), new Point(i, 10), DrawFormat);
            }

            Font defaultTextFont = new Font(FontFamily.GenericMonospace, 10, FontStyle.Bold);
            Brush textBrush = new SolidBrush(Color.Black);
            StringFormat LeftAlText = new StringFormat();
            LeftAlText.Alignment = StringAlignment.Near;
            StringFormat CenterAlText = new StringFormat();
            CenterAlText.Alignment = StringAlignment.Center;

            g.DrawString("Výdajový pokladní doklad", new Font(FontFamily.GenericSerif, 13, FontStyle.Bold), textBrush, new Point(260, 15), LeftAlText);
            g.DrawString("číslo", defaultTextFont, textBrush, new Point(260, 45), LeftAlText);
            g.DrawString(m_recToPrint.TypeID.ToString(), defaultTextFont, textBrush, new Point(315, 45), LeftAlText);
            g.DrawString("ze dne", defaultTextFont, textBrush, new Point(260, 60), LeftAlText);
            g.DrawString(m_recToPrint.Date, defaultTextFont, textBrush, new Point(325, 60), LeftAlText);

            g.DrawString("Vyplaceno: ", defaultTextFont, textBrush, new Point(10, 88), LeftAlText);
            g.DrawString("Částka: ", new Font(FontFamily.GenericMonospace, 13, FontStyle.Bold), textBrush, new Point(10, 105), LeftAlText);
            g.DrawString("Slovy: ", defaultTextFont, textBrush, new Point(10, 125), LeftAlText);
            g.DrawString("Účel platby: ", defaultTextFont, textBrush, new Point(10, 142), LeftAlText);

            g.DrawString("Podpis pokladníka", defaultTextFont, textBrush, new Point(85, 197), CenterAlText);
            g.DrawString("Podpis příjemce", defaultTextFont, textBrush, new Point(250, 197), CenterAlText);
            g.DrawString("Příjemce hotovosti", defaultTextFont, textBrush, new Point(423, 197), CenterAlText);

            CenterAlText.LineAlignment = StringAlignment.Center;
            g.DrawString("Text", defaultTextFont, textBrush, new Point(70, 224), CenterAlText);
            g.DrawString("Účt. předpis (Má dáti-účet)", defaultTextFont, textBrush, new Point(255, 224), CenterAlText);
            g.DrawString("Kč", defaultTextFont, textBrush, new Point(437, 224), CenterAlText);

            LeftAlText.LineAlignment = StringAlignment.Center;
            g.DrawString("Schválil:", defaultTextFont, textBrush, new Point(10, 317), LeftAlText);
            g.DrawString("Zaúčtoval:", defaultTextFont, textBrush, new Point(195, 317), LeftAlText);
            g.DrawString("Dne:", defaultTextFont, textBrush, new Point(383, 317), LeftAlText);
            
        }

    }

}