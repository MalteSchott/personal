using System;
using System.IO;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bordingPasses = File.ReadAllLines("D:/Programmering/Repositories/personal/AdventOfCode/2020/Day5/Input.txt");
            int highestSID = 0;

            foreach(string bordingPass in bordingPasses)
            {
                double maxRow = 127;
                double minRow = 0;

                double maxColumn = 7;
                double minColumn = 0;

                for (int i = 0; i < 7 ; i++)
                {
                    char check = bordingPass[i];

                    if(check.Equals(char.Parse("F")))
                    {
                        maxRow = Math.Floor((maxRow - ((maxRow - minRow)) / 2));
                    }
                    if(check.Equals(char.Parse("B")))
                    {
                        minRow = Math.Ceiling(minRow + ((maxRow - minRow) / 2));
                    }
                }

                for (int i = 7; i < 10; i++)
                {
                    char check = bordingPass[i];

                    if (check.Equals(char.Parse("R")))
                    {
                        minColumn = Math.Ceiling(minColumn + ((maxColumn - minColumn) / 2));
                    }
                    if (check.Equals(char.Parse("L")))
                    {
                        maxColumn = Math.Floor((maxColumn - ((maxColumn - minColumn)) / 2));
                    }
                }
                int row = (int)maxRow;
                int column = (int)maxColumn;

                int SID = (row * 8) + column;
                
                if (SID > highestSID)
                {
                    highestSID = SID;
                }
            }
            Console.WriteLine("Highest seat ID: " + highestSID);
        }
    }
}
