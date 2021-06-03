using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin2.Actors.Characters
{
    public interface IWizard : IActor
    {
        void ChangeMana(int delta);
        int GetMana();
        
        void Cast();

    }
}
