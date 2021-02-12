using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Calculator.Controllers
{
    [Route("api/calculator")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        public int[] Scores { get; set; }
        public CalculatorController()
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("redis"); //Change redis to localhost for Unit tests
            ISubscriber sub = redis.GetSubscriber();

            int[] rolls = new int[21];
            int rollIndex = 0;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5101/");

            sub.Subscribe("roll").OnMessage(channelMessage =>
            {
                string rollString = channelMessage.Message;
                if(rollString.Equals("NewGame"))
                {
                   rolls = new int[21];
                   rollIndex = 0;
                }else
                {
                    int roll = Int32.Parse(channelMessage.Message);
                    rolls[rollIndex] = roll;
                    Scores = Calculate(rolls);
                    rollIndex++;

                    //send scores and rolls as a single array
                    int[] scoresRolls = new int[31];
                    for (int i = 0; i < 10; i++)
                    {
                        scoresRolls[i] = Scores[i];
                    }
                    for (int i = 0; i < 21; i++)
                    {
                        scoresRolls[i + 10] = rolls[i];
                    }
                    string jsonString = JsonSerializer.Serialize(scoresRolls);
                    client.PostAsync("api/presenter/score", new StringContent(jsonString));
                }
            });
        }

        public int[] Calculate(int[] rolls)
        {
            int[] scores = new int[10];
            int score = 0;
            int rollIndex = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                //Check if strike
                if (rolls[rollIndex] == 10)
                {
                    score += GetSpecialScore(rollIndex, rolls);
                    rollIndex++;
                }
                else
                //Check if spare
                if (rolls[rollIndex] + rolls[rollIndex + 1] == 10)
                {
                    score += GetSpecialScore(rollIndex, rolls);
                    rollIndex += 2;
                }
                else
                {
                    score += GetStandardScore(rollIndex, rolls);
                    rollIndex += 2;
                }
                scores[frame] = score;
            }

            return scores;
        }

        private int GetStandardScore(int RollIndex, int[] rolls)
        {
            return rolls[RollIndex] + rolls[RollIndex + 1];
        }

        private int GetSpecialScore(int RollIndex, int[] rolls)
        {
            return rolls[RollIndex] + rolls[RollIndex + 1] + rolls[RollIndex + 2];
        }
    }
}
