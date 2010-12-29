using System;
using System.Collections.Generic;
using System.Xml;
using System.Diagnostics;


namespace Settings
{
    public interface Storable
    {
        XmlElement convertToElement(string name, XmlDocument doc);

        static Object convertFromNode(XmlNode node);
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

        static public Object readStorable(string name, Object defaultObject, out bool ok)
        {
            XmlNodeList elems = m_mainDoc.GetElementsByTagName(name);
            ok = elems.Count != 0;

            if (elems.Count == 0)
                return defaultObject;
            else
            {
                item.convertFromNode(elems[0]);
                return defaultObject;
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

        public Object [] readStorableArray(string name)
        {
            List<Object> result = new List<object>();
            for (int i=0; ; i++)
            {
                String itemName = name + i.ToString();
                bool ok;
                Object itemValue = readStorable(itemName, out ok);
                if (ok)
                    result.Add(itemValue);
                else
                    break;
            }

            return result.ToArray();
        }

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

        public static Object readStorable(string name, Object defaultObject)
        {
            if (m_settings == null)
            {
                Debug.Assert(false, "Try to use uninitialized settings");
                return defaultObject;
            }

            bool ok;
            return m_settings.readStorable(name, defaultObject, out ok);
        }

        public static void addStorableArray(string name, Object [] value)
        {
            if (m_settings == null)
            {
                Debug.Assert(false, "Try to use uninitialized settings");
                return ;
            }

            m_settings.addStorableArray(name, value);
        }

        public static Object[] readStorableArray(string name)
        {
            if (m_settings == null)
            {
                Debug.Assert(false, "Try to use uninitialized settings");
                return new Object[0];
            }

            return m_settings.readStorableArray(name);

        }

    }



    public class HintsHolder
    {
        private class HintItem: Storable
        {
            public string m_hint;
            public Int64 m_counter;
            
            #region Storable Members

            XmlElement Storable.convertToElement(string name, XmlDocument doc)
            {
                XmlElement elem = doc.CreateElement(name);
                XmlElement child = doc.CreateElement("hint");
                child.InnerText = m_hint;
                elem.AppendChild(child);
                child = doc.CreateElement("counter");
                child.InnerText = m_counter.ToString();
                elem.AppendChild(child);

                return elem;

            }

            static Object Storable.convertFromNode(XmlNode elem)
            {
                HintItem hi = new HintItem();
                XmlElement child = elem["hint"];
                if (child != null)
                    hi.m_hint = child.InnerText;
                child = elem["counter"];
                try
                {
                    hi.m_counter = Int64.Parse(child.InnerText);
                }
                catch
                {
                    hi.m_counter = 0;
                }

                return hi;
            }

            #endregion
        }

        private string m_name;
        private List<HintItem> m_items;

        public HintsHolder(string name)
        {
            m_name = name;
            m_items = new List<HintItem>();
        }

        void store()
        {
            Storage.addStorableArray(m_name, m_items);
        }

        void load()
        {
            m_items = (List<HintItem>) Storage.readStorableArray(m_name);
        }
    }

    public static class Settings
    {
        private static string[] m_stamp = new string[0];
        private static string[] m_ = new string[0];
        private static string m_diaryDirectory = "";

        public static void Store()
        {
            Storage.addStringArray("Stamp", Stamp);
            Storage.addString("DiaryDirectory", DiaryDirectory);

            Storage.push();
        }

        public static void Load()
        {
            Stamp = Storage.readStringArray("Stamp");
            DiaryDirectory = Storage.readString("DiaryDirectory");

                        
        }

        public static string[] Stamp
        {
            set { m_stamp = value; }
            get { return m_stamp; }
        }

        public static string DiaryDirectory
        {
            set { m_diaryDirectory = value; }
            get { return m_diaryDirectory; }
        }

        

    }
}