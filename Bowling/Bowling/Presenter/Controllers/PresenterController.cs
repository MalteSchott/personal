using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presenter.Controllers
{
    [Route("api/presenter/score")]
    [ApiController]
    public class PresenterController : ControllerBase
    {
        public string gameString { get; set; }
        public PresenterController()
        {
           
        }

        // POST /presenter/score>
        [HttpPost]
        public void Post([FromBody] string bowlingGameJson)
        {
            gameString = presentScore(bowlingGameJson);
        }

        public String presentScore(string bowlingGameJson)
        {
            int[] scoresRolls = JsonSerializer.Deserialize<int[]>(bowlingGameJson);
            int[] scores = new int[10];
            int[] rolls = new int[21];
            for (int i = 0; i < 10; i++)
            {
                scores[i] = scoresRolls[i];
            }
            for (int i = 0; i < 21; i++)
            {
                rolls[i] = scoresRolls[i + 10];
            }

            int rollIndex = 0;
            String game = "";
            for (int i = 0; i < scores.Length; i++)
            {
                string frame = null;
                //Check if last frame
                if (i == 9)
                {
                    frame = "[" + rolls[rollIndex] + "|" + rolls[rollIndex + 1] + "|" + rolls[rollIndex + 2] + "=>" + scores[i] + "]";
                }else
                {
                    //Check if strike
                    if (rolls[rollIndex] == 10)
                    {
                        frame = "[10=>" + scores[i] + "]";
                        rollIndex++;
                    }
                    else
                    {
                        frame = "[" + rolls[rollIndex] + "|" + rolls[rollIndex + 1] + "=>" + scores[i] + "]";
                        rollIndex += 2;
                    }
                }
                game += frame;
            }
            return game;
        }

        [HttpGet]
        public String Get()
        {
            return gameString;
        }
    }
}
