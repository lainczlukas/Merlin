using Merlin2d.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin2.Actors.State
{
    public interface IPlayerState
    {
        void Update();

        Animation GetAnimation();
    }
}
