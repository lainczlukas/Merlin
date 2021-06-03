using Merlin2.Actors.Characters;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Merlin2.Actors.Objects
{
    public class Princess : AbstractActor
    {
        private IActor enemy;
        private Animation animation;
        private Message msg;

        public Princess()
        {
            animation = new Animation("resources/sprites/princess.png", 25, 47);
            SetAnimation(animation);
            animation.FlipAnimation();
            animation.Start();
            msg = new Message("You saved me, my hero! press esc", -20, -20, 20, new Color(255,255,255), Merlin2d.Game.Enums.MessageDuration.Indefinite);
            msg.SetAnchorPoint(this);
        }

        public override void Update()
        {
            enemy = GetWorld().GetActors().Find(a => a is Dragon);
            if (enemy == null)
            {
                enemy = GetWorld().GetActors().Find(a => a is Skeleton);
                if (enemy == null)
                {
                    GetWorld().AddMessage(msg);
                }               
            }
        }
    }
}
