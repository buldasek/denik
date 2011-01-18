using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace Denik
{

    public class Record
    {
        public const int TypeCount = 2;
        public enum RecordType {
            Income = 0, Expense = 1 ,
        };
        
        private int m_overallID;
        private int m_typeID;
        private RecordType m_type;
        private Int64 m_cost;
        private String m_note;
        private String m_content;
        private Int64 m_remaining;
        private String m_date;
        private String m_payedTo;
        private String m_custName;
        private String m_noteToNumber;

        public Record()
        {
            m_overallID = 0;
            m_date = "";
            m_typeID = 0;
            m_type = RecordType.Income;
            m_cost = 0;
            m_content = "";
            m_cost = 0;
            m_remaining = 0;
            m_note = "";
            m_payedTo = "";
            m_custName = "";
            m_noteToNumber = "";
        }

        public Record(int overallID, String date, int typeID, RecordType type, int cost, String content,
                        int remaining, String note, String payedTo, String custName
                        , String noteToNumber)
        {
            m_overallID = overallID;
            m_date = date;
            m_typeID = typeID;
            m_type = type;
            m_cost = cost;
            m_content = content;
            m_cost = cost;
            m_remaining = remaining;
            m_note = note;
            m_payedTo = payedTo;
            m_custName = custName;
            m_noteToNumber = noteToNumber;
        }

        public Record(Record rec)
        {
            m_overallID = rec.OverallID;
            m_date = rec.Date;
            m_typeID = rec.TypeID;
            m_type = rec.Type;
            m_cost = rec.Cost;
            m_content = rec.Content;
            m_cost = rec.Cost;
            m_remaining = rec.Remaining;
            m_note = rec.Note;
            m_payedTo = rec.PayedTo;
            m_custName = rec.CustName;
            m_noteToNumber = rec.NoteToNumber;
        }


        public int OverallID { set { m_overallID = value; } get { return m_overallID; } }
        public String Date { set { m_date = value; } get { return m_date; } }
        public int TypeID { set { m_typeID = value; } get { return m_typeID; } }
        public RecordType Type { set { m_type = value; } get { return m_type; } }
        public Int64 Cost { set { m_cost = value; } get { return m_cost; } }
        public String Note { set { m_note = value; } get { return m_note; } }
        public String Content { set { m_content = value; } get { return m_content; } }
        public Int64 Remaining { set { m_remaining = value; } get { return m_remaining; } }
        public String PayedTo { set { m_payedTo = value; } get { return m_payedTo; } }
        public String CustName { set { m_custName = value; } get { return m_custName; } }
        public String NoteToNumber { set { m_noteToNumber = value; } get { return m_noteToNumber; } }
 

        public override String ToString()
        {
            String result =
                OverallID.ToString() + "\n" +
                TypeID.ToString() + "\n" +
                (Cost*10).ToString() + "\n" +
                (Remaining*10).ToString() + "\n" +
                ((int)Type).ToString() + "\n" +
                Date + "\n" +
                Date + "\n" +        //todo ???
                NoteToNumber + "\n" +           //todo ???
                CustName + "\n" +
                Content + "\n" +
                Note + "\n" +
                PayedTo + "\n";

            return result;
        }

        public void FromString(String str)
        {
            String[] words = str.Split('\n');
            OverallID = int.Parse(words[0]);
            TypeID = int.Parse(words[1]);
            Cost = int.Parse(words[2]) / 10;
            Remaining = int.Parse(words[3]) / 10;
            Type = (Record.RecordType)(int.Parse(words[4]));
            Date = words[5];
            NoteToNumber = words[7];
            CustName = words[8];
            Content = words[9];
            Note = words[10];
            PayedTo = words[11];
        }

    }

    public class Diary
    {
        private string m_name;
        private string m_dir;

        private int[] m_typeInitCounts = new int[Record.TypeCount];
        private int[] m_typeCounts = new int[Record.TypeCount];
        private int m_initRemain;
        private int m_remainWarning;
        private int m_remainLimit;

        private List<Record> m_records = new List<Record>();

        public Diary()
        {
            for (int i = 0; i < Record.TypeCount; i++)
            {
                InitTypeCounts[i] = 0;
                TypeCounts[i] = 0;
            }

            InitRemain = 0;
            RemainWarning = 30000;
            RemainLimit = 35000;
            Name = "Nový deník";
            NoteToNumber = "";
        }

       //public Diary(String directory)
        //{
            
            //m_dir = directory;
            
        //}

        public String Name { set { m_name = value; } get { return m_name; } }
        public int RemainWarning { set { m_remainWarning = value; } get { return m_remainWarning; } }
        public int RemainLimit { set { m_remainLimit = value; } get { return m_remainLimit; } }
        public int InitRemain { set { m_initRemain = value; } get { return m_initRemain; } }

        public int[] TypeCounts { get { return m_typeCounts; } set { m_typeCounts = (int[])value.Clone(); } }
        public int[] InitTypeCounts { get { return m_typeInitCounts; } set { m_typeInitCounts = (int[])value.Clone(); } }
        public string NoteToNumber { set; get; }

        //just for serialization, should not be used directly, does not ensure update
        public Record[] Records { set { m_records = new List<Record>(value); } get { return m_records.ToArray(); } }

        public void UpdateRecords()
        {
            for (int i = 0; i < Record.TypeCount; i++)
                m_typeCounts[i] = m_typeInitCounts[i];

            Int64 remain = m_initRemain;
            for (int i=0; i<m_records.Count; i++)
            {
                if (m_records[i].Type == Record.RecordType.Income)
                {
                    m_records[i].TypeID = ++m_typeCounts[(int)m_records[i].Type];
                    remain += m_records[i].Cost;
                }
                else
                {
                    m_records[i].TypeID = ++m_typeCounts[(int)m_records[i].Type];
                    remain -= m_records[i].Cost;
                }
                m_records[i].Remaining = remain;
            
                int overallID = 0;
                for (int j = 0; j < Record.TypeCount; j++)
                    overallID += m_typeCounts[j];

                m_records[i].OverallID = overallID;
            }
        }

        public void AppendRecordNoUpdate(Record newRecord)
        {
            m_records.Add(newRecord);
        }

        public void AppendRecord(Record newRecord)
        {
            AppendRecordNoUpdate(newRecord);
            UpdateInfoFromRecord(newRecord);
            UpdateRecords();
            if (Records[Records.Length - 1].Remaining > RemainLimit)
                MessageBox.Show("Překročen limit pokladny!", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (Records[Records.Length - 1].Remaining > RemainWarning)
                MessageBox.Show("Blížíte se k limitu!", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            Store(Directory);
            /*
            newRecord.OverallID = m_typeCounts[0] + m_typeCounts[1]-1;
            newRecord.TypeID = m_typeCounts[(int)newRecord.Type]++;
            Int64 remain = m_initRemain;
           
            if (newRecord.Type == Record.RecordType.Income)
                remain+= newRecord.Cost;
            else
                remain-= newRecord.Cost;
            foreach (Record rec in m_records)
                if (rec.Type == Record.RecordType.Income)
                    remain += rec.Cost;
                else
                    remain -= rec.Cost;

            newRecord.Remaining = remain;
            
            m_records.Add(newRecord);*/
        }

        public void ReplaceRecord(int pos, Record newRecord)
        {
            Debug.Assert(pos < RecordsCount);
            if (pos >= RecordsCount)
                return;

            m_records[pos] = newRecord;

            UpdateInfoFromRecord(newRecord);
            UpdateRecords();
            Store(Directory);
        }

        public void InsertRecord(int pos, Record record)
        {
            Debug.Assert(pos >= 0 && pos < RecordsCount);
            if (pos > RecordsCount || pos < 0)
                return;

            m_records.Insert(pos, record);

            UpdateInfoFromRecord(record);
            UpdateRecords();
            Store(Directory);
        }

        public void RemoveRecord(int pos)
        {
            Debug.Assert(pos >= 0 && pos < RecordsCount);
            if (pos >= RecordsCount || pos <0)
                return;

            m_records.RemoveAt(pos);

            UpdateRecords();
            Store(Directory);
        }

        public int RecordsCount
        {
            get
            {
                return m_records.Count;
            }
        }

        public String Directory
        {
            set
            {
                String NewDirectory = value;
                try
                {
                    Store(NewDirectory);
                }
                catch
                {
                    return;
                }
                m_dir = NewDirectory;
            }

            get { return m_dir; }
        }

        public Record GetRecord(int index)
        {
            Debug.Assert(index >= 0 && index < RecordsCount);
            if (index >= 0 && index < RecordsCount)
                return m_records[index];

            if (m_records.Count == 0)
                return null;

            return m_records[0];
        }

        public Record[] GetPage(int pageID)
        {
            List<Record> result = new List<Record>();
            if (pageID * PageSize > m_records.Count || pageID < 0)
                throw new Exception();

            for (int i = 0; i < PageSize; i++)
            {
                if (i + pageID * PageSize >= m_records.Count)
                    break;
                result.Add(m_records[pageID * PageSize + i]);
            }

            return result.ToArray();
        }

        public int PageSize
        {
            set ; get;
        }

        public int PageCount
        {
            get { return (Math.Max(m_records.Count - 1, 0)) / PageSize + 1; }
        }

        public override String ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(m_records.Count.ToString() + "\n" +
                          m_typeInitCounts[0].ToString() + "\n" +
                          m_typeInitCounts[1].ToString() + "\n" +
                          m_initRemain.ToString() + "\n" +
                          Name + "\n" +
                          RemainWarning.ToString() + "\n" +
                          RemainLimit.ToString());

            result.Append("\n");
            for (int i = 0; i < m_records.Count; i++)
            {
                result.Append(m_records[i].ToString());
            }

            return result.ToString();
        }

        private void UpdateInfoFromRecord(Record record)
        {
            NoteToNumber = record.NoteToNumber;
        }

        private void FromStringv1d0(String str)
        {
            String[] lines = str.Split('\n');
            int recordCount = int.Parse(lines[0]);
            m_typeCounts[0] = m_typeInitCounts[0] = int.Parse(lines[1]);
            m_typeCounts[1] = m_typeInitCounts[1] = int.Parse(lines[2]);

            int overalID = m_typeCounts[0] + m_typeCounts[1] - 1;

            InitRemain = int.Parse(lines[3])/10;

            Int64 remain = InitRemain;

            Name = lines[4];
            RemainLimit = int.Parse(lines[5])/10;
            RemainWarning = int.Parse(lines[6])/10;

            int recordOffset = 7;
            for (recordCount--; recordCount >= 0; recordCount--)
            {
                StringBuilder nextRecord = new StringBuilder();
                for (int i = 0; i < 12; i++)
                {
                    nextRecord.Append(lines[recordOffset + i]);
                    nextRecord.Append("\n");
                }

                Record newRec = new Record();
                newRec.FromString(nextRecord.ToString());
                //AppendRecordNoUpdate(newRec);
                //newRec.OverallID = overalID++;
                //if (newRec.Type  == Record.RecordType.Expense)
                //{
                //    remain-= newRec.Cost;
                //}
                //else
                //{
                //    remain+= newRec.Cost;
                //}

                //newRec.TypeID = m_typeCounts[(int)newRec.Type]++;
                //newRec.Remaining = remain;

                m_records.Add(newRec);
                recordOffset += 12;
            }
        }

        public static Diary FromString(String str)
        {
            Diary result;
            if (str[0] != '<')
            {
                result =  new Diary();
                result.FromStringv1d0(str);
            }
            else
            {
                using (StringReader sr = new StringReader(str))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(Diary));
                    result = (Diary)xs.Deserialize(new StringReader(str));
                }
            }

            result.UpdateRecords();
         
            return result;
        }

        public static Diary Load(string dir)
        {
            using (StreamReader sr = new StreamReader(dir, Encoding.GetEncoding(1250)))
            {
                StringBuilder sb = new StringBuilder();
                while (!sr.EndOfStream)
                {
                    string str = sr.ReadLine() + '\n';
                    sb.Append(str);
                }

                Diary result = FromString(sb.ToString());
                result.m_dir = dir;

                return result;
            }
            //sr.Close();

        }

        public void StoreChanges()
        {
            Store(Directory);
        }

        //throws exception
        private void Store(String directory)
        {
            using(StreamWriter wr = new StreamWriter(directory, false, Encoding.GetEncoding(1250)))
            {
                XmlSerializer sr = new XmlSerializer(typeof(Diary));
                sr.Serialize(wr, this);;
                //wr.Close();
            }
        }
    }
    class DataStore
    {
    }
}
