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

            if (value >= 1000)
            {
                int thousands  = value /1000;
                result = numberHundreds[thousands / 100];
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


    public class Printer
    {
        //private static PrintDialog m_printDialog = new PrintDialog();
        private static PrintDocument m_printDoc = new PrintDocument();
        private Record m_recToPrint;
        private int curPage;

        public PrintDocument printDoc
        {
            get { return m_printDoc; }
        }

        public void printOutcomeOne(Record rcToPrint)
        {
            m_printDoc.DocumentName = "Tisk deniku...";
            m_printDoc.PrintPage += new PrintPageEventHandler(OnPrintOutcome);
            m_printDoc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("PaperA6", 583, 827);
            m_recToPrint = rcToPrint;
            m_printDoc.DefaultPageSettings.Landscape = false;

            try { m_printDoc.Print(); }
            catch (Exception) { MessageBox.Show("ajajaj printing"); }

            m_printDoc.PrintPage -= new PrintPageEventHandler(OnPrintOutcome);
        }

        public void printOutcomeTwiceTwoPage(Record rcToPrint)
        {
            m_printDoc.DocumentName = "Tisk deniku...";
            m_printDoc.PrintPage += new PrintPageEventHandler(OnPrintOutcomeTwiceTwo);
            m_printDoc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("PaperA6", 583, 827);
            m_recToPrint = rcToPrint;
            m_printDoc.DefaultPageSettings.Landscape = false;
            curPage = 0;

            try { m_printDoc.Print(); }
            catch (Exception) { MessageBox.Show("ajajaj printing"); }

            m_printDoc.PrintPage -= new PrintPageEventHandler(OnPrintOutcomeTwiceTwo);
        }

        //public void printOutcomeTwiceOnePage(Record rcToPrint)
        //{
        //    m_printDoc.DocumentName = "Tisk deniku...";
        //    m_printDoc.PrintPage += new PrintPageEventHandler(OnPrintOutcomeTwiceOne);
        //    m_printDoc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("PaperA5", 827, 1166);
        //    m_recToPrint = rcToPrint;
        //    m_printDoc.DefaultPageSettings.Landscape = false;

        //    try { m_printDoc.Print(); }
        //    catch (Exception) { MessageBox.Show("ajajaj printing"); }

        //    m_printDoc.PrintPage -= new PrintPageEventHandler(OnPrintOutcomeTwiceOne);
        //}

        public void PrintIncome(Record rcToPrint)
        {
            m_printDoc.DocumentName = "Tisk deniku...";
            m_printDoc.PrintPage += new PrintPageEventHandler(OnPrintIncome);
            m_printDoc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("PaperA6", 583, 827);
            m_recToPrint = rcToPrint;
            m_printDoc.DefaultPageSettings.Landscape = false;
            curPage = 0;

            try { m_printDoc.Print(); }
            catch (Exception) { MessageBox.Show("ajajaj printing"); }

            m_printDoc.PrintPage -= new PrintPageEventHandler(OnPrintIncome);
        }

        //TODO ten offset asi moc nefunguje   
        private void PrintOutcome(Graphics g, int yOffset, int width, int height)
        {
            g.ResetTransform();

            Bitmap im = new Bitmap("dokladstabulkou.bmp");//Prijmovydokladstabulkou.bmp Stvrzenka.bmp
            g.DrawImage(im, 0, yOffset, width, g.VisibleClipBounds.Height + yOffset);
            g.RotateTransform(90);
            g.TranslateTransform(0, -g.VisibleClipBounds.Height);
       
            g.ScaleTransform(((float)height) / im.Height, ((float)(width)) / im.Width);

            StringFormat DrawFormat = new StringFormat();
            DrawFormat.Alignment = StringAlignment.Center;
            DrawFormat.LineAlignment = StringAlignment.Center;


            Font defaultTextFont = new Font(FontFamily.GenericMonospace, 10, FontStyle.Bold);
            Brush textBrush = new SolidBrush(Color.Black);
            StringFormat LeftAlText = new StringFormat();
            LeftAlText.Alignment = StringAlignment.Near;
            StringFormat CenterAlText = new StringFormat();
            CenterAlText.Alignment = StringAlignment.Center;

            g.DrawString("Výdajový pokladní doklad", new Font(FontFamily.GenericSerif, 13, FontStyle.Bold), textBrush, new Point(260, 15 + yOffset), LeftAlText);
            PrintCommon(g, yOffset, false);            

            g.DrawString("Podpis pokladníka", defaultTextFont, textBrush, new Point(85, 197 + yOffset), CenterAlText);
            g.DrawString("Podpis příjemce", defaultTextFont, textBrush, new Point(250, 197 + yOffset), CenterAlText);

            g.DrawString(m_recToPrint.PayedTo, defaultTextFont, textBrush, new Point(423, 180 + yOffset), CenterAlText);
            g.DrawString("Příjemce hotovosti", defaultTextFont, textBrush, new Point(423, 197 + yOffset), CenterAlText);
            g.ResetTransform();
        }
        
        //offset nejspis nefunguje
        private void PrintIncome(Graphics g, int yOffset, int width, int height)
        {
            g.ResetTransform();
         
            Bitmap im;

            im = new Bitmap("Prijmovydokladstabulkou.bmp");//Prijmovydokladstabulkou.bmp Stvrzenka.bmp
            g.DrawImage(im, yOffset, 0, width + yOffset, height);
            g.RotateTransform(90);

            g.TranslateTransform(0, -g.VisibleClipBounds.Height);

            g.ScaleTransform((height) / (float)im.Height, (width) / (float)im.Width);

            StringFormat DrawFormat = new StringFormat();
            DrawFormat.Alignment = StringAlignment.Center;
            DrawFormat.LineAlignment = StringAlignment.Center;


            Font defaultTextFont = new Font(FontFamily.GenericMonospace, 10, FontStyle.Bold);
            Brush textBrush = new SolidBrush(Color.Black);
            StringFormat LeftAlText = new StringFormat();
            LeftAlText.Alignment = StringAlignment.Near;
            StringFormat CenterAlText = new StringFormat();
            CenterAlText.Alignment = StringAlignment.Center;

            g.DrawString("Příjmový pokladní doklad", new Font(FontFamily.GenericSerif, 13, FontStyle.Bold),
                        textBrush, new Point(260, 15 + yOffset), LeftAlText);
            PrintCommon(g, yOffset, false);
            
            g.DrawString("Podpis pokladníka", defaultTextFont, textBrush, new Point(423, 197+ yOffset), CenterAlText);

        }

        private void printIncomeReceipt(Graphics g, int yOffset, int width, int height)
        {
            Bitmap im;
            g.ResetTransform();
            im = new Bitmap("Stvrzenka.bmp");//Prijmovydokladstabulkou.bmp Stvrzenka.bmp
            g.DrawImage(im, yOffset, 0, width + yOffset, height);
            g.RotateTransform(90);

            g.ScaleTransform(height / (float)im.Height, width / (float)im.Width);
            g.TranslateTransform(0, -g.VisibleClipBounds.Height);
            
            StringFormat DrawFormat = new StringFormat();
            DrawFormat.Alignment = StringAlignment.Center;
            DrawFormat.LineAlignment = StringAlignment.Center;


            Font defaultTextFont = new Font(FontFamily.GenericMonospace, 10, FontStyle.Bold);
            Brush textBrush = new SolidBrush(Color.Black);
            StringFormat LeftAlText = new StringFormat();
            LeftAlText.Alignment = StringAlignment.Near;
            StringFormat CenterAlText = new StringFormat();
            CenterAlText.Alignment = StringAlignment.Center;

            g.DrawString("Stvrzenka", new Font(FontFamily.GenericSerif, 13, FontStyle.Bold), textBrush,
                        new Point(260, 15+ yOffset), LeftAlText);
            PrintCommon(g, yOffset, true);

            g.DrawString("Podpis pokladníka", defaultTextFont, textBrush, new Point(423, 197+ yOffset), CenterAlText);
        }

        private void PrintCommon(Graphics g, int yOffset, bool onlyUpper)
        {
            Font defaultTextFont = new Font(FontFamily.GenericMonospace, 10, FontStyle.Bold);
            Brush textBrush = new SolidBrush(Color.Black);
            StringFormat LeftAlText = new StringFormat();
            LeftAlText.Alignment = StringAlignment.Near;
            StringFormat CenterAlText = new StringFormat();
            CenterAlText.Alignment = StringAlignment.Center;
            Font stampFont = new Font(FontFamily.GenericMonospace, 9, FontStyle.Regular);
            
            string  [] Stamp = Settings.Settings.Stamp;
            for (int i = 0; i < Math.Min(6, Stamp.Length); i++)
            {
                g.DrawString(Stamp[i], stampFont, textBrush, new PointF(130, 11+((6-Math.Min(Stamp.Length,6))/(float)2+i)*11), CenterAlText);
            }

            g.DrawString("číslo " + m_recToPrint.TypeID.ToString(), defaultTextFont, textBrush, new Point(260, 45 + yOffset), LeftAlText);
            g.DrawString("ze dne " + m_recToPrint.Date, defaultTextFont, textBrush, new Point(260, 60 + yOffset), LeftAlText);

            g.DrawString("Vyplaceno: " + m_recToPrint.CustName, defaultTextFont, textBrush, new Point(10, 88 + yOffset), LeftAlText);
            g.DrawString("Částka: " + m_recToPrint.Cost.ToString() + ",00", new Font(FontFamily.GenericMonospace, 13, FontStyle.Bold), 
                            textBrush, new Point(10, 105 + yOffset), LeftAlText);
            g.DrawString("Slovy: ==" + NumberConvertor.ConvertIntToString((int)m_recToPrint.Cost)+" Kč==",
                            defaultTextFont, textBrush, new Point(10, 125 + yOffset), LeftAlText);
            g.DrawString("Účel platby: " + m_recToPrint.Content, defaultTextFont, textBrush, new Point(10, 142 + yOffset), LeftAlText);

            CenterAlText.LineAlignment = StringAlignment.Center;
            if (!onlyUpper)
            {
                g.DrawString("Text", defaultTextFont, textBrush, new Point(70, 224 + yOffset), CenterAlText);
                g.DrawString("Účt. předpis (Má dáti-účet)", defaultTextFont, textBrush, new Point(255, 224 + yOffset), CenterAlText);
                g.DrawString("Kč", defaultTextFont, textBrush, new Point(437, 224 + yOffset), CenterAlText);

                LeftAlText.LineAlignment = StringAlignment.Center;
                g.DrawString("Schválil:", defaultTextFont, textBrush, new Point(10, 317 + yOffset), LeftAlText);
                g.DrawString("Zaúčtoval:", defaultTextFont, textBrush, new Point(195, 317 + yOffset), LeftAlText);
                g.DrawString("Dne: ", defaultTextFont, textBrush, new Point(383, 317 + yOffset), LeftAlText);
            }
        }

        //
        // Event Handler
        //
        private void OnPrintOutcome(object sender, PrintPageEventArgs ppea)
        {
            PrintOutcome(ppea.Graphics, 0, (int)ppea.Graphics.VisibleClipBounds.Width, (int)ppea.Graphics.VisibleClipBounds.Height);
        }

        //private void OnPrintOutcomeTwiceOne(object sender, PrintPageEventArgs ppea)
        //{
        //    PrintOutcome(ppea.Graphics, 0, (int)ppea.Graphics.VisibleClipBounds.Width, (int)ppea.Graphics.VisibleClipBounds.Height, true);
        //    ppea.Graphics.ResetTransform();
        //    PrintOutcome(ppea.Graphics, (int)ppea.Graphics.VisibleClipBounds.Width/2, 
        //                    (int)ppea.Graphics.VisibleClipBounds.Width, (int)ppea.Graphics.VisibleClipBounds.Height, true);
        //}

        private void OnPrintOutcomeTwiceTwo(object sender, PrintPageEventArgs ppea)
        {
            //todo nejak lepe udelat pocitani stranek
            PrintOutcome(ppea.Graphics, 0, (int)ppea.Graphics.VisibleClipBounds.Width, (int)ppea.Graphics.VisibleClipBounds.Height);
            if (curPage==0)
            {
                ppea.HasMorePages = true;
                curPage = 1;
            }
            
        }

        private void OnPrintIncome(object sender, PrintPageEventArgs ppea)
        {
            if (curPage == 0)
            {
                curPage = 1;
                ppea.HasMorePages = true;
                PrintIncome(ppea.Graphics, 0, (int)ppea.Graphics.VisibleClipBounds.Width, (int)ppea.Graphics.VisibleClipBounds.Height);
            }
            else
                printIncomeReceipt(ppea.Graphics, 0, (int)ppea.Graphics.VisibleClipBounds.Width
                    , (int)ppea.Graphics.VisibleClipBounds.Height);
        }

        //private void OnPrintPage(object sender, PrintPageEventArgs ppea)
        //{
        //    Graphics g = ppea.Graphics;
        //    Bitmap im;

        //    if (m_recToPrint.Type == Record.RecordType.Expense)
        //    {
        //        im = new Bitmap("dokladstabulkou.bmp");//Prijmovydokladstabulkou.bmp Stvrzenka.bmp
        //        g.DrawImage(im, 0, 0, g.VisibleClipBounds.Width, g.VisibleClipBounds.Height);
        //    }
        //    else
        //    {
        //        im = new Bitmap("Prijmovydokladstabulkou.bmp");//Prijmovydokladstabulkou.bmp Stvrzenka.bmp
        //        g.DrawImage(im, 0, 0, g.VisibleClipBounds.Width / 2, g.VisibleClipBounds.Height);
        //        im = new Bitmap("Stvrzenka.bmp");//Prijmovydokladstabulkou.bmp Stvrzenka.bmp
        //        g.DrawImage(im, g.VisibleClipBounds.Width / 2, 0, g.VisibleClipBounds.Width / 2, g.VisibleClipBounds.Height);
        //    }
        //    g.RotateTransform(90);

        //    g.TranslateTransform(0, -g.VisibleClipBounds.Height);
        //    if (m_recToPrint.Type == Record.RecordType.Expense)
        //        g.ScaleTransform((g.VisibleClipBounds.Width) / im.Height, (g.VisibleClipBounds.Height) / im.Width);
        //    else
        //        g.ScaleTransform((g.VisibleClipBounds.Width) / im.Height, (g.VisibleClipBounds.Height/2) / im.Width);

        //    StringFormat DrawFormat = new StringFormat();
        //    DrawFormat.Alignment = StringAlignment.Center;
        //    DrawFormat.LineAlignment = StringAlignment.Center;


        //    Font defaultTextFont = new Font(FontFamily.GenericMonospace, 10, FontStyle.Bold);
        //    Brush textBrush = new SolidBrush(Color.Black);
        //    StringFormat LeftAlText = new StringFormat();
        //    LeftAlText.Alignment = StringAlignment.Near;
        //    StringFormat CenterAlText = new StringFormat();
        //    CenterAlText.Alignment = StringAlignment.Center;

        //    if (m_recToPrint.Type == Record.RecordType.Expense)
        //    {
        //        g.DrawString("Výdajový pokladní doklad", new Font(FontFamily.GenericSerif, 13, FontStyle.Bold), textBrush, new Point(260, 15), LeftAlText);
        //        (g, 0);
        //    }
        //    else
        //    {
        //        g.DrawString("Příjmový pokladní doklad", new Font(FontFamily.GenericSerif, 13, FontStyle.Bold),
        //                    textBrush, new Point(260, 15 + (int)g.VisibleClipBounds.Height / 2), LeftAlText);
        //        g.DrawString("Stvrzenka", new Font(FontFamily.GenericSerif, 13, FontStyle.Bold), textBrush, 
        //                    new Point(260, 15), LeftAlText);
        //        PrintUpper(g, 0);
        //        PrintUpper(g, (int)(g.VisibleClipBounds.Height / 2));
        //    }

        //    if (m_recToPrint.Type == Record.RecordType.Expense)
        //    {
        //        g.DrawString("Podpis pokladníka", defaultTextFont, textBrush, new Point(85, 197), CenterAlText);
        //        g.DrawString("Podpis příjemce", defaultTextFont, textBrush, new Point(250, 197), CenterAlText);

        //        g.DrawString(m_recToPrint.PayedTo, defaultTextFont, textBrush, new Point(423, 180), CenterAlText);
        //        g.DrawString("Příjemce hotovosti", defaultTextFont, textBrush, new Point(423, 197), CenterAlText);

        //    }
        //    else
        //    {
        //        g.DrawString("Podpis pokladníka", defaultTextFont, textBrush, new Point(423, 197), CenterAlText);
        //        g.DrawString("Podpis pokladníka", defaultTextFont, textBrush, new Point(423, 197 + (int)g.VisibleClipBounds.Height / 2), CenterAlText);

        //    }

        ////ppea.HasMorePages
        //}
    }

}