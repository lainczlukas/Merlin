using Merlin2.Actors.Characters;
using Merlin2d.Game.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin2.Commands
{
    public class FireDamage : Command
    {
        private AbstractCharacter character;
        public FireDamage(AbstractCharacter character)
        {
            this.character = character;
        }

        public void Execute()
        {
            character.ChangeHealth(-50);
            character.RemoveEffect(this);
        }
    }
}
