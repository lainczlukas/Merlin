using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin2.Actors.Objects
{
    interface IUsable
    {
        void Use(IActor user);
    }
}
