using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.Business.Factory
{
    public class NoBonusCalculationStrategy : IBonusCalculationStrategy
    {
        public int CalculateBonus(List<int> nextTwoRuns)
        {
            return 0;
        }
    }
}
