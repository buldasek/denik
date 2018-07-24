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
    

    public class Printer
    {
        static private string footerText = "Vytvořeno v programu Pokladni Denik 2.0";
        Font m_footerFont = new Font("Times New Roman", 8, FontStyle.Italic);

        static private string picturePath = "images/";

        static PaperSize PaperA6 = new PaperSize("Paper A6", 413, 583);

        static StringFormat LeftTopAlign;// = new StringFormat();
        static StringFormat CenterTopAlign;// = new StringFormat();
        static StringFormat RightTopAlign;// = new StringFormat();
        static StringFormat RightCenterAlign;// = new StringFormat();
        static StringFormat CenterCenterAlign;// = new StringFormat();
        static StringFormat LeftCenterAlign;// = new StringFormat();

        static Brush TextBrush = new SolidBrush(Color.Black);

        private bool m_isSizeCorrect;
        //private static PrintDialog m_printDialog = new PrintDialog();
        private static PrintDocument m_printDoc = new PrintDocument();
        private static PrintDocument m_diaryPrintDoc = new PrintDocument();
        private Record m_recToPrint;
        private Diary m_diaryToPrint;
        private int m_firstPage;
        private int m_lastPage;
        private int curPage;

        enum FormType {
            Income,
            Outcome,
        }


        private StringFormat stringFormatFactory(StringAlignment horizontal, StringAlignment vertical)
        {
            StringFormat format = new StringFormat();
            format.Alignment = horizontal;
            format.LineAlignment = vertical;

            return format;
        }



        public Printer()
        {
            LeftTopAlign = stringFormatFactory(StringAlignment.Near, StringAlignment.Near);
            CenterTopAlign = stringFormatFactory(StringAlignment.Center, StringAlignment.Near);
            RightTopAlign = stringFormatFactory(StringAlignment.Far, StringAlignment.Near);
            LeftCenterAlign = stringFormatFactory(StringAlignment.Near, StringAlignment.Center);
            CenterCenterAlign = stringFormatFactory(StringAlignment.Center, StringAlignment.Center);
            RightCenterAlign = stringFormatFactory(StringAlignment.Far, StringAlignment.Center);
        }

        public PrintDocument printDoc
        {
            get {
                if (Settings.Settings.SettingsHolder.PrinterName != "")
                {
                    m_printDoc.PrinterSettings.PrinterName = Settings.Settings.SettingsHolder.PrinterName;
                }
                return m_printDoc; 
            }
        }

        public void printOutcomeOne(Record rcToPrint)
        {
            Debug.Assert(rcToPrint != null);
            if (rcToPrint == null)
                return;

            prepareDocumentA4(printDoc);
            m_recToPrint = rcToPrint;

            printDoc.PrintPage += new PrintPageEventHandler(OnPrintOutcome);

            printDocumentSafely(printDoc);

            printDoc.PrintPage -= new PrintPageEventHandler(OnPrintOutcome);
        }

        public void printOutcomeTwiceTwoPage(Record rcToPrint)
        {
            Debug.Assert(rcToPrint != null);
            if (rcToPrint == null)
                return;
            
            prepareDocumentA4(printDoc);
            m_recToPrint = rcToPrint;

            printDoc.PrintPage += new PrintPageEventHandler(OnPrintOutcomeTwiceTwo);
            curPage = 0;

            printDocumentSafely(printDoc);

            printDoc.PrintPage -= new PrintPageEventHandler(OnPrintOutcomeTwiceTwo);
        }

        public void PrintIncome(Record rcToPrint)
        {
            Debug.Assert(rcToPrint != null);
            if (rcToPrint == null)
                return;

            prepareDocumentA4(printDoc);
            m_recToPrint = rcToPrint;
            
            printDoc.PrintPage += new PrintPageEventHandler(OnPrintIncome);
            curPage = 0;

            printDocumentSafely(printDoc);

            printDoc.PrintPage -= new PrintPageEventHandler(OnPrintIncome);
        }

        public void PrintDiary(Diary diaryToPrint, int currentPage)
        {
            Debug.Assert(diaryToPrint != null, "No diary");
            if (diaryToPrint==null)
                return;

            m_diaryToPrint = diaryToPrint;

            m_diaryPrintDoc.DocumentName = "Tisk deniku...";
            m_diaryPrintDoc.PrintPage += new PrintPageEventHandler(OnPrintDiaryPage);
            m_diaryPrintDoc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("PaperA4", 827, 1169);
            
            m_diaryPrintDoc.DefaultPageSettings.Landscape = false;
                       
            curPage = 0;

            PrintDialog pd = new PrintDialog();
            pd.Document = m_diaryPrintDoc;
            pd.AllowSomePages = true;
            pd.PrinterSettings.PrintRange = PrintRange.SomePages;
            pd.PrinterSettings.MaximumPage = m_diaryToPrint.PageCount;
            pd.PrinterSettings.MinimumPage = 1;
            pd.PrinterSettings.FromPage = pd.PrinterSettings.ToPage = currentPage+1;
            pd.UseEXDialog = true;
            Settings.Settings.SettingsHolder.PrinterName = pd.PrinterSettings.PrinterName;
            if (pd.ShowDialog() != DialogResult.OK)
            {
                Debug.Assert(false);
                return;
            }

            if (pd.PrinterSettings.PrintRange == PrintRange.AllPages)
            {
                m_firstPage = 0;
                m_lastPage = m_diaryToPrint.PageCount - 1;
            }
            else
            {
                m_firstPage = pd.PrinterSettings.FromPage-1;
                m_lastPage = pd.PrinterSettings.ToPage-1;
            }
            
            printDocumentSafely(m_diaryPrintDoc);
            
            m_diaryPrintDoc.PrintPage -= new PrintPageEventHandler(OnPrintDiaryPage);


        }

         private void OnPrintDiaryPage(object sender, PrintPageEventArgs ppea)
         {

             ppea.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
             ppea.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

             PrintDiaryPage(ppea.Graphics, m_firstPage);
             if (++m_firstPage <= m_lastPage)
             {
                 ppea.HasMorePages = true;
             }
             else
                 ppea.HasMorePages = false;

         }

         private void PrintDiaryPage(Graphics g, int page)
         {
             Debug.Assert(page<=m_diaryToPrint.PageCount);
             if (page>m_diaryToPrint.PageCount)
                 return;

             Record[] records = m_diaryToPrint.GetPage(page);
             Debug.Assert(records.Length >= 0);
             if (records.Length < 0)
                 return;

             g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
             //g.TextRenderingHin
             Font defaultTextFont = new Font("Times New Roman",12, FontStyle.Bold);
             Font mainTextFont = new Font("Times New Roman", 18, FontStyle.Bold);
             
             //Tisk razitka
             printStamp(g, 130, 6);

             g.ResetTransform();
             g.ScaleTransform((g.VisibleClipBounds.Width - 8) / 827,
                              (g.VisibleClipBounds.Height - 8) / 1169);  
             float width = (float)827;

             int[] colBorders = { 32, 50, 57, 55, 266, 83, 83, 101, 84};
             string[] colDescriptions = { "Poř.\nčíslo", "Datum", "Číslo\ndokladu", "Obsah zápisu", "Příjmy", 
                                    "Výdaje", "Zůstatek", "Poznámka"};

             Rectangle tableRect = new Rectangle(5, 80, 817, 1064);
             int tableHeader = 40;
             //g.ScaleTransform(g.VisibleClipBounds.Width/width , g.VisibleClipBounds.Height/height);

             g.DrawString(m_diaryToPrint.Name, mainTextFont, TextBrush, width / 2, 35, CenterCenterAlign);
             if (records.Length > 0)
             {
                 g.DrawString("Od: " + records[0].DateDiary + "   Do: " + records[records.Length - 1].DateDiary,
                                 defaultTextFont, TextBrush, width / 2, 60, CenterCenterAlign);
             }
             g.DrawString("Stránka: " + (page+1).ToString()+".  ",
                                         defaultTextFont, TextBrush, tableRect.Right-20, 35, RightCenterAlign);


             Brush borderBrush = new SolidBrush(Color.Black);
             Pen borderPen = new Pen(borderBrush, 3);
             Pen normalPen = new Pen(borderBrush, 1);

             g.DrawRectangle(borderPen, tableRect);
             g.DrawLine(borderPen, tableRect.Left, tableRect.Top + tableHeader, tableRect.Right, tableRect.Top+tableHeader);

             float rowHeight = (tableRect.Height-tableHeader)/(float)m_diaryToPrint.PageSize;
             int tableTop = tableHeader + tableRect.Top;
             for (int row = 1; row <= m_diaryToPrint.PageSize; row++)
             {
                 g.DrawLine(normalPen, tableRect.Left, row * rowHeight + tableTop, tableRect.Right,
                            row * rowHeight + tableTop);
             }
             int sumCol = tableRect.Left;

             Font tableHeaderFont = new Font("Times New Roman", 10, FontStyle.Bold);
             
             for (int colId = 1; colId < colBorders.Length; colId++)
             {
                 if (colId == colBorders.Length - 1)
                 {
                     colBorders[colId] = tableRect.Right - sumCol;
                     sumCol = tableRect.Right;
                 }
                 else
                     sumCol += colBorders[colId];
                 g.DrawLine(normalPen, sumCol, tableRect.Top, sumCol, tableRect.Bottom);
                 g.DrawString(colDescriptions[colId - 1], tableHeaderFont, TextBrush,
                            new RectangleF(sumCol - colBorders[colId], tableRect.Top, colBorders[colId], tableHeader),
                            CenterCenterAlign);
             }

             Font tableBodyFont = new Font("Courier New", 9, FontStyle.Bold);
             
             for (int row = 0; row < records.Length; row++)
             {
                 Record record = records[row];
                 string costIn = (record.Type==Record.RecordType.Income)?(MoneyConvertor.MoneyToStr(record.Cost) + ",-"):("");
                 string costOut = (record.Type == Record.RecordType.Expense) ? (MoneyConvertor.MoneyToStr(record.Cost) + ",-") : ("");
                 string remaining = MoneyConvertor.MoneyToStr(record.Remaining) + ",-";
                 string[] rowVals = { record.OverallID.ToString(), record.DateDiary, record.TypeID.ToString(),
                                       record.Content, costIn, costOut, remaining, record.Note};
                 StringFormat[] colFormats = { RightCenterAlign, RightCenterAlign, RightCenterAlign, LeftCenterAlign, RightCenterAlign, RightCenterAlign, RightCenterAlign, LeftCenterAlign, LeftCenterAlign };

                 sumCol = tableRect.Left;
                 float rowTop = tableRect.Top + tableHeader + row * rowHeight;
                 for (int colId = 1; colId < colBorders.Length; colId++)
                 {
                     if (colId == colBorders.Length - 1)
                     {
                         colBorders[colId] = tableRect.Right - sumCol;
                         sumCol = tableRect.Right;
                     }
                     else
                         sumCol += colBorders[colId];
                    // g.DrawLine(normalPen, sumCol, tableRect.Top, sumCol, tableRect.Bottom);
                     g.DrawString(rowVals[colId - 1], tableBodyFont, TextBrush,
                                new RectangleF(sumCol - colBorders[colId]+2, rowTop+2, colBorders[colId]-5, rowHeight),
                                colFormats[colId-1]);
                 }
             }

             g.DrawString(footerText, m_footerFont, TextBrush, (float)tableRect.Right - 10, (float)tableRect.Bottom + 15, RightCenterAlign);

         }

         private void DrawBackgroundAndSetGraphics(string BackgroundName, Graphics g, float yOffset, float width, float height)
         {
             g.ResetTransform();
             Bitmap im;
             float marginX = (float)(printDoc.DefaultPageSettings.HardMarginX);
             float marginY = (float)(printDoc.DefaultPageSettings.HardMarginY);
             try
             {
                 im = new Bitmap(BackgroundName);
             }
             catch
             {
                 throw new MissingMyFileException(BackgroundName);
             }

             /*if (m_isSizeCorrect)
                 g.DrawImage(im, -yOffset + g.VisibleClipBounds.Width - width, 0, width, height);
             else*/
                 g.DrawImage(im, -yOffset + g.VisibleClipBounds.Width/2 - width/2+marginX, 0, width-2*marginX, height-2*marginY);

             g.RotateTransform(90);

             if (m_isSizeCorrect)
                 g.TranslateTransform(0, -g.VisibleClipBounds.Height + yOffset + marginX);
             else
                 g.TranslateTransform(0, -g.VisibleClipBounds.Height / 2 - width / 2 + yOffset + marginX);
             // g.TranslateTransform(-g.VisibleClipBounds.Width+width, -g.VisibleClipBounds.Height + yOffset);

             g.ScaleTransform((height - 2 * marginY) / (float)im.Height,
                 (width - 2 * marginX) / (float)im.Width);
         }

         private void PrintOutcome(Graphics g, int yOffset, int width, int height)
         {
            DrawBackgroundAndSetGraphics(picturePath+"dokladstabulkou.bmp", g, yOffset, width, height);

            Font defaultTextFont = new Font("Courier New", 10, FontStyle.Bold);

            g.DrawString("Výdajový pokladní doklad", new Font("Courier New", 11, FontStyle.Bold), TextBrush, 
                        new Point(260, 15), LeftTopAlign);
            PrintCommon(g, yOffset, false, FormType.Outcome);            

            g.DrawString("Podpis pokladníka", defaultTextFont, TextBrush, new Point(85, 197), CenterTopAlign);
            g.DrawString("Podpis příjemce", defaultTextFont, TextBrush, new Point(250, 197), CenterTopAlign);

            g.DrawString(m_recToPrint.PayedTo, defaultTextFont, TextBrush, new Point(423, 180), CenterTopAlign);
            g.DrawString("Příjemce hotovosti", defaultTextFont, TextBrush, new Point(423, 197), CenterTopAlign);
            g.ResetTransform();
        }
        
        private void PrintIncome(Graphics g, int yOffset, int width, int height)
        {

            DrawBackgroundAndSetGraphics(picturePath+"Prijmovydokladstabulkou.bmp", g, yOffset, width, height);

            Font defaultTextFont = new Font("Courier New", 10, FontStyle.Bold);

            g.DrawString("Příjmový pokladní doklad", new Font("Courier New", 11, FontStyle.Bold),
                        TextBrush, new Point(260, 15), LeftTopAlign);
            PrintCommon(g, 0, false, FormType.Income);

            g.DrawString("Podpis pokladníka", defaultTextFont, TextBrush, new Point(423, 197), CenterTopAlign);

        }

        private void printIncomeReceipt(Graphics g, int yOffset, int width, int height)
        {
            DrawBackgroundAndSetGraphics(picturePath+"Stvrzenka.bmp", g, yOffset, width, height);
            
            Font defaultTextFont = new Font("Courier New", 10, FontStyle.Bold);

            g.DrawString("Stvrzenka", new Font("Courier New", 13, FontStyle.Bold), TextBrush,
                        new Point(260, 15+ yOffset), LeftTopAlign);
            PrintCommon(g, yOffset, true, FormType.Income);

            g.DrawString("Podpis pokladníka", defaultTextFont, TextBrush, new Point(423, 197+ yOffset), CenterTopAlign);
        }

        private void printStamp(Graphics g, float Xmiddle, float Ytop)
        {
            Font stampFont = new Font("Courier New", 7, FontStyle.Bold);

            string[] Stamp = Settings.Settings.SettingsHolder.Stamp;
            for (int i = 0; i < Math.Min(6, Stamp.Length); i++)
            {
                g.DrawString(Stamp[i], stampFont, TextBrush, new PointF(Xmiddle, Ytop+((6-Math.Min(Stamp.Length,6))/(float)2+i)*11), CenterTopAlign);
            }
        }

        private void PrintCommon(Graphics g, int yOffset, bool onlyUpper, FormType formType)
        {
            Font defaultTextFont = new Font("Courier New", 9, FontStyle.Bold);
            printStamp(g, 130, 11);
            //Font stampFont = new Font("Courier New", 7, FontStyle.Bold);

            //string[] Stamp = Settings.Settings.SettingsHolder.Stamp;
            //for (int i = 0; i < Math.Min(6, Stamp.Length); i++)
            //{
            //    g.DrawString(Stamp[i], stampFont, TextBrush, new PointF(130, 11+((6-Math.Min(Stamp.Length,6))/(float)2+i)*11), CenterTopAlign);
            //}

            g.DrawString("číslo " + m_recToPrint.TypeID.ToString()+m_recToPrint.NoteToNumber, defaultTextFont, TextBrush, new Point(260, 45), LeftTopAlign);
            g.DrawString("ze dne " + m_recToPrint.Date, defaultTextFont, TextBrush, new Point(260, 60), LeftTopAlign);

            if (formType == FormType.Income)
            {
                g.DrawString("Přijato od: " + m_recToPrint.CustName, defaultTextFont, TextBrush, new Point(10, 88), LeftTopAlign);
            }
            else
            {
                g.DrawString("Vyplaceno: " + m_recToPrint.CustName, defaultTextFont, TextBrush, new Point(10, 88), LeftTopAlign);
            }
            g.DrawString("Částka: " + MoneyConvertor.MoneyToStr(m_recToPrint.Cost) + ",00 Kč", new Font("Courier New", 11, FontStyle.Bold), 
                            TextBrush, new Point(10, 105), LeftTopAlign);

            string castkaSlovy = "Slovy: " + "=" + NumberConvertor.ConvertIntToWord((int)m_recToPrint.Cost) + " Kč=";
            g.DrawString(castkaSlovy, defaultTextFont, TextBrush, new Point(10, 125), LeftTopAlign);
            g.DrawString("Účel platby: " + m_recToPrint.Content, defaultTextFont, TextBrush, new Point(10, 142), LeftTopAlign);

            if (!onlyUpper)
            {
                g.DrawString("Text", defaultTextFont, TextBrush, new Point(70, 224), CenterCenterAlign);
                g.DrawString("Účt. předpis (Má dáti-účet)", defaultTextFont, TextBrush, new Point(255, 224), CenterCenterAlign);
                g.DrawString("Kč", defaultTextFont, TextBrush, new Point(437, 224), CenterCenterAlign);

                g.DrawString("Schválil:", defaultTextFont, TextBrush, new Point(10, 317), LeftCenterAlign);
                g.DrawString("Zaúčtoval:", defaultTextFont, TextBrush, new Point(195, 317), LeftCenterAlign);
                g.DrawString("Dne: ", defaultTextFont, TextBrush, new Point(383, 317), LeftCenterAlign);
            }

            g.DrawString(footerText, m_footerFont, TextBrush, 500, 325, RightTopAlign);
        }

        private SizeF paperA6PrintSize
        {
            get
            {
                SizeF size = new SizeF(PaperA6.Width, PaperA6.Height);
                size.Width -= 5;// +2 * printDoc.DefaultPageSettings.HardMarginX / 100f;
                //size.Height;// -= 2 * printDoc.DefaultPageSettings.HardMarginY / 100f;

                return size;
            }
        }

        private void OnPrintOutcome(object sender, PrintPageEventArgs ppea)
        {
            PrintOutcome(ppea.Graphics, -5, (int)paperA6PrintSize.Width, (int)paperA6PrintSize.Height);
        }

        private void OnPrintOutcomeTwiceTwo(object sender, PrintPageEventArgs ppea)
        {
            //todo nejak lepe udelat pocitani stranek
            PrintOutcome(ppea.Graphics, -5, (int)paperA6PrintSize.Width, (int)paperA6PrintSize.Height);
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
                PrintIncome(ppea.Graphics, -5, (int)paperA6PrintSize.Width, (int)paperA6PrintSize.Height);
            }
            else
                printIncomeReceipt(ppea.Graphics, -5, (int)paperA6PrintSize.Width, (int)paperA6PrintSize.Height);
        }

        private void printDocumentSafely(PrintDocument pd)
        {
            try { pd.Print(); }
            catch (Exception e)
            {
                InvalidPrinterException ipe = e as InvalidPrinterException;
                if (ipe != null)
                {
                    MessageBox.Show("Na uloženou tiskárnu není možno tisknout. Zvolte jinou.");
                    return;
                }
                ExceptionWithMessageBox em = e as ExceptionWithMessageBox;
                if (em != null) 
                {                    
                    em.ShowMessage();
                    return;
                }
                MessageBox.Show("Došlo k neznámé chybě při tisku.");
            }
        }

        private void prepareDocumentA6(PrintDocument pd)
        {
            printDoc.DocumentName = "Tisk dokladu...";
            //printDoc.PrinterSettings.PaperSizes
            m_isSizeCorrect = false;
            foreach (PaperSize ps in printDoc.PrinterSettings.PaperSizes)
                if (ps.Width == PaperA6.Width && ps.Height == PaperA6.Height)
                {
                    m_isSizeCorrect = true;
                    break;
                }
            if (m_isSizeCorrect)
                printDoc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("PaperA6", PaperA6.Width, PaperA6.Height);
            else
                printDoc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("PaperA6", 827, 1169);

            printDoc.DefaultPageSettings.Landscape = false;
        }

        private void prepareDocumentA4(PrintDocument pd)
        {
            printDoc.DocumentName = "Tisk dokladu...";
            printDoc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("PaperA4", 827, 1169);
            printDoc.DefaultPageSettings.Landscape = false;
        }

    }

}