using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AnagramAnalyser.Core
{
    public static class FileReader
    {
        public static List<string> GetWords(string fileName)
        {
            var content = new StringBuilder();
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    content.AppendLine(s);
                }
            }
            var lines = content.ToString().LowMemSplit("\r");
            return lines;
        }

        /// <summary>
        /// https://stackoverflow.com/questions/1404435/string-split-out-of-memory-exception-when-reading-tab-separated-file
        /// </summary>
        /// <param name="s"></param>
        /// <param name="seperator"></param>
        /// <returns></returns>
        public static List<string> LowMemSplit(this string s, string seperator)
        {
            List<string> list = new List<string>();
            int lastPos = 0;
            int pos = s.IndexOf(Environment.NewLine);
            while (pos > -1)
            {
                while (pos == lastPos)
                {
                    lastPos += seperator.Length;
                    pos = s.IndexOf(seperator, lastPos);
                    if (pos == -1)
                        return list;
                }

                string tmp = s.Substring(lastPos, pos - lastPos);
                if (tmp.Trim().Length > 0)
                    list.Add(tmp);
                lastPos = pos + seperator.Length;
                pos = s.IndexOf(seperator, lastPos);
            }

            if (lastPos < s.Length)
            {
                string tmp = s.Substring(lastPos, s.Length - lastPos);
                if (tmp.Trim().Length > 0)
                    list.Add(tmp);
            }

            return list;
        }   

    }
}
