using Merlin2.Commands;
using Merlin2.Strategy;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin2.Actors.Characters
{
    public class Ally : AbstractCharacter, IMovable, IStalker
    {
        private Animation animation;
        private Command moveLeft;
        private Command moveRigft;
        private Message curMessage;
        private Color red = new Color(255, 255, 255);
        private bool said = false;
        private int counter = 0;
        private Player player;
        private ActorOrientation actorOrientation = ActorOrientation.FacingRight;

        public Ally(string actorName)
        {
            SetName(actorName);
            SetPhysics(true);
            animation = new Animation("resources/sprites/player.png", 28, 47);
            SetAnimation(animation);
            animation.Start();
            moveLeft = new Move(this, 3, -1, 0);
            moveRigft = new Move(this, 4, 1, 0);
        }

        public void AddPrey()
        {
            player = (Player)GetWorld().GetActors().Find(x => x.GetName() == "player");
        }

        public override void Update()
        {
            counter++;
            if (GetX() > 150 && !said)
            {
                if (actorOrientation == ActorOrientation.FacingRight)
                {
                    animation.FlipAnimation();
                    actorOrientation = ActorOrientation.FacingLeft;
                    animation.Start();
                }
                moveLeft.Execute();
            } 
            else if (GetX() <= 150 && !said)
            {
                animation.Stop();
                curMessage = new Message("Wake up Merlin!", -30, -30, 20, red, (Merlin2d.Game.Enums.MessageDuration)90);
                curMessage.SetAnchorPoint(this);
                GetWorld().AddMessage(curMessage);
                said = true;
            }
            else if (GetX() > 500 && said)
            {
                player.WakeUp();
                GetWorld().RemoveActor(this);
            }

            if (counter == 210)
            {
                curMessage = new Message("Skeletons kidnapped our princess!", -30, -30, 20, red, (Merlin2d.Game.Enums.MessageDuration)90);
                curMessage.SetAnchorPoint(this);
                GetWorld().AddMessage(curMessage);
            }
            else if (counter >= 330)
            {
                if (actorOrientation == ActorOrientation.FacingLeft)
                {
                    animation.FlipAnimation();
                    actorOrientation = ActorOrientation.FacingRight;
                    animation.Start();
                }
                moveRigft.Execute();
                
            }
        } 
    }
}
