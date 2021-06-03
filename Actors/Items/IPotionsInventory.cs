using Merlin2d.Game.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin2.Actors.Items
{
    interface IPotionsInventory : IInventory
    {
        public int GetHighestPosition();
    }
}
