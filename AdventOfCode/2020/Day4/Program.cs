using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] passports = File.ReadAllLines("D:/Programmering/Repositories/personal/AdventOfCode/2020/Day4/Input.txt");
            int validPassports1 = 0;
            int validPassports2 = 0;

            bool byrTrue = false;
            bool iyrTrue = false;
            bool eyrTrue = false;
            bool hgtTrue = false;
            bool hclTrue = false;
            bool eclTrue = false;
            bool pidTrue = false;

            bool byrValid = false;
            bool iyrValid = false;
            bool eyrValid = false;
            bool hgtValid = false;
            bool hclValid = false;
            bool eclValid = false;
            bool pidValid = false;

            foreach (string passportLine in passports)
            {   
                string[] fields = passportLine.Split(' ');

                foreach (string field in fields)
                { 
                    if (Regex.IsMatch(field, "byr"))
                    {
                        byrTrue = true;
                        int byr = Int32.Parse(field.Substring(field.IndexOf(char.Parse(":")) + 1));

                        if (byr >= 1920 && byr <= 2002)
                        {
                            byrValid = true;
                        }
                    }

                    if (Regex.IsMatch(field, "iyr"))
                    {
                        iyrTrue = true;
                        int iyr = Int32.Parse(field.Substring(field.IndexOf(char.Parse(":")) + 1));

                        if (iyr >= 2010 && iyr <= 2020)
                        {
                            iyrValid = true;
                        }
                    }
                    if (Regex.IsMatch(field, "eyr"))
                    {
                        eyrTrue = true;
                        int eyr = Int32.Parse(field.Substring(field.IndexOf(char.Parse(":")) + 1));

                        if (eyr >= 2020 && eyr <= 2030)
                        {
                            eyrValid = true;
                        }
                    }
                    if (Regex.IsMatch(field, "hgt"))
                    {
                        hgtTrue = true;
                        int hgt = Int32.Parse(Regex.Match(field.Substring(field.IndexOf(char.Parse(":")) + 1), @"\d+").Value);
                        string format = Regex.Match(field.Substring(field.IndexOf(char.Parse(":")) + 1), "[a-zA-Z]+").Value;

                        if(format.Equals("in"))
                        {
                            if(hgt >= 59 && hgt <= 76)
                            {
                                hgtValid = true;
                            }
                        }
                        if(format.Equals("cm"))
                        {
                            if (hgt >= 150 && hgt <= 193)
                            {
                                hgtValid = true;
                            }
                        }
                    }
                    if (Regex.IsMatch(field, "hcl"))
                    {
                        hclTrue = true;
                        string hcl = Regex.Match(field.Substring(field.IndexOf(char.Parse("#")) + 1), "[a-f0-9]+").Value;

                        if(hcl.Length == 6)
                        {
                            hclValid = true;
                        }
                    }
                    if (Regex.IsMatch(field, "ecl"))
                    {
                        eclTrue = true;
                        string ecl = field.Substring(field.IndexOf(char.Parse(":")) + 1);

                        if(ecl.Equals("amb") || ecl.Equals("blu") || ecl.Equals("brn") || ecl.Equals("gry") || ecl.Equals("grn") || ecl.Equals("hzl") || ecl.Equals("oth"))
                        {
                            eclValid = true;
                        }
                    }
                    if (Regex.IsMatch(field, "pid"))
                    {
                        pidTrue = true;
                        string pid = Regex.Match(field.Substring(field.IndexOf(char.Parse(":")) + 1), @"\d+").Value;

                        if (pid.Length == 9)
                        {
                            pidValid = true;
                        }
                    }


                    if (passportLine.Length == 0)
                    {
                        if (byrTrue && iyrTrue && eyrTrue && hgtTrue && hclTrue && eclTrue && pidTrue)
                        {
                            validPassports1 += 1;

                            if (byrValid && iyrValid && eyrValid && hgtValid && hclValid && eclValid && pidValid)
                            {
                                validPassports2 += 1;
                            }
                        }
                        
                        byrTrue = false;
                        iyrTrue = false;
                        eyrTrue = false;
                        hgtTrue = false;
                        hclTrue = false;
                        eclTrue = false;
                        pidTrue = false;

                        byrValid = false;
                        iyrValid = false;
                        eyrValid = false;
                        hgtValid = false;
                        hclValid = false;
                        eclValid = false;
                        pidValid = false;
                    }
                }
            }
            Console.WriteLine("Result 1: " + validPassports1);
            Console.WriteLine("Result 2: " + validPassports2);
        }
    }
}
