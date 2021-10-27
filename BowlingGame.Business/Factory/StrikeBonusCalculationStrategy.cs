using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingGame.Business.Factory
{
    public class StrikeBonusCalculationStrategy : IBonusCalculationStrategy
    {
        public int CalculateBonus(List<int> nextTwoRuns)
        {
            return nextTwoRuns.Sum();
        }
     }
}
