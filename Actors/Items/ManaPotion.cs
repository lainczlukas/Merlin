using Merlin2.Actors.Characters;
using Merlin2.Actors.Objects;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin2.Actors.Items
{
    public class ManaPotion : AbstractObject, IPotion, IUsable
    {
        private Animation animationFull;
        private Animation animationEmpty;
        private bool used = false;

        public ManaPotion(string actorName)
        {
            SetName(actorName);
            animationFull = new Animation("resources/sprites/potion_mana_full.png", 21, 26);
            animationEmpty = new Animation("resources/sprites/potion_empty.png", 21, 24);
            SetAnimation(animationFull);
            animationFull.Start();
        }

        public void Refill()
        {
            SetAnimation(animationFull);
            animationFull.Start();
            used = false;
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
            if (!used)
            {
                SetAnimation(animationEmpty);
                animationEmpty.Start();
                player.ChangeMana(40);
                used = true;
            }
        }
    }
}
