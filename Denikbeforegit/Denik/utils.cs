using System;
using System.Collections.Generic;
using System.Xml;
using System.Diagnostics;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Windows.Forms;


namespace Denik
{
    public static class MoneyConvertor
    {
        public static Int64 StrToMoney(string value, Int64 limit)
        {
            char[] charsToRemove = { ' ', ',', '.'};
            foreach(char c in charsToRemove)
                value = value.Replace(c.ToString(), "");
            Int64 result = Int64.Parse(value);
            if (result >= limit || result<0)
                throw new System.OverflowException();

            return result;
        }

        public static string MoneyToStr(Int64 value)
        {
            string input = value.ToString();
            StringBuilder result = new StringBuilder(input);

            for (int i = input.Length - 3; i > 0; i -= 3)
            {
                if (!((i > 0) && (result[i - 1] == '-')))   //kvuli zapornym cislu, delalo to tecku pred -
                    result.Insert(i, '.');
            }
            return result.ToString();
        }
    }

    public class NumberConvertor   //todo move to different file
    {
        static private string[] numbers1to19 = { "", "jedna", "dva", "tři", "čtyři", "pět"
            , "šest", "sedm", "osm", "devět", "deset", "jedenáct", "dvanáct",
            "třináct", "čtrnáct", "patnáct", "šestnáct", "sedmnáct", "osmnáct", "devatenáct"};

        static private string[] numbersDecades = {"", "", "dvacet", "třicet", "čtyřicet", "padesát", "šedesát"
                                                  ,"sedmdesát", "osmdesát", "devadesát"};
        static private string[] numberHundreds = {"", "sto", "dvěstě", "třista", "čtyřista", "pětset", "šestset",
                                                  "sedmset", "osmset", "devětset"};

        static public string ConvertIntToWord(int value)
        {
            Debug.Assert(value < 1000000);

            string result = "";
            if (value == 0)
                return "nula";

            if (value >= 1000)
            {
                int thousands = value / 1000;
                result = numberHundreds[thousands / 100];
                int tens = thousands % 100;
                if (tens != 0)
                {
                    if (2 <= thousands && thousands <= 4)
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
                    result = result + "tisíc";
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

    interface ExceptionWithMessageBox
    {
        void ShowMessage();
    }

    class MissingMyFileException : Exception, ExceptionWithMessageBox
    {
        
        public MissingMyFileException(string missingFile)
        {
            MissingFileName = missingFile;
        }

        public string MissingFileName { set; get; }
        #region ExceptionWithMessageBox Members

        public void ShowMessage()
        {
            MessageBox.Show("Soubor " + MissingFileName + " byl poškozen nebo zničen. Problém vyřešíte opětovnou instalací aplikace.", "Chyba!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion
    }


}