using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.Business.Factory
{
    public class BonusCalculationStrategyFactory
    {
        public IBonusCalculationStrategy GetBonusCalculationStrategy(bool isStrike, bool isSpare)
        {
            if (isStrike)
                return new StrikeBonusCalculationStrategy();
            else if (isSpare)
                return new SpareBonusCalculationStrategy();
            return new NoBonusCalculationStrategy();
        }
    }
}
