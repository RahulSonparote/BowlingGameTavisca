using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.Business
{
    public interface IGame
    {
        void Roll(int pins);
        void Roll(int[] pins);
        int Score();
    }
}
