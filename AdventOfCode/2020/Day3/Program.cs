using System;
using System.IO;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Slope = File.ReadAllLines("D:/Programmering/Repositories/personal/AdventOfCode/2020/Day3/Input.txt");
            int horisontalPosition = 0;

            int CheckHorisontal(int h)
            {
                int newPos = h;
                if (h > Slope[0].Length - 1)
                {
                    newPos = h - Slope[0].Length;
                }
                return newPos;
            }
            int CalculateHit(int h, int v)
            {
                horisontalPosition = 0;
                int treesHit = 0;
                for (int i = v; i <= Slope.Length - 1; i += v)
                {
                    string line = Slope[i];
                    horisontalPosition += h;
                    horisontalPosition = CheckHorisontal(horisontalPosition);
                    char square = line[horisontalPosition];

                    if (square.Equals(char.Parse("#")))
                    {
                        treesHit += 1;
                    }
                }
                Console.WriteLine(treesHit);
                return treesHit;
            }

            long treesHit1 = CalculateHit(1, 1);
            long treesHit2 = CalculateHit(3, 1);
            long treesHit3 = CalculateHit(5, 1);
            long treesHit4 = CalculateHit(7, 1);
            long treesHit5 = CalculateHit(1, 2);

            long result2 = treesHit1 * treesHit2 * treesHit3 * treesHit4 * treesHit5;

            Console.WriteLine("Result1: Trees hit: " + treesHit2);
            Console.WriteLine("Result2: " + result2);
        }
    }
}
