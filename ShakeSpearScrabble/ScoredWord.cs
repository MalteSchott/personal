using System;
using System.Collections.Generic;
using System.Text;

namespace ShakeSpearScrabble
{
    class ScoredWord
    {
        public string Word { get; set; }
        public int Score { get; set; }

        public ScoredWord(string word, int score)
        {
            Word = word;
            Score = score;
        }

    }
}
