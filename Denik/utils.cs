using System;
using System.Collections.Generic;
using System.Xml;
using System.Diagnostics;
using System.Xml.Serialization;
using System.IO;
using System.Text;


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

            for (int i = input.Length - 3; i > 0;  i -= 3) 
                result.Insert(i, ' ');            

            return result.ToString();
        }
    }

}