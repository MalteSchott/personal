using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace AoC2020.Day2
{
    class Output
    {
        static public void Main(string[] args)
        {
            string[] Passwords = File.ReadAllLines("D:/Programmering/Repositories/personal/AdventOfCode/2020/Day2/Input.txt");
            int validPasswords = 0;
            int validPasswords2 = 0;

            foreach (string password in Passwords)
            {
                //Task1
                int low = Int32.Parse(Regex.Match(password, @"\d+").Value);
                int max = Int32.Parse(Regex.Match(password, @"\d+").NextMatch().Value);
                char letter = char.Parse(Regex.Match(password, "[a-zA-Z]+").Value);
                int letterCount = -1;

                foreach(char c in password)
                {
                    if (c.Equals(letter))
                    {
                        letterCount++;
                    }
                }

                if(letterCount >= low && letterCount <= max)
                {
                    validPasswords++;
                }

                //Task2
                string truePassword = password.Substring(password.IndexOf(char.Parse(":")) + 2);
                char first = truePassword[low - 1];
                char second = truePassword[max - 1];

                if (first.Equals(letter) ^ second.Equals(letter))
                {
                    validPasswords2++;
                }
            }
            Console.WriteLine("Result 1: " + validPasswords);
            Console.WriteLine("Result 2: " + validPasswords2);

        }
    }
}
