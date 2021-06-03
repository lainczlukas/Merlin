using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin2.Strategy
{
    public interface ISpeedStrategy
    {
        double GetSpeed(double speed);
    }
}
