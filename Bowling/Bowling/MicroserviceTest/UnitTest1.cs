using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.Controllers;
using Presenter.Controllers;
using Rolls.Controllers;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace MicroserviceTest
{
    [TestClass]
    public class UnitTest1
    {
        private CalculatorController calculatorService;
        private PresenterController presenterService;
        private RollsController rollsService;

        [TestInitialize]
        public void Initialize()
        {
            calculatorService = new CalculatorController();
            presenterService = new PresenterController();
            rollsService = new RollsController();
        }

        [TestMethod]
        public void CanCalculateRoll()
        {
            int[] rolls = new int[21];
            rolls[0] = 4;
            rolls[1] = 5;
            rollsService.Post(rolls);
            Task.Delay(50).Wait();
            int[] scores = calculatorService.Scores;
            Assert.AreEqual(9, scores[9]);
        }

        [TestMethod]

        public void CanRollAllTwos()
        {
            RollMany(20, 2);
            Task.Delay(50).Wait();
            int[] scores = calculatorService.Scores;
            Assert.AreEqual(40, scores[9]);
        }

        [TestMethod]
        public void CanRollStrike()
        {
            int[] rolls = new int[21];
            rolls[0] = 10;
            rolls[1] = 4;
            rolls[2] = 5;
            rollsService.Post(rolls);
            Task.Delay(50).Wait();
            int[] scores = calculatorService.Scores;
            Assert.AreEqual(28, scores[9]);
        }

        [TestMethod]
        public void CanRollSpare()
        {
            int[] rolls = new int[21];
            rolls[0] = 4;
            rolls[1] = 6;
            rolls[2] = 3;
            rolls[3] = 2;
            rollsService.Post(rolls);
            Task.Delay(50).Wait();
            int[] scores = calculatorService.Scores;
            Assert.AreEqual(18, scores[9]);
        }

        [TestMethod]
        public void CanRollPerfectGame()
        {
            RollMany(12, 10);
            Task.Delay(50).Wait();
            int[] scores = calculatorService.Scores;
            Assert.AreEqual(300, scores[9]);
        }

        [TestMethod]
        public void CanPresentPerfectGame()
        {
            int[] rolls = new int[21];
            for (int i = 0; i < 12; i++)
            {
                rolls[i] = 10;
            }
            rollsService.Post(rolls);

            int[] scores = calculatorService.Scores;
            int[] scoresRolls = new int[31];
            for (int i = 0; i < 10; i++)
            {
                scoresRolls[i] = scores[i];
            }
            for (int i = 0; i < 21; i++)
            {
                scoresRolls[i + 10] = rolls[i];
            }
            string jsonString = JsonSerializer.Serialize(scoresRolls);
            presenterService.Post(jsonString);
            String gameCheck = "[10=>30][10=>60][10=>90][10=>120][10=>150][10=>180][10=>210][10=>240][10=>270][10|10|10=>300]";
            Assert.AreEqual(gameCheck, presenterService.gameString);
        }

        private void RollMany(int rollsAmount, int pins)
        {
            int[] rolls = new int[21];
            for (int i = 0; i < rollsAmount; i++)
            {
                rolls[i] = pins;
            }
            rollsService.Post(rolls);
        }
    }
}
