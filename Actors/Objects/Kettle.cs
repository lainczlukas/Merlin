using Merlin2.Actors.Characters;
using Merlin2.Actors.Items;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Items;
using System;

namespace Merlin2.Actors.Objects
{
    public class Kettle : AbstractObject
    {
        private Animation animation;
        private int counter = 0;

        public Kettle()
        {
            animation = new Animation("resources/sprites/kettle_hot.png", 64, 49);
            SetAnimation(animation);
            animation.Start();
        }

        public override void Update()
        {
            if (counter < 20)
            {
                counter++;
            }
            if (Input.GetInstance().IsKeyDown(Input.Key.F) && IntersectsWithActor(player) && counter == 20)
            {
                counter = 0;
                IPotionsInventory backpack = (IPotionsInventory)player.GetBackpack();
                int backpackCapacity = backpack.GetHighestPosition();
                IPotion potion;
                IItem item;
                for (int i = 0; i < backpackCapacity; i++)
                {                    
                    item = backpack.GetItem();
                    if (item != null)
                    {
                        backpack.ShiftLeft();
                        if (item is IPotion)
                        {
                            potion = (IPotion)item;
                            potion.Refill();
                        }
                    }                   
                }                
            }
        }
    }
}
