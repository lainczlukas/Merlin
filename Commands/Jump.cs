using Merlin2.Actors;
using Merlin2.Actors.Characters;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin2.Commands
{
    public class Jump : Command
    {
        private IActor movable;
        private int step;
        private int dx;
        private int dy;

        public Jump(IMovable movable, int step, int dx, int dy)
        {
            if (movable != null && movable is IActor)
            {
                this.movable = (IActor)movable;
                this.step = step;
                this.dx = dx;
                this.dy = dy;
            }
            else
            {
                throw new ArgumentException("error message");
            }
        }

        public void Execute()
        {
            movable.SetPosition(movable.GetX() + dx * step, movable.GetY() + dy * step);
            while (movable.GetWorld().IntersectWithWall(movable) == true)
            {
                movable.SetPosition(movable.GetX() - dx, movable.GetY() - dy);
            }
        }
    }
}
