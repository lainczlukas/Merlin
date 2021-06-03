using Merlin2.Actors.Characters;
using Merlin2.Actors.Objects;
using Merlin2d.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin2.Actors.Objects
{
    public class Door : AbstractActor, IObserver
    {
        private Animation animationOpen;
        private Animation animationClosed;
        private bool isOpen = true;

        public Door(string actorName)
        {
            SetName(actorName);
            animationOpen = new Animation("resources/sprites/door.png", 32, 96);
            animationClosed = new Animation("resources/sprites/door_right.png", 53, 96);
        }

        private void OpenDoor()
        {
            isOpen = true;
            SetAnimation(animationOpen);
            animationOpen.Start();
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    GetWorld().SetWall(GetX()/16 + j, GetY()/16 + i, false);
                }
            }
        }

        private void CloseDoor()
        {
            isOpen = false;
            SetAnimation(animationClosed);
            animationClosed.Start();
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    GetWorld().SetWall(GetX()/16 + j, GetY()/16 + i, true);
                }
            }
        }
        public void Notify()
        {
            if (isOpen)
            {
                CloseDoor();
            }
            else 
            {
                OpenDoor();
            }
        }

        public override void Update()
        {
        }
    }
}
