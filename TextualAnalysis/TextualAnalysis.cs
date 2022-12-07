using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextualAnalysis
{
    public class TextualAnalysis
    {
        public static string stopWordFilePath = "../../../Data/stop-words.txt";

        public TextualAnalysis()
        {
        }


        public static Dictionary<string, int> ComputeWordFrequencies(string s, bool ignoreStopWords = false)
        {
            var wordCounts = new Dictionary<string, int>();
            // s = "all the faith he had had had had no effect."

            // remove punctuation
            var cleanString = Regex.Replace(s, @"[^\w\s ]", "");

            // split the string into words (filtering out the empty strings)

            var words = cleanString.ToLower().Split().Where(s => s != "");

            string[] stopWords = GetStopWordsFromFile(stopWordFilePath);

            HashSet<string> wordSet = new HashSet<string>();

            foreach (var i in stopWords)
            {
                wordSet.Add(i);
            }

            foreach(var w in words)
            {
                if(wordSet.Contains(w) && ignoreStopWords == true)
                {
                    continue;
                }

                else
                {
                    if( wordCounts.ContainsKey(w))
                    {
                        wordCounts[w]++;
                    }

                    else
                    {
                        wordCounts.Add(w,1);
                    }
                }
            }
            return wordCounts;
        }


        public static Dictionary<string, int> ComputeWordFrequenciesFromFile(string path, bool ignoreStopWords = false)
        {
            // read in the file
            string text = System.IO.File.ReadAllText(path);

            // call the other method
            var wordCount = ComputeWordFrequencies(text, ignoreStopWords);

            // return the result of the other method

            return wordCount;

        }

        private static string[] GetStopWordsFromFile(string path)
        {
            var rawLines = System.IO.File.ReadAllLines(path);
            var lines = new List<string>();

            foreach (var line in rawLines)
            {
                // ignore blank lines
                if (line.Trim() != "")
                {
                    lines.Add(line.Trim().ToLower());
                }
            }

            return lines.ToArray();
        }

    }
}
