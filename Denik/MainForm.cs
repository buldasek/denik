using System;
using System.Drawing;
using System.Xml;
using System.Windows.Forms;
using Settings;
using System.Diagnostics;


namespace Denik
{
    public partial class MainForm : Form
    {
        private string settingsFile = "settings.xml";

        private const int pageSize = 49;

        private Diary m_mainDiary;
        private int m_currentPage = 0; //TODO zapouzdrit
        
        
        public MainForm()
        {
            InitializeComponent();

            Settings.Storage.init(settingsFile);
            gridHistory.Rows.Add(pageSize);

            //Printer printer = new Printer();
            //printer.print();
        }

        public void setPage(int pageId)
        {
            if (pageId >= m_mainDiary.PageCount || pageId < 0)
            {
                UpdateCurrentPage();
                return;
            }

            m_currentPage = pageId;
            UpdateCurrentPage();
        }

        public void setNextPage()
        {
            setPage(m_currentPage + 1);
        }
        
        public void setPrevPage()
        {
            setPage(m_currentPage - 1);
        }

        private void ClearGrid()
        {
           // gridHistory.
            for (int row = 0; row < gridHistory.Rows.Count; row++)
                for (int col = 0; col < gridHistory.Rows[row].Cells.Count; col++)
                    gridHistory.Rows[row].Cells[col].Value = "";
        }

        private void EnsureRecordVisibility(int recordId)
        {
            if (recordId / pageSize < m_mainDiary.PageCount && recordId / pageSize >= 0)
            {
                setPage(recordId / pageSize);
                gridHistory.CurrentCell = gridHistory[0, recordId % pageSize];
            }


        }

        private void UpdateCurrentPage()
        {
            lbPageId.Text = "Stránka " + (m_currentPage+1).ToString() + ".";
            Record[] records = m_mainDiary.GetPage(m_currentPage);
            ClearGrid();
            String [] cells = new String[8];
            
            for (int i = 0; i < records.Length && records[i]!=null; i++)
            {
                /*
                gridHistory.Rows[i].Cells[0].Value = records[i].OverallID.ToString();
                gridHistory.Rows[i].Cells[1].Value = records[i].Date;
                gridHistory.Rows[i].Cells[2].Value = records[i].TypeID.ToString();
                gridHistory.Rows[i].Cells[3].Value = records[i].Content;
                if (records[i].Type == Record.RecordType.Expense)
                {
                    gridHistory.Rows[i].Cells[4].Value = "";
                    gridHistory.Rows[i].Cells[5].Value = records[i].Cost.ToString();
                }
                else
                {
                    gridHistory.Rows[i].Cells[5].Value = "";
                    gridHistory.Rows[i].Cells[4].Value = records[i].Cost.ToString();
                }
                gridHistory.Rows[i].Cells[6].Value = records[i].Remaining.ToString();
                gridHistory.Rows[i].Cells[7].Value = records[i].Note;*/
                cells[0] = records[i].OverallID.ToString();
                cells[1] = records[i].Date;
                cells[2] = records[i].TypeID.ToString();
                cells[3] = records[i].Content;
                if (records[i].Type == Record.RecordType.Expense)
                {
                    cells[4] = "";
                    cells[5] = records[i].Cost.ToString();
                }
                else
                {
                    cells[5] = "";
                    cells[4] = records[i].Cost.ToString();
                }
                cells[6] = records[i].Remaining.ToString();
                cells[7] = records[i].Note;

                //for (int j=0; j<8; j++)
                //    dataSource[i*8+j] = cells[j];
                if (records[i].Remaining > m_mainDiary.RemainLimit)
                {
                    for (int j = 0; j < gridHistory.Rows[i].Cells.Count; j++)
                        gridHistory.Rows[i].Cells[j].Style.ForeColor = Color.Red;
                }
                else if (records[i].Remaining > m_mainDiary.RemainWarning)
                {
                    for (int j = 0; j < gridHistory.Rows[i].Cells.Count; j++)
                        gridHistory.Rows[i].Cells[j].Style.ForeColor = Color.Blue;
                }
                else 
                {
                    for (int j = 0; j < gridHistory.Rows[i].Cells.Count; j++)
                        gridHistory.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                }
                gridHistory.Rows[i].SetValues(cells);
            }
            
            //gridHistory.DataSource = dataSource;
        }

        private void LoadDiary()
        {
            Diary newDiary = null; 
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.InitialDirectory = Application.StartupPath; //todo
                dlg.Filter = "Deníky (*.pkl)|*.pkl";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    newDiary = new Diary(dlg.FileName);
                }
            }
            catch
            {
                MessageBox.Show("Zadaný deník se nepodařilo otevřít.", "Chyba");
                return;
            }

            if (newDiary != null)
                m_mainDiary = newDiary;

            UpdateCurrentPage();
        }

        private void StoreSettings()
        {
            /*try
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = ("    ");
                using (XmlWriter writer = XmlWriter.Create(settingsFile, settings))
                {
                    writer.WriteStartElement("DiarySettings");
                    writer.WriteElementString("Directory", m_mainDiary.Directory);
                    writer.WriteEndElement();
                    writer.Flush();
                }
            }
            catch {} // neni to tak dulezite, jen maskuju ze se to nepovedlo
             */
            if (m_mainDiary == null)
                return;
            Settings.Settings.Store();

            //Storage.addString("Directory", m_mainDiary.Directory);
           // Storage.push();

        }

        private void LoadSettings()
        {
            //string directory = Storage.readString("Directory");
            Settings.Settings.Load();
            /* string directory = "";*/

             do
             {
               /*  directory = "";

                 try
                 {
                     XmlReaderSettings settings = new XmlReaderSettings();
                     using (XmlReader reader = XmlReader.Create(settingsFile, settings))
                     {
                         reader.ReadStartElement("DiarySettings");
                         directory = reader.ReadElementString("Directory");
                         reader.ReadEndElement();
                     }
                 }
                 catch { }*/

                 if (Settings.Settings.DiaryDirectory == "")
                 {
                     initFailureForm fform = new initFailureForm();
                     if (fform.ShowDialog() == DialogResult.Cancel)
                     {
                         Application.Exit();    //todo lepeji ukoncit!!
                         return;
                     }
                     else if (fform.DialogResult == DialogResult.Retry)
                     {
                         OpenFileDialog dlg = new OpenFileDialog();
                         dlg.InitialDirectory = Application.StartupPath; //todo
                         dlg.Filter = "Deníky (*.pkl)|*.pkl";
                         if (dlg.ShowDialog() == DialogResult.OK)
                         {
                             Settings.Settings.DiaryDirectory = dlg.FileName;
                         }
                     }
                     else
                     {
                         // todo new denik
                     }
                 }
                 try
                 {
                     m_mainDiary = new Diary(Settings.Settings.DiaryDirectory);
                 }
                 catch
                 {
                     MessageBox.Show("Zadaný deník se nepodařilo otevřít.", "Chyba");
                     Settings.Settings.DiaryDirectory = "";
                 }
             } while (Settings.Settings.DiaryDirectory == "");
            m_mainDiary.SetPageSize(pageSize);
            
            UpdateCurrentPage();
        }


        private void gridHistory_Click(object sender, EventArgs e)
        {
         //   m_mainDiary = new Diary("d:/ProjektyZS/Denik/data/rok2010.pkl");
         //   Record[] records = m_mainDiary.GetPage(2);


         ////   gridHistory.Rows.Add();
         //   gridHistory.Rows[gridHistory.Rows.Count - 1].Cells[5].Value = "999.924,12";//gridHistory.Rows.Count.ToString();
         //   try
         //   {
         //       Diary diary = new Diary();
         //   }
         //   catch
         //   {
         //       MessageBox.Show("asdf");
         //   }

        }

        private void konecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StoreSettings();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            LoadSettings();
            if (m_mainDiary!=null) // todo tohle by nemelo byt nutne pokud to predtim poradne ukoncim
                EnsureRecordVisibility(m_mainDiary.RecordsCount - 1);
        }

        private void otevřítDeníkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadDiary();
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            setPrevPage();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            setNextPage();
        }

        private void btnIncome_Click(object sender, EventArgs e)
        {
            Record newRecord = new Record();    //todo kdo nastavi defaulty?
            incomeForm iform = new incomeForm(newRecord);
            iform.ShowDialog();
            if (iform.DialogResult == DialogResult.OK)
            {
                m_mainDiary.AppendRecord(newRecord);
                EnsureRecordVisibility(m_mainDiary.RecordsCount - 1);
            }
        }

        private void btnExpense_Click(object sender, EventArgs e)
        {
            Record newRecord = new Record();    //todo kdo nastavi defaulty?

            outcomeForm oform = new outcomeForm(newRecord);
            oform.ShowDialog();
            if (oform.DialogResult == DialogResult.OK)
            {
                m_mainDiary.AppendRecord(newRecord);
                EnsureRecordVisibility(m_mainDiary.RecordsCount - 1);
            }
        }

        private void gridHistory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int curRecord = e.RowIndex+pageSize*m_currentPage;
            Record recordToChange = m_mainDiary.GetPage(m_currentPage)[e.RowIndex];

            inoutParentForm form;
            if (recordToChange.Type == Record.RecordType.Income)
            {
                form = new incomeForm(recordToChange);
            }
            else
            {
                form = new outcomeForm(recordToChange);
            }

            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                m_mainDiary.ReplaceRecord(recordToChange, curRecord);
            }
        }

        private void printerSettings_Click(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            pd.Document = inoutParentForm.printer.printDoc;
            pd.ShowDialog();
        }

        private void nastaveníDeníkuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DiarySettings ds = new DiarySettings(m_mainDiary);
            ds.ShowDialog();

            m_mainDiary.UpdateRecords();
            UpdateCurrentPage();
        }

        private void nasteveníRazítkaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StampForm sf = new StampForm();
            sf.ShowDialog();
        }

    }
    
}
