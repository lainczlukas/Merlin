using Merlin2.Actors.Characters;
using Merlin2d.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin2.Actors.Objects
{
    public class Fountain : AbstractObject
    {
        private Animation animation;

        public Fountain()
        {
            animation = new Animation("resources/sprites/fountain.png", 64, 56);
            SetAnimation(animation);
            animation.Start();
        }

        public override void Update()
        {
            if (IntersectsWithActor(player))
            {
                player.ChangeHealth(1);
            }
        }
    }
}
