using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class LinqTest
    {
        public static void Print()
        {
            IEnumerable<Patent> patents = PatentData.Patents;
            //Console.WriteLine($"Patent Count:{patents.Count()}");
            //Console.WriteLine($@"Patent Count in 1800s:{  patents.Count(d => d.YearOfPublication.StartsWith("18"))}");
            IEnumerable<string> selection = from word in GetWords()
                                            where !word.Contains("*")
                                            select word;
            foreach (string keyword in selection)
            {
                Console.WriteLine(keyword + " ");
            }
        }

        private static void Prints<T>(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                Console.WriteLine(item);
            }
        }

        private static string[] GetWords()
        {
            string[] KeyWords = {"abstract","add","alias","as","ascending","async","await","base"
            ,"bool","break","by","byte","case","catch","char","checked","class"};
            return KeyWords;
        }
    }

    public class Patent
    {
        public string Title { get; set; }

        public string YearOfPublication { get; set; }

        public string ApplicationNumber { get; set; }

        public long[] InventorIds { get; set; }

        public override string ToString()
        {
            return $"{Title}({YearOfPublication})";
        }
    }

    public class Inventor
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public override string ToString()
        {
            return $"{Name}({City},{State})";
        }
    }

    public static class PatentData
    {
        public static readonly Inventor[] Inventors = new Inventor[]
            {
                new Inventor()
                {
                    Name="Benjamin Franklin",City="PhiladePhia",
                    State="PA",Country="USA",Id=1
                },
                 new Inventor()
                {
                    Name="Benjamin Franklin",City="PhiladePhia",
                    State="PA",Country="USA2",Id=2
                }, new Inventor()
                {
                    Name="Benjamin Franklin",City="PhiladePhia",
                    State="PA",Country="USA3",Id=3
                }, new Inventor()
                {
                    Name="Benjamin Franklin",City="PhiladePhia",
                    State="PA",Country="USA4",Id=4
                }, new Inventor()
                {
                    Name="Benjamin Franklin",City="PhiladePhia",
                    State="PA",Country="USA5",Id=5
                },
            };

        public static readonly Patent[] Patents = new Patent[]
        {
            new Patent()
            {
                Title="Bifocals",YearOfPublication="1753",
                InventorIds=new long[]{1 }
            },
             new Patent()
            {
                Title="Bifoca22ls",YearOfPublication="17253",
                InventorIds=new long[]{1,4,5 }
            },
              new Patent()
            {
                Title="Bifoc33als",YearOfPublication="17653",
                InventorIds=new long[]{1 ,6,7}
            }
        };
    }
}
