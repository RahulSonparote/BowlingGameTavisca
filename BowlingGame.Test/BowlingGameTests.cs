using BowlingGame.Business;
using System;
using System.Collections.Generic;
using Xunit;

namespace BowlingGame.Test
{
    public class BowlingGameTests
    {
        private readonly Game objGame;
        private readonly BowlingScoreCalculator scoreCalculator;
        public BowlingGameTests()
        {
            objGame = new Game();
            scoreCalculator = new BowlingScoreCalculator();
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

        [Fact]
        public void TestOneSpareCalculation()
        {
            var allrolls = new Dictionary<int, List<int>>
            {
                { 1, new List<int>{4,6} },
                { 2, new List<int>{4} }
            };
            Assert.Equal(18, scoreCalculator.CalculateGameScore(allrolls));
        }

        [Fact]
        public void TestOneStrikrCalculation()
        {
            var allrolls = new Dictionary<int, List<int>>
            {
                { 1, new List<int>{10} },
                { 2, new List<int>{5,4} }
            };

            Assert.Equal(28, scoreCalculator.CalculateGameScore(allrolls));
        }

        [Fact]
        public void TestGutterCalculation()
        {
            var allrolls = new Dictionary<int, List<int>>
            {
                { 1, new List<int>{0,0} },
                { 2, new List<int>{0,0} },
                { 3, new List<int>{0,0} },
                { 4, new List<int>{0,0} },
                { 5, new List<int>{0,0} },
                { 6, new List<int>{0,0} },
                { 7, new List<int>{0,0} },
                { 8, new List<int>{0,0} },
                { 9, new List<int>{0,0} },
                { 10, new List<int>{0,0} }
            };
            Assert.Equal(0, scoreCalculator.CalculateGameScore(allrolls));
        }

        [Fact]
        public void TestAllStrikeCalculation()
        {
            var allrolls = new Dictionary<int, List<int>>
            {
                { 1, new List<int>{10} },
                { 2, new List<int>{10} },
                { 3, new List<int>{10} },
                { 4, new List<int>{10} },
                { 5, new List<int>{10} },
                { 6, new List<int>{10} },
                { 7, new List<int>{10} },
                { 8, new List<int>{10} },
                { 9, new List<int>{10} },
                { 10, new List<int>{10} },
                { 11, new List<int>{10} }
            };
            Assert.Equal(300, scoreCalculator.CalculateGameScore(allrolls));
        }
        [Fact]
        public void TestAllOne()
        {
            var allrolls = new Dictionary<int, List<int>>
            {
                { 1, new List<int>{1,1} },
                { 2, new List<int>{1,1} },
                { 3, new List<int>{1,1} },
                { 4, new List<int>{1,1} },
                { 5, new List<int>{1,1} },
                { 6, new List<int>{1,1} },
                { 7, new List<int>{1,1} },
                { 8, new List<int>{1,1} },
                { 9, new List<int>{1,1} },
                { 10, new List<int>{1,1} }
            };
            Assert.Equal(20, scoreCalculator.CalculateGameScore(allrolls));
        }
    }
}
