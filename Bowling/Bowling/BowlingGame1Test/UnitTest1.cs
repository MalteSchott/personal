using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BowlingGame1;

namespace BowlingGame1Test
{
    [TestClass]
    public class UnitTest1
    {

        private BowlingGame game;

        [TestInitialize]
        public void Initialize()
        {
            game = new BowlingGame();
        }

        [TestMethod]
        public void CanRollGutterGame()
        {
            RollMany(20,0);
            Assert.AreEqual(0, game.Score);
        }

        [TestMethod]
        public void CanRollAllTwos()
        {
            RollMany(20,2);
            Assert.AreEqual(40, game.Score);
        }

        [TestMethod]
        public void CanRollStrike()
        {
            game.Roll(10);
            game.Roll(4);
            game.Roll(5);
            Assert.AreEqual(28, game.Score);
        }

        [TestMethod]
        public void CanRollSpare()
        {
            game.Roll(4);
            game.Roll(6);
            game.Roll(3);
            game.Roll(2);
            Assert.AreEqual(18, game.Score);
        }

        [TestMethod]
        public void CanRollPerfectGame()
        {
            RollMany(12,10);
            Assert.AreEqual(300, game.Score);
        }

        [TestMethod]
        public void CanRollAllSpares()
        {
            RollMany(21, 5);
            Assert.AreEqual(150, game.Score);
        }

        [TestMethod]
        public void CanRollSequence()
        {
            game.Roll(10);
            game.Roll(8);
            game.Roll(2);
            game.Roll(4);
            game.Roll(0);

            Assert.AreEqual(38, game.Score);
        }

        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                game.Roll(pins);
            }
        }
    }
}
