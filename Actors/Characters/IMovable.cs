using Merlin2.Strategy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin2.Actors.Characters
{
    public interface IMovable
    {
        void SetSpeedStrategy(ISpeedStrategy speedStrategy);
        double GetSpeed();
    }
}
