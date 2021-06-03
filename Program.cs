using Merlin2.Actors.Characters;
using Merlin2.Actors.Items;
using Merlin2.Actors.Objects;
using Merlin2.Commands;
using Merlin2.Factories;
using Merlin2d.Game;
using Merlin2d.Game.Enums;
using System;

namespace Merlin2
{
    class Program
    {
        static void Main(string[] args)
        {
            //initial settings
            GameContainer container = new GameContainer("Remorseless winter", 1024, 768);
            IWorld world = container.GetWorld();
            world.SetFactory(new ActorFactory());
            world.SetPhysics(new Gravity());
            container.SetMap("resources/maps/map04.tmx");
            container.SetCameraZoom(1.6f);
            
            //setting camera follow style
            Action<IWorld> setCamera = world =>
            {
                world.CenterOn(world.GetActors().Find(a => a.GetName() == "player"));
                container.SetCameraFollowStyle(CameraFollowStyle.CenteredInsideMapPreferTop);
            };

            //setting initial references between objects
            Action<IWorld> setPrey = world =>
            {
                Skeleton skeleton = (Skeleton)world.GetActors().Find(a => a.GetName() == "skeleton");
                if (skeleton != null)
                {
                    skeleton.AddPrey();
                }
                Skeleton skeleton1 = (Skeleton)world.GetActors().Find(a => a.GetName() == "skeleton1");
                if (skeleton1 != null)
                {
                    skeleton1.AddPrey();
                }
                Skeleton skeleton2 = (Skeleton)world.GetActors().Find(a => a.GetName() == "skeleton2");
                if (skeleton2 != null)
                {
                    skeleton2.AddPrey();
                }
                Skeleton skeleton3 = (Skeleton)world.GetActors().Find(a => a.GetName() == "skeleton3");
                if (skeleton3 != null)
                {
                    skeleton3.AddPrey();
                }
                Ally ally = (Ally)world.GetActors().Find(a => a.GetName() == "ally");
                ally.AddPrey();
                Dragon dragon = (Dragon)world.GetActors().Find(a => a.GetName() == "dragon");
                dragon.AddPrey();
                Dragon boss = (Dragon)world.GetActors().Find(a => a.GetName() == "dragonBoss");
                boss.AddPrey();
            };

            Action<IWorld> setDoor = world =>
            {
                PressurePlate pressurePlate = (PressurePlate)world.GetActors().Find(x => x.GetName() == "pressurePlate");
                pressurePlate.PressurePlateInit();
                Switch switchButton = (Switch)world.GetActors().Find(x => x.GetName() == "switch");
                switchButton.AddDoor();
                Box box = (Box)world.GetActors().Find(x => x.GetName() == "box");
                box.AddCharacters();
            };

            Action<IWorld> setIems = world =>
            {
                HealingPotion potion = (HealingPotion)world.GetActors().Find(a => a.GetName() == "potion");
                if (potion != null)
                {
                    potion.AddPlayer();
                }
                HealingPotion potion1 = (HealingPotion)world.GetActors().Find(a => a.GetName() == "potion1");
                if (potion1 != null)
                {
                    potion1.AddPlayer();
                }
                ManaPotion mPotion = (ManaPotion)world.GetActors().Find(a => a.GetName() == "manaPotion");
                if (mPotion != null)
                {
                    mPotion.AddPlayer();
                }
                Mushroom mushroom = (Mushroom)world.GetActors().Find(a => a.GetName() == "mushroom");
                if (mushroom != null)
                {
                    mushroom.AddPlayer();
                }
                Food food = (Food)world.GetActors().Find(a => a.GetName() == "food");
                if (food != null)
                {
                    food.AddPlayer();
                }
                Alcohol alcohol = (Alcohol)world.GetActors().Find(a => a.GetName() == "alcohol");
                if (alcohol != null)
                {
                    alcohol.AddPlayer();
                }
                Kettle kettle = (Kettle)world.GetActors().Find(a => a.GetName() == "kettle");
                kettle.AddPlayer();
                Fountain fountain = (Fountain)world.GetActors().Find(a => a.GetName() == "fountain");
                fountain.AddPlayer();
            };

            world.AddInitAction(setCamera);
            world.AddInitAction(setPrey);
            world.AddInitAction(setDoor);
            world.AddInitAction(setIems);

            //starting game loop
            container.Run();
        }
    }
}
