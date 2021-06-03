using Merlin2.Actors;
using Merlin2d.Game.Actions;
using System;
using Merlin2d.Game.Actors;
using Merlin2.Actors.Characters;

namespace Merlin2.Commands
{
    public class Move : Command
    {
        private AbstractCharacter movable;
        private int step;
        private int multipliedStep;
        private double fullStep;
        private int dx;
        private int dy;
        private double delta = 0.0;
        private double multiplier = 1.0;
        private double temp = 0.0;

        public Move(IActor movable, int step, int dx, int dy)
        {
            if (movable != null && movable is IMovable)
            {
                this.movable = (AbstractCharacter)movable;
                this.step = step;
                this.dx = dx;
                this.dy = dy;
                multipliedStep = step;
                fullStep = step;
                
            }
            else
            {
               throw new ArgumentException("error message");
            }
        }
        public void Execute()
        {
            if (multiplier != movable.GetSpeed())
            {
                multiplier = movable.GetSpeed();
                fullStep = step * multiplier;
                temp = fullStep % 1;
                temp *= 10000;
                temp = Math.Ceiling(temp);
                temp /= 10000;
                if (fullStep > 0)
                {
                    multipliedStep = (int)(Math.Floor(fullStep));
                }
                else
                {
                    multipliedStep = (int)(Math.Ceiling(fullStep));
                }
                
            }
            delta = delta + temp;
            
            while (delta >= 1)
            {
                delta--;
                movable.SetPosition(movable.GetX() + dx, movable.GetY() + dy);
            }

            while (delta <= -1)
            {
                delta++;
                movable.SetPosition(movable.GetX() - dx, movable.GetY() - dy);
            }

            movable.SetPosition(movable.GetX() + dx * multipliedStep, movable.GetY() + dy * multipliedStep);
            while (movable.GetWorld().IntersectWithWall(movable) == true)
            {
                if (multiplier >= 0)
                {
                    movable.SetPosition(movable.GetX() - dx, movable.GetY() - dy);
                } else
                {
                    movable.SetPosition(movable.GetX() + dx, movable.GetY() + dy);
                }
                
            }
        }
    }
}
