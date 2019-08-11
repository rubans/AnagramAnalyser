using System;
using System.Collections.Generic;
using System.Linq;

namespace AnagramAnalyser.Core
{
    public static class AnagramAggregator
    {
        public static Dictionary<string, LinkedList<string>> FindAll(List<string> input)
        {
            var  hashMap = new Dictionary<string,LinkedList<string>>();

            foreach(var line in input)
            {
                string current = line.Replace("\n", "");

                char[] chars = current.ToCharArray();
                Array.Sort(chars);
                string key = new String(chars);

                LinkedList<string> ll = hashMap.ContainsKey(key) ? hashMap[key]
                    : new LinkedList<String>();
                ll.AddLast(current);

                if (!hashMap.ContainsKey(key))
                    hashMap.Add(key, ll);
            }
            return hashMap;
        }

        public static string FormatResult(this Dictionary<string, LinkedList<string>> anagrams)
        {
            var result = string.Join(Environment.NewLine, anagrams.Values
                .Select(_ =>
                    {
                        var s = string.Join(",", _.Distinct().ToArray());
                        return s;
                    }
                )
                .ToArray());
            return result;
        }
    }
}
            