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
    public class Mushroom : AbstractObject, IItem, IUsable
    {
        private Animation animation;

        public Mushroom(string actorName)
        {
            SetName(actorName);
            animation = new Animation("resources/sprites/mushroom.png", 25, 23);
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
            player.AddEffect(new Haste(player));
            player.GetBackpack().RemoveItem(this);
        }
    }
}
