using System;
using System.Collections.Generic;
using System.Xml;
using System.Diagnostics;
using System.Xml.Serialization;
using System.IO;
using System.Drawing;
using System.Windows.Forms;


namespace Settings
{
    public interface Storable
    {
        XmlElement convertToElement(string name, XmlDocument doc);

        bool convertFromNode(XmlNode node);
    }

    class SetingsStorageImpl
    {
        private XmlDocument m_mainDoc = new XmlDocument();
        //XmlDocument private Dictionary<string, string> m_settingsItems;
        private string m_directory;

        public SetingsStorageImpl(String directory)
        {
            m_directory = directory;
            try
            {
                m_mainDoc.Load(directory);
            }
            catch
            {
                m_mainDoc.LoadXml("<?xml version='1.0' encoding='utf-8'?>"+
                            "<DiarySettings> </DiarySettings>");
            }
        }

        private void genericAddValue(string name, string value)
        {
            removeValue(name);
            XmlElement elem = m_mainDoc.CreateElement(name);
            elem.InnerText = value;
            m_mainDoc.DocumentElement.AppendChild(elem);
        }

        private string genericReadString(string name, out bool ok)
        {
            XmlNodeList elems = m_mainDoc.GetElementsByTagName(name);
            ok = elems.Count != 0;

            if (elems.Count == 0)
                return "";
            else
                return elems[0].InnerText;
        }

        private bool removeValue(string name)
        {
            XmlNodeList elems = m_mainDoc.GetElementsByTagName(name);
            bool result = elems.Count != 0;
            for (int i = 0; i < elems.Count; i++)
            {
                elems[i].ParentNode.RemoveChild(elems[i]);
            }

            return result;
        }

        private void removeArray(string name)
        {
            for (int i = 0; ; i++)
            {
                String toRemoveName = name + i.ToString();
                if (!removeValue(toRemoveName))
                    break;
            }
        }

        public void addStorable(string name, Storable item)
        {
            removeValue(name);
            XmlElement elem = item.convertToElement(name, m_mainDoc);

            m_mainDoc.DocumentElement.AppendChild(elem);
        }

        public void readStorable(Storable newObject, string name, out bool ok)
        {
            XmlNodeList elems = m_mainDoc.GetElementsByTagName(name);
            ok = elems.Count != 0;

            if (elems.Count == 0)
                 return ;
            else
            {
                ok = (ok & newObject.convertFromNode(elems[0]));                
            }           
        }

        public void addString(string name, string value)
        {
            genericAddValue(name, value);
        }

        public string readString(string name)
        {
            return readString(name, "");
        }

        public string readString(string name, string defaultValue)
        {
            bool ok;
            string result = genericReadString(name, out ok);
            if (ok)
                return result;
            else
                return defaultValue;
        }

        public void addStorableArray(string name, Storable[] value)
        {
            removeArray(name);

            for (int i = 0; i < value.Length; i++)
            {
                String itemName = name + i.ToString();
                addStorable(itemName, value[i]);
            }
        }

        //public Storable [] readStorableArray(string name)
        //{
        //    List<Object> result = new List<object>();
        //    for (int i=0; ; i++)
        //    {
        //        String itemName = name + i.ToString();
        //        bool ok;
        //        Object itemValue = readStorable(itemName, out ok);
        //        if (ok)
        //            result.Add(itemValue);
        //        else
        //            break;
        //    }

        //    return result.ToArray();
        //}

        public void addStringArray(string name, string[] value)
        {
            //todo udelat nejaky array descriptor?
            removeArray(name);

            for (int i = 0; i < value.Length; i++)
            {
                String itemName = name + i.ToString();
                genericAddValue(itemName, value[i]);
            }
        }

        public string [] readStringArray(string name)
        {
            List<string> result = new List<string>();
            for (int i = 0; ; i++)
            {
                String itemName = name + i.ToString();
                bool ok;
                string itemValue = genericReadString(itemName, out ok);
                if (ok)
                    result.Add(itemValue);
                else
                    break;
            }

            return result.ToArray();            
        }

        public void push()
        {
            m_mainDoc.Save(m_directory);
        }

        public void Reload()
        {
            /*   try
               {
                   XmlReaderSettings settings = new XmlReaderSettings();
                   using (XmlReader reader = XmlReader.Create(settingsFile, settings))
                   {
                       //reader.GetType
                       reader.ReadStartElement("DiarySettings");
                       directory = reader.ReadElementString("Directory");
                       reader.ReadEndElement();
                   }
               }
           */
        }
    }



    public static class Storage
    {
        private static SetingsStorageImpl m_settings = null;

        public static void init(string settingsFileName)
        {
            if (m_settings != null)
            {
                Debug.Assert(false, "Try to reinit settings");
                return;
            }
            m_settings = new SetingsStorageImpl(settingsFileName);
        }

        public static void addString(string name, string value)
        {
            if (m_settings==null)
            {
                Debug.Assert(false, "Try to use uninitialized settings");
                return;
            }

            m_settings.addString(name, value);
        }

        public static string readString(string name)
        {
            return readString(name, "");
        }

        public static string readString(string name, string defaultValue)
        {
            if (m_settings == null)
            {
                Debug.Assert(false, "Try to use uninitialized settings");
                return defaultValue;
            }

            return m_settings.readString(name, defaultValue);
        }

        public static void push()
        {
            if (m_settings == null)
            {
                Debug.Assert(false, "Try to use uninitialized settings");
                return;
            }

            m_settings.push();
        }

        public static void addStringArray(string name, string[] value)
        {
            if (m_settings == null)
            {
                Debug.Assert(false, "Try to use uninitialized settings");
                return;
            }

            m_settings.addStringArray(name, value);
        }

        public static string[] readStringArray(string name)
        {
            if (m_settings == null)
            {
                Debug.Assert(false, "Try to use uninitialized settings");
                return new string[0];
            }

            return m_settings.readStringArray(name);
        }

        public static void addStorable(string name, Storable item)
        {
            if (m_settings == null)
            {
                Debug.Assert(false, "Try to use uninitialized settings");
                return ;
            }

            m_settings.addStorable(name, item);
        }

        public static T readStorable<T>(string name, T defaultObject) where T: Storable, new()
        {
            T newItem = new T();
            if (m_settings == null)
            {
                Debug.Assert(false, "Try to use uninitialized settings");
                return defaultObject;
            }

            bool ok;
            m_settings.readStorable(newItem, name, out ok);
            if (ok)
                return newItem;
            else
                return defaultObject;
        }

        public static void addStorableArray(string name, Storable [] value)
        {
            if (m_settings == null)
            {
                Debug.Assert(false, "Try to use uninitialized settings");
                return ;
            }

            m_settings.addStorableArray(name, value);
        }

        public static T[] readStorableArray<T>(string name) where T:Storable, new()
        {
            if (m_settings == null)
            { 
                Debug.Assert(false, "Try to use uninitialized settings");
                return new T[0];
            }

            List<T> result = new List<T>();
            for (int i = 0; ; i++)
            {
                String itemName = name + i.ToString();
                T newItem = new T();
                bool ok;
                m_settings.readStorable(newItem, itemName, out ok);
                if (ok)
                    result.Add(newItem);
                else
                    break;
            }

            return result.ToArray();

        }

    }



    public class HintsHolder
    {
        public class HintItem//: Storable
        {
            public string m_hint;
            public Int64 m_counter;
            
            public HintItem()
                : this("", 0)
            {

            }

            public HintItem(String hint, int counter)
            {
                m_hint = hint;
                m_counter = counter;
            }
            
            //XmlElement Storable.convertToElement(string name, XmlDocument doc)
            //{
            //    XmlElement elem = doc.CreateElement(name);
            //    XmlElement child = doc.CreateElement("hint");
            //    child.InnerText = m_hint;
            //    elem.AppendChild(child);
            //    child = doc.CreateElement("counter");
            //    child.InnerText = m_counter.ToString();
            //    elem.AppendChild(child);

            //    return elem;

            //}

            //bool Storable.convertFromNode(XmlNode elem)
            //{
            //    XmlElement child = elem["hint"];
            //    if (child != null)
            //        m_hint = child.InnerText;
            //    child = elem["counter"];
            //    try
            //    {
            //        m_counter = Int64.Parse(child.InnerText);
            //    }
            //    catch
            //    {
            //        m_counter = 0;
            //        return false;
            //    }
            //    return true;
            //}

            //#endregion
        }

        private string m_name;

        private List<HintItem> m_items;

        public HintsHolder() 
        {
            m_name = "";
            m_items = new List<HintItem>();
        }
        public HintsHolder(string name)
        {
            m_name = name;
            m_items = new List<HintItem>();
        }

        public void appendHint(string hint)
        {  
            for (int i = 0; i < m_items.Count; i++)
                if (hint.CompareTo(m_items[i].m_hint) == 0)
                {
                    return;
                }

            m_items.Add(new HintItem(hint, 0));
        }

        public void removeHint(string hint)
        {
            for (int i = 0; i < m_items.Count; i++)
                if (hint.CompareTo(m_items[i].m_hint) == 0)
                    m_items.RemoveAt(i);
        }


        public string[] hints()
        {
            List<string> result = new List<string>();
            foreach (HintItem hi in m_items)
                result.Add(hi.m_hint);

            result.Sort();

            return result.ToArray();
        }

        /// <summary>
        /// Should not be accessed directly, just for serialization
        /// </summary>
        /// 
        public HintItem[] hintItems
        {
            get
            {
                return m_items.ToArray();
            }
            set
            {
                m_items = new List<HintItem>(value);
            }
        }

        //public void store()
        //{
        //}

        //public void load()
        //{
        //    for (int i = 0; i < 150; i++)
        //        m_items.Add(new HintItem(Denik.NumberConvertor.ConvertIntToString(i),0));
        //}

        public string Name
        {
            set { m_name = value; }
            get { return m_name; }
        }
    }

    public class SettingsImpl
    {
        private string[] m_stamp = new string[0];
        private string m_diaryDirectory = "";

        private Dictionary<string, HintsHolder> m_hints = new Dictionary<string,HintsHolder>();

        private static string [] m_hintClasses = {"IncomeName", "IncomeFor", "OutcomeName", "OutcomeFor", "OutcomeRecipient"};

        public SettingsImpl()
        {
            foreach (string hintClass in m_hintClasses)
            {
                m_hints.Add(hintClass, new HintsHolder(hintClass));
            }

            MainWindowPos = new Rectangle(0, 0, 0,0);            
        }

        //Should not be access directly, just for serialization
        public HintsHolder[] hintHolders
        {
            get
            {
                HintsHolder[] result = new HintsHolder[m_hints.Count];
                int i = 0;
                foreach (KeyValuePair<string, HintsHolder> hh in m_hints)
                {
                    foreach(string hc in m_hintClasses)
                        if (hc.Equals(hh.Key))
                        {
                            result[i++] = hh.Value;
                            break;
                        }
                }
                return result;
            }
            set
            {
                m_hints = new Dictionary<string, HintsHolder>();
                foreach (HintsHolder hh in value)
                {
                    foreach (string hc in m_hintClasses)
                        if (hc.Equals(hh.Name))
                        {
                            m_hints.Add(hh.Name, hh);
                            break;
                        }
                }
            }
        }

        public string[] Stamp
        {
            set { m_stamp = value; }
            get { return m_stamp; }
        }

        public Rectangle MainWindowPos
        {
            set;
            get;
        }

        public float[] ColumnsWidths
        {
            set;
            get;
        }

        public string DiaryDirectory
        {
            set { m_diaryDirectory = value; }
            get { return m_diaryDirectory; }
        }

        public void addHint(string hintClass, string hint)
        {
            Debug.Assert(Array.IndexOf(m_hintClasses, hintClass)!=-1);

            int i = hint.Length-1;
            while (i>0 && hint[i] == ' ')
                i--;
            string newHint = hint.Substring(0, i + 1);

            if (newHint == "")
                return;
            
            HintsHolder hi;
            if (m_hints.TryGetValue(hintClass, out hi))
                hi.appendHint(newHint);
        }

        public void removeHint(string hintClass, string hint)
        {
            Debug.Assert(Array.IndexOf(m_hintClasses, hintClass) != -1, "Wrong hintClass");
            HintsHolder hi;
            if (m_hints.TryGetValue(hintClass, out hi))
                hi.removeHint(hint);
        }

        public string[] getHints(string hintClass)
        {
            Debug.Assert(Array.IndexOf(m_hintClasses, hintClass) != -1, "Wrong hintClass");
            HintsHolder hi;
            if (m_hints.TryGetValue(hintClass, out hi))
                return hi.hints();
            else
                return new string[0];
        }
    }

    public static class Settings
    {
        public static SettingsImpl SettingsHolder = new SettingsImpl();
        public static void Load()
        {
            try
            {
                using (StreamReader sr = new StreamReader("main_settings.xml"))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(SettingsImpl));
                    SettingsHolder = (SettingsImpl)xs.Deserialize(sr);

                }
            }
            catch
            {
                MessageBox.Show("Došlo k poškození pomocných souborů, veškerá nastavení budou ztracena.",
                    "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Store()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("main_settings.xml"))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(SettingsImpl));
                    xs.Serialize(sw, SettingsHolder);
                }
            }
            catch
            {
                Debug.Assert(false); //silently ignores
            }
            //sw.Close();
        }

    }
}