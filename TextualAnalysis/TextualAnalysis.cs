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
            var cleanString = Regex.Replace(s, @"[ ^\w\s ]", "");

            // split the string into words (filtering out the empty strings)

            var words = cleanString.ToLower()
                                   .Split()
                                   .Where(s => s != "");

            string[] stopWords = GetStopWordsFromFile(stopWordFilePath);


            // foreach word do something
            foreach (var word in words)
            {
            
            // if not ignoring stop words and word is a stop word
                if( ignoreStopWords == false && stopWords.Contains(word))
                {
                    // Skip the word
                    continue;
                }
            // else
                else
                {
                    // either add word if new with count of one

                    if( wordCounts[word] == 0 )
                    {
                        wordCounts[word] = 1;
                    }

                    wordCounts[word]++;
                    //if( wordCounts.ContainsKey(word))
                    //{
                    //    wordCounts[word] = wordCounts[word] + 1;
                    //}

                    //wordCounts[word] = 1;
                }
            // or increment the word count if it's already in the dictionary


            }

            return wordCounts;
        }


        public static Dictionary<string, int> ComputeWordFrequenciesFromFile(string path, bool ignoreStopWords = false)
        {
            // read in the file
            string text = System.IO.File.ReadAllText(path);

            // call the other method
            return ComputeWordFrequencies(text);
            // return the result of the other method

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
