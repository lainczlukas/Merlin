using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin2.Actors.Characters
{
    public abstract class AbstractObject : AbstractActor, IObject
    {
        protected Player player;
        public void AddPlayer()
        {            
            player = (Player)GetWorld().GetActors().Find(x => x.GetName() == "player");          
        }
    }
}
