using AnagramAnalyser.Core;
using System;
using System.IO;

namespace AnagramAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args == null)
                    throw new Exception("No fileName provided!");
                // The path is passed as the first argument
                string fileName = args[0];
                if (!File.Exists(fileName))
                    throw new FileNotFoundException();
                Console.WriteLine($"File : {fileName}");
                Console.WriteLine($"Begin Reading File...");
                var lines = FileReader.GetWords(fileName);
                Console.WriteLine($"Finished Reading File.");
                if(lines.Count == 0)
                {
                    throw new Exception("No lines found!");
                }
                Console.WriteLine($"Finding Anagrams from {lines.Count} lines...");
                var anagrams = AnagramAggregator.FindAll(lines);
                Console.WriteLine($"Found {anagrams.Count} anagrams.");
                Console.WriteLine($"Anagrams:\n{anagrams.FormatResult()}");
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error - Exception : {e}");
            }
            finally
            {
                Console.WriteLine("Press Any key to exit.");
                Console.ReadLine();
            }
        }
    }
}
