using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.Business.Factory
{
    public interface IBonusCalculationStrategy
    {
        int CalculateBonus(List<int> nextTwoRuns);
    }
}
