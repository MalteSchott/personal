using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ShakeSpearScrabble
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> wordList = new List<string>(File.ReadAllLines("D:/Programmering/Repositories/personal/ShakeSpearScrabble/words.shakespeare.txt"));
            List<String> dictionary = new List<string>(File.ReadAllLines("D:/Programmering/Repositories/personal/ShakeSpearScrabble/ospd.txt"));
            List<ScoredWord> validWords = new List<ScoredWord>();

            //Tests:

            /*string test1 = "amps";
            string test2 = "diddededzzz";
            int[] letters = countLetters(test1);
            Console.WriteLine("Test1 letters 1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,1,0,0,0,0,0,0,0, ==");
            Console.Write("Test1 letters ");
            for (int i = 0; i < 26; i++)
            {
                Console.Write(letters[i] + ",");
            }
            Console.WriteLine("");

            Console.WriteLine("Test1 enoughletters(true) = " + EnoughLetters(test1));
            Console.WriteLine("Test2 enoughletters(false) = " + EnoughLetters(test2));

            Console.WriteLine("Test1 scoreWord(8) = " + ScoreWord(test1));
            Console.WriteLine("Test2 scoreWord(15) = " + ScoreWord(test2));*/

            foreach (string word in wordList)
            {
                if (EnoughLetters(word))
                {
                    if (dictionary.Contains(word))
                    {
                        ScoredWord scoredWord = new ScoredWord(word, ScoreWord(word));
                        validWords.Add(scoredWord);
                    }
                }
            }
            List<ScoredWord> sortedWords = validWords.OrderByDescending(w => w.Score).ToList();
            List<String> sortedWordsStrings = new List<string>();

            sortedWordsStrings.Add("Top 3 Words: ");

            for (int i = 0; i < 3; i++)
            {
                ScoredWord currentWord = sortedWords.ElementAt(i);
                sortedWordsStrings.Add(currentWord.Word + " : " + currentWord.Score);
            }

            sortedWordsStrings.Add("");
            sortedWordsStrings.Add("Results: ");

            foreach (ScoredWord scoredWord in sortedWords)
            {
                sortedWordsStrings.Add(scoredWord.Word + " : " + scoredWord.Score);               
            }
            File.WriteAllLines("D:/Programmering/Repositories/personal/ShakeSpearScrabble/Result.txt", sortedWordsStrings);
        }

        static int[] countLetters(string word)
        {
            string lowerCaseWord = word.ToLower();
            int[] letters = new int[26];
            List<char> alphabet = new List<char>();
            alphabet.AddRange("abcdefghijklmnopqrstuvwxyz");

            foreach (char letter in lowerCaseWord)
            {
                letters[alphabet.BinarySearch(letter)]++;
            }

            return letters;
        }

        static Boolean EnoughLetters(string word)
        {
            int[] letters = countLetters(word);
            int[] blanksUsed = BlanksUsed(word);
            int totalBlanksUsed = 0;

            for (int i = 0; i < 26; i++)
            {
                totalBlanksUsed += blanksUsed[i];
            }
            return totalBlanksUsed <= 2;
        }
        static int[] BlanksUsed(string word)
        {
            int[] letters = countLetters(word);
            int[] scrabbleLetterDistribution = {
             // a, b, c, d,  e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z
                9, 2, 2, 1, 12, 2, 3, 2, 9, 1, 1, 4, 2, 6, 8, 2, 1, 6, 4, 6, 4, 2, 2, 1, 2, 1
            };
            int[] blanksUsed = new int[26];

            for (int i = 0; i < 26; i++)
            {
                if (letters[i] > scrabbleLetterDistribution[i])
                {
                    blanksUsed[i] = letters[i] - scrabbleLetterDistribution[i];
                }
            }
            return blanksUsed;
        }

        static int ScoreWord(string word)
        {
            int[] letters = countLetters(word);
            int[] blanksUsed = BlanksUsed(word);
            int[] letterScores = {
             // a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p,  q, r, s, t, u, v, w, x, y, z
                1, 3, 3, 2, 1, 4, 2, 4, 1, 8, 5, 1, 3, 1, 1, 3, 10, 1, 1, 1, 1, 4, 4, 8, 4, 10
            };
            int score = 0;

            for(int i = 0; i < 26; i++)
            {
                score += (letters[i] - blanksUsed[i]) * letterScores[i];
            }
            return score;
        }
    }
}