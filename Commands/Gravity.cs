using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Merlin2.Commands
{
    public class Gravity : IPhysics
    {
        private IWorld world;
        private IAction<IActor> fall = new Fall<IActor>(3); 
        public void Execute()
        {
            foreach (IActor actor in world.GetActors().Where(x => x.IsAffectedByPhysics()))
            {
                fall.Execute(actor);
            }
        }

        public void SetWorld(IWorld world)
        {
            this.world = world;
        }
    }
}
