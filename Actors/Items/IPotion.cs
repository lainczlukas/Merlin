using Merlin2d.Game.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin2.Actors.Items
{
    public interface IPotion : IItem
    {
        public void Refill();
    }
}
