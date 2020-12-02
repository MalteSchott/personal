using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AoC2020.Day1
{
    class Output
    {
        static public void Main(string[] args)
        {
            string[] LinesTxt = File.ReadAllLines("D:/Programmering/Repositories/personal/AdventOfCode/2020/AoC2020/Input.txt");
            int[] LinesInt = new int[LinesTxt.Length];

            int result = 0;
            int result2 = 0;

            for (int i = 0; i < LinesTxt.Length; i++)
            {
                LinesInt[i] = Int32.Parse(LinesTxt[i]);
            }

            foreach (int a in LinesInt)
            {
                foreach (int b in LinesInt)
                {
                    int c = a + b;

                    if(c == 2020)
                    {
                        result = a * b;
                    }
                }
            }
            Console.WriteLine("First result: " + result);

            foreach (int a in LinesInt)
            {
                foreach (int b in LinesInt)
                {
                    foreach(int c in LinesInt)
                    {
                        int d = a + b + c;

                        if(d == 2020)
                        {
                            result2 = a * b * c;
                        }
                    }

                }
            }
            Console.WriteLine("Second result: " + result2);
        }
    }
}
