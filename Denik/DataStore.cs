using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

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
                Cost.ToString() + "\n" +
                Remaining.ToString() + "\n" +
                Type.ToString() + "\n" +
                Date.ToString() + "\n" +
                Date.ToString() + "\n" +        //todo ???
                NoteToNumber + "\n" +           //todo ???
                CustName + "\n" +
                Content + "\n" +
                Note + "\n" +
                PayedTo.ToString() + "\n";

            return result;
        }

        public void FromString(String str)
        {
            String[] words = str.Split('\n');
            OverallID = int.Parse(words[0]);
            TypeID = int.Parse(words[1]);
            Cost = int.Parse(words[2]);
            Remaining = int.Parse(words[3]);
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

        private int m_pageSize = 20;

        public Diary()
        {
            throw new Exception();
        }

        public Diary(String directory) 
        {
            m_dir = directory;
            Load();
        }

        public String Name { set { m_name = value; } get { return m_name; } }
        public int RemainWarning { set { m_remainWarning = value; } get { return m_remainWarning; } }
        public int RemainLimit { set { m_remainLimit = value; } get { return m_remainLimit; } }
        public int InitRemain { set { m_initRemain = value; } get { return m_initRemain; } }

        public int[] TypeCounts { get { return m_typeCounts; } }
        public int[] InitTypeCounts { get { return m_typeInitCounts; } }

        public void UpdateRecords()
        {
            int[] typesCount = new int[Record.TypeCount];
            for (int i = 0; i < Record.TypeCount; i++)
                typesCount[i] = m_typeInitCounts[i];

            Int64 remain = m_initRemain;
            for (int i=0; i<m_records.Count; i++)
            {
                if (m_records[i].Type == Record.RecordType.Income)
                {
                    m_records[i].TypeID = ++typesCount[(int)m_records[i].Type];
                    remain += m_records[i].Cost;
                }
                else
                {
                    m_records[i].TypeID = ++typesCount[(int)m_records[i].Type];
                    remain -= m_records[i].Cost;
                }
                m_records[i].Remaining = remain;
            
                int overallID = 0;
                for (int j = 0; j < Record.TypeCount; j++)
                    overallID += typesCount[j];

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
            UpdateRecords();
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

        public void ReplaceRecord(Record newRecord, int pos)
        {
            Debug.Assert(pos < RecordsCount);
            if (pos >= RecordsCount)
                return;

            m_records[pos] = newRecord;
            

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

        public Record[] GetPage(int pageID)
        {
            Record[] result = new Record[m_pageSize];
            if (pageID * m_pageSize > m_records.Count || pageID < 0)
                throw new Exception();

            for (int i = 0; i < m_pageSize; i++)
            {
                if (i + pageID * m_pageSize >= m_records.Count)
                    break;
                result[i] = m_records[pageID * m_pageSize + i];
            }

            return result;
        }

        public void SetPageSize(int pageSize)
        {
            m_pageSize = pageSize;
        }

        public int PageCount
        {
            get { return (Math.Max(m_records.Count - 1, 0)) / m_pageSize + 1; }
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
                          RemainLimit.ToString() + "\n");

            for (int i = 0; i < m_records.Count; i++)
            {
                result.Append("\n");
                result.Append(m_records[i].ToString());
            }

            return result.ToString();
        }

        public void FromString(String str)
        {
            
            String[] lines = str.Split('\n');
            int recordCount = int.Parse(lines[0]);
            m_typeCounts[0] = m_typeInitCounts[0] = int.Parse(lines[1]);
            m_typeCounts[1] = m_typeInitCounts[1] = int.Parse(lines[2]);
            
            int overalID = m_typeCounts[0] + m_typeCounts[1]-1;

            InitRemain = int.Parse(lines[3]);

            Int64 remain = InitRemain;

            Name = lines[4];
            RemainLimit = int.Parse(lines[5]);
            RemainWarning = int.Parse(lines[6]);

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

            UpdateRecords();

        }

        public void Load()
        {
            StreamReader sr = new StreamReader(Directory, Encoding.GetEncoding(1250));
            StringBuilder sb = new StringBuilder();
            while (!sr.EndOfStream)
            {
                string str = sr.ReadLine() + '\n';
                sb.Append(str);
            }
            FromString(sb.ToString());
        }

        //throws exception
        public void Store(String directory)
        {
            StreamWriter wr = new StreamWriter(Directory);
            wr.Write(ToString());
            wr.Close();
        }
    }
    class DataStore
    {
    }
}
