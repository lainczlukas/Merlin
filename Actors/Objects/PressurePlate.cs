using Merlin2.Actors.Characters;
using Merlin2.Actors.Objects;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Merlin2.Actors.Objects
{
    public class PressurePlate : AbstractActor, IObservable
    {
        private Animation animationOn;
        private Animation animationOff;
        private List<IObserver> observers;
        private List<ICharacter> characters; 
        private bool isPressed = false;
        private bool isReady;

        public PressurePlate(string actorName)
        {
            animationOn = new Animation("resources/sprites/source_on.png", 64, 23);
            animationOff = new Animation("resources/sprites/source_off.png", 64, 23);
            SetAnimation(animationOn);
            animationOn.Start();
            SetName(actorName);
            observers = new List<IObserver>();
            characters = new List<ICharacter>();
        }

        public void PressurePlateInit()
        {
            foreach (IActor actor in GetWorld().GetActors())
            {
                if (actor is ICharacter)
                {
                    characters.Add((ICharacter)actor);
                }
            }
            Door door = (Door)GetWorld().GetActors().Find(x => x.GetName() == "door");
            Subscribe(door);
            door.Notify();
        }

        public void Subscribe(IObserver observer)
        {
            if(observer != null && observer is IActor)
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

            if (isPressed)
            {
                isReady = true;
                foreach (ICharacter character in characters)
                {
                    if (IntersectsWithActor((IActor)character))
                    {
                        isReady = false;
                    }
                }

                if (isReady)
                {
                    foreach (IObserver obsever in observers)
                    {
                        obsever.Notify();
                    }
                    isPressed = false;
                }
            }
            else
            {
                foreach (ICharacter character in characters)
                {
                    if (IntersectsWithActor((IActor)character))
                    {
                        foreach (IObserver obsever in observers)
                        {
                            obsever.Notify();
                        }
                        isPressed = true;
                        break;
                    }
                }
            }
        }
    }
}
