using Merlin2.Actors.Characters;
using Merlin2.Actors.Objects;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Items;

namespace Merlin2.Actors.Items
{
    public class Food : AbstractObject, IItem, IUsable
    {
        private Animation animation;

        public Food(string actorName)
        {
            SetName(actorName);
            animation = new Animation("resources/sprites/food.png", 46, 34);
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
            player.ChangeMaxHealth(20);
            player.ChangeMaxMana(20);
            player.GetBackpack().RemoveItem(this);
        }
    }
}
