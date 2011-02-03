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
        private string mainHeader = "Pokladní deník 2.0";

        private const int pageSize = 50;

        private Diary m_mainDiary;
        private int m_currentPage = 0; //TODO zapouzdrit
        private int contextMenuRowIndex = 0;
        
        
        public MainForm()
        {
            InitializeComponent();

            Settings.Storage.init(settingsFile);
            gridHistory.Rows.Add(pageSize);
            foreach (DataGridViewColumn column in gridHistory.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            

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
            if (recordId / pageSize < m_mainDiary.PageCount && recordId % pageSize >= 0)
            {
                setPage(recordId / pageSize);
                gridHistory.CurrentCell = gridHistory[0, recordId % pageSize];
            }
        }

        private void initRecord(ref Record record)
        {
            DateTime dt = DateTime.Today.Date;
            record.Date = DateTime.Today.Date.ToString("d/M.");
            record.NoteToNumber = m_mainDiary.NoteToNumber;
        }

        private void UpdateCurrentPage()
        {
            if (m_currentPage >= m_mainDiary.PageCount)
                m_currentPage = m_mainDiary.PageCount - 1;
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
                    cells[5] = MoneyConvertor.MoneyToStr(records[i].Cost)+",-";
                }
                else
                {
                    cells[5] = "";
                    cells[4] = MoneyConvertor.MoneyToStr(records[i].Cost) + ",-";
                }
                cells[6] = MoneyConvertor.MoneyToStr(records[i].Remaining) + ",-";
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
                dlg.InitialDirectory = Settings.Settings.SettingsHolder.DiaryDirectory; //todo
                dlg.Filter = "Deníky (*.pkl)|*.pkl";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    newDiary = Diary.Load(dlg.FileName);
                }
            }
            catch
            {
                MessageBox.Show("Zadaný deník se nepodařilo otevřít.", "Chyba");
                return;
            }

            if (newDiary != null)
                m_mainDiary.Clone(newDiary);

            EnsureRecordVisibility(m_mainDiary.RecordsCount - 1);
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
            if (m_mainDiary == null)//should not happen!!!
            {
                Debug.Assert(false, "Tohle se nemelo stat.");
                return;
            }
            Settings.Settings.SettingsHolder.DiaryDirectory = m_mainDiary.Directory;
            Settings.Settings.SettingsHolder.MainWindowPos = this.Bounds;

            Settings.Settings.Store();

            //Storage.addString("Directory", m_mainDiary.Directory);
           // Storage.push();

        }

        private void LoadSettings()
        {
            //string directory = Storage.readString("Directory");
            Settings.Settings.Load();
            Rectangle winRec = Settings.Settings.SettingsHolder.MainWindowPos;
            Screen scr = Screen.FromRectangle(winRec);
            Rectangle monitorBounds = scr.Bounds;

            Diary newDiary = null;

            if (monitorBounds.IntersectsWith(winRec) && winRec.Width > 100 && winRec.Height > 100)
                this.Bounds = winRec;

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

                if (Settings.Settings.SettingsHolder.DiaryDirectory == "")
                {
                    initFailureForm fform = new initFailureForm();
                    fform.ShowDialog();
                    if (fform.Result == initFailureForm.InitFailureResults.Cancel)
                    {
                        Application.Exit();    //todo lepeji ukoncit!!
                        return;
                    }
                    else if (fform.Result == initFailureForm.InitFailureResults.Open)
                    {
                        OpenFileDialog dlg = new OpenFileDialog();
                        dlg.InitialDirectory = Settings.Settings.SettingsHolder.DiaryDirectory; //todo
                        dlg.Filter = "Deníky (*.pkl)|*.pkl";
                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            Settings.Settings.SettingsHolder.DiaryDirectory = dlg.FileName;
                        }
                    }
                    else
                    {
                        tryCreateNewDiary();
                    }
                }
                try
                {
                    newDiary = Diary.Load(Settings.Settings.SettingsHolder.DiaryDirectory);
                }
                catch
                {
                    MessageBox.Show("Zadaný deník se nepodařilo otevřít.", "Chyba");
                    Settings.Settings.SettingsHolder.DiaryDirectory = "";
                }
            } while (Settings.Settings.SettingsHolder.DiaryDirectory == "");

            m_mainDiary.Clone(newDiary);
            EnsureRecordVisibility(m_mainDiary.RecordsCount - 1);

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
            initRecord(ref newRecord);
            
            newRecord.TypeID = m_mainDiary.TypeCounts[(int)Record.RecordType.Income]+1;
            incomeForm iform = new incomeForm(newRecord);
            iform.ShowDialog();
            if (iform.Result != inoutParentForm.InOutFormResult.Cancel)
            {
                m_mainDiary.AppendRecord(newRecord);
                EnsureRecordVisibility(m_mainDiary.RecordsCount - 1);
                UpdateCurrentPage();
            }
                        
        }

        private void btnExpense_Click(object sender, EventArgs e)
        {
            Record newRecord = new Record();    //todo kdo nastavi defaulty?
            initRecord(ref newRecord);
            
            newRecord.TypeID = m_mainDiary.TypeCounts[(int)Record.RecordType.Expense] + 1;

            outcomeForm oform = new outcomeForm(newRecord);
            oform.ShowDialog();
            if (oform.Result != inoutParentForm.InOutFormResult.Cancel)
            {
                m_mainDiary.AppendRecord(newRecord);
                EnsureRecordVisibility(m_mainDiary.RecordsCount - 1);
                UpdateCurrentPage();
            }
        }

        private void gridHistory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int curRecord = e.RowIndex+pageSize*m_currentPage;
            editRecord(curRecord);
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
            ds.ShowDialog(this);

            m_mainDiary.UpdateRecords();
            m_mainDiary.StoreChanges();
            UpdateCurrentPage();
        }

        private void nasteveníRazítkaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StampForm sf = new StampForm();
            sf.ShowDialog();
        }

        private void nastaveníDoplňováníToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutocompleteSettingsForm acsf = new AutocompleteSettingsForm();

            acsf.ShowDialog();
        }

        private void změnitJménoDeníkuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveDialogDiary.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    m_mainDiary.Directory = saveDialogDiary.FileName;
                    Settings.Settings.SettingsHolder.DiaryDirectory = saveDialogDiary.FileName;
                }
                catch
                {
                    MessageBox.Show("Deník se nepodařilo přesunout.", "Chyba!", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                }
            }
        }

        //Try to create new item, returns null if unsuccesful, sets Setting.DiaryDirectory
        private Diary tryCreateNewDiary()
        {
            Diary newDiary = new Diary();
            string directory = "";

            DiarySettings fds = new DiarySettings(newDiary);
            fds.ShowDialog();
            if (fds.DialogResult == DialogResult.OK)
            {
                if (saveDialogDiary.ShowDialog() == DialogResult.OK)
                {
                    directory = saveDialogDiary.FileName;
                    newDiary.Directory = directory;
                }

            }

            try
            {
                newDiary = Diary.Load(directory);
            }
            catch
            {
                return null;
            }

            Settings.Settings.SettingsHolder.DiaryDirectory = directory;
            return newDiary;
        }

        private void vytvořitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Diary newDiary = tryCreateNewDiary();
            if (newDiary != null)
            {
                m_mainDiary.Clone(newDiary);
                EnsureRecordVisibility(m_mainDiary.RecordsCount - 1);
                UpdateCurrentPage();
            }
        }

        private void editRecord(object o, EventArgs es)
        {
            editRecord(contextMenuRowIndex);
        }

        private void editRecord(int recordID)
        {
            if (recordID < 0 || m_mainDiary.RecordsCount <= recordID)
                return;

            Record recordToChange = m_mainDiary.GetRecord(recordID);
            if (recordToChange == null)
                return;

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
            if (form.Result != inoutParentForm.InOutFormResult.Cancel)
            {
                m_mainDiary.ReplaceRecord(recordID, recordToChange);
            }

            UpdateCurrentPage();
        }

        private void removeRecord(object o, EventArgs ea)
        {
            if (MessageBox.Show("Opravdu si přejete vymazat vzbraný doklad?", "Pozor!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
                DialogResult.No)
                return;
            m_mainDiary.RemoveRecord(contextMenuRowIndex);
            UpdateCurrentPage();
        }

        private void insertOutcomeForm(object o, EventArgs ea)
        {
            Record newRecord = new Record();
            initRecord(ref  newRecord);

            int curRecord = contextMenuRowIndex;
            int curNumber = -1;
            while (curRecord >= 0)
            {
                Record rec = m_mainDiary.GetRecord(curRecord);
                if (rec.Type == Record.RecordType.Expense)
                {
                    curNumber = rec.TypeID;
                    break;
                }
                curRecord--;
            }
            if (curNumber == -1)
                curNumber = m_mainDiary.InitTypeCounts[(int)Record.RecordType.Expense] + 1;
            newRecord.TypeID = curNumber+1;

            outcomeForm oForm = new outcomeForm(newRecord);
            oForm.ShowDialog();
            if (oForm.Result == inoutParentForm.InOutFormResult.OK)
                m_mainDiary.InsertRecord(contextMenuRowIndex, newRecord);

            UpdateCurrentPage();
        }

        private void insertIncomeForm(object o, EventArgs ea)
        {
            Record newRecord = new Record();
            initRecord(ref newRecord);

            int curRecord = contextMenuRowIndex-1;
            int curNumber = -1;
            while (curRecord >= 0)
            {
                Record rec = m_mainDiary.GetRecord(curRecord);
                if (rec.Type == Record.RecordType.Income)
                {
                    curNumber = rec.TypeID;
                    break;
                }
                curRecord--;
            }
            if (curNumber == -1)
                curNumber = m_mainDiary.InitTypeCounts[(int)Record.RecordType.Income]+1;
            newRecord.TypeID = curNumber+1;

            incomeForm iForm = new incomeForm(newRecord);
            iForm.ShowDialog();
            if (iForm.Result == inoutParentForm.InOutFormResult.OK)
                m_mainDiary.InsertRecord(contextMenuRowIndex, newRecord);

            UpdateCurrentPage();
        }
        
        private void gridHistory_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int curRecord = e.RowIndex + pageSize * m_currentPage;
                Record[] recordsToChange = m_mainDiary.GetPage(m_currentPage);
                if (e.RowIndex < 0 || recordsToChange.Length <= e.RowIndex)
                    return;

                gridHistory.ClearSelection();
                gridHistory.Rows[e.RowIndex].Selected = true;
                contextMenuRowIndex = curRecord;

                DataGridView grid = sender as DataGridView;
                ContextMenuStrip menu = new ContextMenuStrip();
                
                //menu.Items.Add("Task1", null, new EventHandler(Task1_Click));
                menu.Items.Add("Upravit doklad", null, new EventHandler(editRecord));
                menu.Items.Add("Vložit příjmový doklad", null, new EventHandler(insertIncomeForm));
                menu.Items.Add("Vložit výdajový doklad", null, new EventHandler(insertOutcomeForm));
                menu.Items.Add(new ToolStripSeparator());
                menu.Items.Add("Odstranit doklad", null, new EventHandler(removeRecord));
                Point pt = grid.PointToClient(Control.MousePosition);
                menu.Show(gridHistory, pt.X, pt.Y);
            }
        }

        private void OnNameChanged(string oldName, string newName)
        {
            this.Text = mainHeader + " - " + newName;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            m_mainDiary = new Diary();
            m_mainDiary.PageSize = pageSize;
            m_mainDiary.onNameChanged += new Diary.OnDiaryNameChanged(OnNameChanged);

            LoadSettings();

            if (m_mainDiary != null) // todo tohle by nemelo byt nutne pokud to predtim poradne ukoncim
                EnsureRecordVisibility(m_mainDiary.RecordsCount - 1);
        }

        private void MainForm_Move(object sender, EventArgs e)
        {
            //Point loc = global::Denik.Properties.Settings.Default.MainWindowPosition;
        }

        private void tiskDeníkuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Printer printer = new Printer();
            printer.PrintDiary(m_mainDiary, m_currentPage); //todo pridat current page
        }

    }
    
}
