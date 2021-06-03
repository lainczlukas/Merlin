using Merlin2.Actors.Characters;
using Merlin2.Strategy;
using Merlin2d.Game.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin2.Commands
{
    public class Drunkenness : Command
    {
        private int counter = 0;
        private AbstractCharacter character;

        public Drunkenness(AbstractCharacter character)
        {
            this.character = character;
            character.SetSpeedStrategy(new ModifiedSpeedStrategy(-1));
        }
        public void Execute()
        {
            counter++;
            if (counter > 900)
            {
                character.SetSpeedStrategy(new NormalSpeedStrategy());
                character.RemoveEffect(this);
            }
        }
    }
}
