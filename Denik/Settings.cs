using System;
using System.Collections.Generic;
using System.Xml;
using System.Diagnostics;


namespace Settings
{
    class SetingsImpl
    {
        private XmlDocument m_mainDoc = new XmlDocument();
        //XmlDocument private Dictionary<string, string> m_settingsItems;
        private string m_directory;

        public SetingsImpl(String directory)
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

        public void addStringArray(string name, string[] value)
        {
            //todo udelat nejaky array descriptor?
            for (int i = 0; ; i++)
            {
                String toRemoveName = name + i.ToString();
                if (!removeValue(toRemoveName))
                    break;
            }

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
    public static class GlobalSettings
    {
        private static SetingsImpl m_settings = null;

        public static void init(string settingsFileName)
        {
            if (m_settings != null)
            {
                Debug.Assert(false, "Try to reinit settings");
                return;
            }
            m_settings = new SetingsImpl(settingsFileName);
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
        
    }
}