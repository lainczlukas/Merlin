using Merlin2.Actors.Characters;
using Merlin2.Actors.Objects;
using Merlin2.Commands;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin2.Actors.Items
{
    public class Alcohol : AbstractObject, IItem, IUsable
    {
        private Animation animation;

        public Alcohol(string actorName)
        {
            SetName(actorName);
            animation = new Animation("resources/sprites/alcohol.png", 14, 33);
            SetAnimation(animation);
            animation.Start();
        }

        public override void Update()
        {
            if (IntersectsWithActor(player) && Input.GetInstance().IsKeyDown(Input.Key.F))
            {
                player.GetBackpack().AddItem(this);
                player.GetWorld().RemoveActor(this);
            }
        }

        public void Use(IActor user)
        {
            player.AddEffect(new Drunkenness(player));
            player.GetBackpack().RemoveItem(this);
        }
    }
}
