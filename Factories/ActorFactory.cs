using Merlin2.Actors;
using Merlin2.Actors.Characters;
using Merlin2.Actors.Items;
using Merlin2.Actors.Objects;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System;

namespace Merlin2.Factories
{
    public class ActorFactory : IFactory
    {
        public IActor Create(string actorType, string actorName, int x, int y)
        {
            if (actorType == "Player")
            {
                Player player = new Player(actorName);
                player.SetPosition(x, y);
                return player;
            }
            else if (actorType == "Skeleton")
            {
                Skeleton skeleton = new Skeleton(actorName);
                skeleton.SetPosition(x, y);
                return skeleton;
            }
            else if (actorType == "PressurePlate")
            {
                PressurePlate pressurePlate = new PressurePlate(actorName);
                pressurePlate.SetPosition(x, y);
                return pressurePlate;
            }
            else if (actorType == "Door")
            {
                Door door = new Door(actorName);
                door.SetPosition(x, y);
                return door;
            }
            else if (actorType == "Switch")
            {
                Switch switchButton = new Switch(actorName);
                switchButton.SetPosition(x, y);
                return switchButton;
            }
            else if (actorType == "Box")
            {
                Box box = new Box(actorName);
                box.SetPosition(x, y);
                return box;
            }
            else if (actorType == "Potion")
            {
                HealingPotion potion = new HealingPotion(actorName);
                potion.SetPosition(x, y);
                return potion;
            }
            else if (actorType == "ManaPotion")
            {
                ManaPotion potion = new ManaPotion(actorName);
                potion.SetPosition(x, y);
                return potion;
            }
            else if (actorType == "Ally")
            {
                Ally ally = new Ally(actorName);
                ally.SetPosition(x, y);
                return ally;
            }
            else if (actorType == "Mushroom")
            {
                Mushroom mushroom = new Mushroom(actorName);
                mushroom.SetPosition(x, y);
                return mushroom;
            }
            else if (actorType == "Food")
            {
                Food food = new Food(actorName);
                food.SetPosition(x, y);
                return food;
            }
            else if (actorType == "Alcohol")
            {
                Alcohol alcohol = new Alcohol(actorName);
                alcohol.SetPosition(x, y);
                return alcohol;
            }
            else if (actorType == "Dragon")
            {
                Dragon dragon = new Dragon(actorName);
                dragon.SetPosition(x, y);
                return dragon;
            }
            else if (actorType == "Kettle")
            {
                Kettle kettle = new Kettle();
                kettle.SetName(actorName);
                kettle.SetPosition(x, y);
                return kettle;
            }
            else if (actorType == "Fountain")
            {
                Fountain fountain = new Fountain();
                fountain.SetName(actorName);
                fountain.SetPosition(x, y);
                return fountain;
            }
            else if (actorType == "Princess")
            {
                Princess princess = new Princess();
                princess.SetName(actorName);
                princess.SetPosition(x, y);
                return princess;
            }
            else
            {
                return null;
            }
        }
    }
}
