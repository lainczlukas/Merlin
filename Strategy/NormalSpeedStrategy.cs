using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin2.Strategy
{
    public class NormalSpeedStrategy : ISpeedStrategy
    {
        public NormalSpeedStrategy()
        {
        }

        public double GetSpeed(double speed)
        {
            return speed;
        }
    }
}
