using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin2.Strategy
{
    class ModifiedSpeedStrategy : ISpeedStrategy
    {
        private double speedMultimeter;

        public ModifiedSpeedStrategy(double speedMultimeter)
        {
            this.speedMultimeter = speedMultimeter;
        }
        public double GetSpeed(double speed)
        {
            return speedMultimeter * speed;
        }
    }
}
