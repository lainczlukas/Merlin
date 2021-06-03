using Merlin2.Actors.Characters;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin2.Actors.Objects
{
    public class Switch : AbstractActor, IObservable, IUsable
    {
        private Animation animationOn;
        private Animation animationOff;
        private bool isOn = true;
        private int isReady = 0;
        private List<IObserver> observers;
        private IActor user;

        public Switch(string actorName)
        {
            animationOn = new Animation("resources/sprites/crystal_on.png", 28, 32);
            animationOff = new Animation("resources/sprites/crystal_off.png", 28, 32);
            UpdateAnimation();
            SetName(actorName);
            observers = new List<IObserver>();

        }

        private void UpdateAnimation()
        {
            if (isOn)
            {
                isOn = false;
                SetAnimation(animationOff);
                animationOff.Start();
            } 
            else
            {
                isOn = true;
                SetAnimation(animationOn);
                animationOn.Start();
            }
        }

        public void AddDoor()
        {
            user = (Player)GetWorld().GetActors().Find(x => x.GetName() == "player");
            Door door = (Door)GetWorld().GetActors().Find(x => x.GetName() == "door1");
            Subscribe(door);
            door.Notify();
        }

        public void Subscribe(IObserver observer)
        {
            if (observer != null && observer is IActor)
            {
                observers.Add(observer);
            }
        }

        public void Unsubscribe(IObserver observer)
        {
            if (observer != null && observers.Contains(observer))
            {
                observers.Remove(observer);
            }
        }

        public override void Update()
        {
            if (isReady < 20)
            {
                isReady++;
            }
            if (Input.GetInstance().IsKeyDown(Input.Key.F) && isReady == 20)
            {
                Use(user);
                isReady = 0;
            } 
        }

        public void Use(IActor user)
        {
            if (IntersectsWithActor(user))
            {
                foreach (IObserver observer in observers)
                {
                    observer.Notify();
                    UpdateAnimation();
                }
            }
        }
    }
}
