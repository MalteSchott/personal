using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rolls.Controllers
{
    [Route("api/rolls")]
    [ApiController]
    public class RollsController : ControllerBase
    {
        ISubscriber sub;

        public RollsController() {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("redis"); //Change redis to localhost for Unit tests
            sub = redis.GetSubscriber();
        }

        // POST /rolls>
        [HttpPost]
        public void Post([FromBody] int[] rolls)
        {
            sub.Publish("roll", "NewGame");
            for(int i = 0; i < rolls.Length; i++)
            {
                int roll = rolls[i];
                sub.Publish("roll", roll);
            }
        }
    }
}
