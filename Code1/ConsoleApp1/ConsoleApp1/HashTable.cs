using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class HashTable
    {
        public static Dictionary<string, int> CountWords(string text)
        {
            Dictionary<string, int> frequencies;
            frequencies = new Dictionary<string, int>();
            string[] words = Regex.Split(text, @"\W+");

            foreach (string word in words)
            {
                if (frequencies.ContainsKey(word))
                {
                    frequencies[word]++;
                }
                else
                {
                    frequencies[word] = 1;
                }
            }

            return frequencies;
        }

        public static void Printf()
        {
            ArrayList a = new ArrayList();
            IEnumerator e = a.GetEnumerator();
            Console.WriteLine(e.GetType().Name);
            string s = string.Empty;
            IEnumerator se = s.GetEnumerator();
            Console.WriteLine(se.GetType().Name);
        }
    }
}
