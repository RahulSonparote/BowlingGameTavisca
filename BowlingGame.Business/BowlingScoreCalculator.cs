using BowlingGame.Business.Factory;
using System.Collections.Generic;
using System.Linq;

namespace BowlingGame.Business
{
    public class BowlingScoreCalculator
    {
        #region "Variable Declarations"
        private readonly BonusCalculationStrategyFactory bonusCalculationStrategyFactory;
        #endregion

        #region "Constructor"
        public BowlingScoreCalculator()
        {
            bonusCalculationStrategyFactory = new BonusCalculationStrategyFactory();
        }
        #endregion

        #region "Bussiness Logic"
        public int CalculateGameScore(Dictionary<int, List<int>> frameScores)
        {
            var finalScore = 0;
            var currentIndex = 0;
            try
            {
                foreach (var frame in frameScores)
                {
                    bool isStrike = IsStrike(frame);
                    var isSpare = IsSpare(frame);
                    var nextFrameRolls = GetNextRollValues(frameScores, currentIndex);
                    var bonusStrategy = bonusCalculationStrategyFactory.GetBonusCalculationStrategy(isStrike, isSpare);
                    var frameScore = IsStrike(frame) ? frame.Value.First() : frame.Value.Sum();
                    finalScore += frameScore + bonusStrategy.CalculateBonus(nextFrameRolls);
                    currentIndex++;
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            return finalScore;

        }
        #endregion

        #region "Helper Methods"
        private bool IsStrike(KeyValuePair<int, List<int>> frame)
        {
            return frame.Value.First() == 10;
        }
        private bool IsSpare(KeyValuePair<int, List<int>> frame)
        {
            return frame.Value.Sum() == 10;
        }
        private List<int> GetNextRollValues(Dictionary<int, List<int>> frameScores, int currentIndex)
        {
            var nextFrameRolls = new List<int>();
            if (frameScores.Count > currentIndex + 1)
            {
                var nextFrame = frameScores.ElementAt(currentIndex + 1).Value;
                if (nextFrame.First() != 10)
                    nextFrameRolls.AddRange(nextFrame);
                else
                {
                    nextFrameRolls.Add(nextFrame.First());
                    if (frameScores.Count > currentIndex + 2)
                    {
                        var nextSecondFrame = frameScores.ElementAt(currentIndex + 2).Value;
                        nextFrameRolls.Add(nextSecondFrame.First());
                    }
                }
            }
            return nextFrameRolls;
        }
        #endregion
    }
}
