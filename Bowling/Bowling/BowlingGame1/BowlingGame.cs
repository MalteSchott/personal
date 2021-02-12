using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame1
{
    public class BowlingGame
    {
        private int[] rolls = new int[21];
        private int currentRoll = 0;

        public int Score { 
            get
            {
                int score = 0;
                int RollIndex = 0;

                for(int frame = 0; frame < 10; frame++ )
                {
                    //Check if strike
                    if(rolls[RollIndex] == 10)
                    {
                        score += GetSpecialScore(RollIndex);
                        RollIndex++;
                    }
                    else
                    //Check if spare
                    if (rolls[RollIndex] + rolls[RollIndex + 1] == 10)
                    {
                        score += GetSpecialScore(RollIndex);
                        RollIndex += 2;
                    }
                    else
                    {
                        score += GetStandardScore(RollIndex);
                        RollIndex += 2;
                    }
                }
                return score;
            }
        }

        private int GetStandardScore(int RollIndex)
        {
            return rolls[RollIndex] + rolls[RollIndex + 1];
        }

        private int GetSpecialScore(int RollIndex)
        {
            return rolls[RollIndex] + rolls[RollIndex + 1] + rolls[RollIndex + 2];
        }
        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }
    }
}
