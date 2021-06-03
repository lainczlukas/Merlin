using Merlin2.Strategy;
using Merlin2d.Game.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Merlin2.Actors.Characters
{
    public abstract class AbstractCharacter : AbstractActor, ICharacter
    {
        private int health = 100;
        private int maxHealth = 100;
        protected int mana = 100;
        protected int maxMana = 100;

        private List<Command> effects = new List<Command>();

        private double speed = 1;
        private ISpeedStrategy speedStrategy = new NormalSpeedStrategy();


        public AbstractCharacter()
        {
        }

        public void ChangeMaxHealth(int delta)
        {
            maxHealth += delta;
        }

        protected int GetMaxMana()
        {
            return maxMana;
        }

        public void ChangeMaxMana(int delta)
        {
            maxMana += delta;
        }

        public void ChangeHealth(int delta)
        {
            if (health > 0)
            {
                if (delta > 0)
                {
                    for (int i = 0; i < delta; i++)
                    {
                        if (health == maxHealth)
                        {
                            break;
                        }
                        health++;
                    }
                }
                else
                {
                    for (int i = 0; i > delta; i--)
                    {
                        if (health == 0)
                        {
                            break;
                        }
                        health--;
                    }
                }
            }
            if (health == 0)
            {
                Die();
            }
        }

        public virtual void Die()
        {
            GetWorld().RemoveActor(this);
        }

        public int GetHealth()
        {
            return health;
        }

        public void AddEffect(Command effect)
        {
            effects.Add(effect);
        }

        public void RemoveEffect(Command effect)
        {
            effects.Remove(effect);
        }

        public override void Update()
        {
            //effects.ForEach(e => e.Execute());
            for (int i = 0; i < effects.Count(); i++)
            {
                effects[i].Execute();
            }
        }

        public void SetSpeedStrategy(ISpeedStrategy speedStrategy)
        {
            this.speedStrategy = speedStrategy;
        }

        public double GetSpeed()
        {
            return speedStrategy.GetSpeed(speed);
        }
    }
}
