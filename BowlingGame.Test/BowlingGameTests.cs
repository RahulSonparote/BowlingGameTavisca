using BowlingGame.Business;
using System;
using Xunit;

namespace BowlingGame.Test
{
    public class BowlingGameTests
    {
        private readonly Game objGame;
        public BowlingGameTests()
        {
            objGame = new Game();
        }
        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                objGame.Roll(pins);
            }
        }

        private void RollSpare()
        {
            objGame.Roll(6);
            objGame.Roll(4);
        }

        [Fact]
        public void TestBowlingGameClass()
        {
            Assert.IsType<Game>(objGame);
        }

        [Fact]
        public void TestGutterGame()
        {
            RollMany(20, 0);
            Assert.Equal(0, objGame.Score());
        }

        [Fact]
        public void TestAllOnes()
        {
            RollMany(20, 1);
            Assert.Equal(20, objGame.Score());
        }

        [Fact]
        public void TestOneSpare()
        {
            RollSpare();
            objGame.Roll(4);
            RollMany(17, 0);
            Assert.Equal(18, objGame.Score());
        }

        [Fact]
        public void TestOneStrike()
        {
            objGame.Roll(10);
            objGame.Roll(4);
            objGame.Roll(5);
            RollMany(17, 0);
            Assert.Equal(28, objGame.Score());
        }

        [Fact]
        public void TestPerfectGame()
        {
            RollMany(12, 10);
            Assert.Equal(300, objGame.Score());
        }
    }
}
