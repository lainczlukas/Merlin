using Merlin2.Actors.State;
using Merlin2.Commands;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin2.Actors.Characters
{
    public class Dragon : AbstractCharacter, IStalker
    {
        private ActorOrientation actorOrientation = ActorOrientation.FacingRight;
        private Animation animation;
        private Player player;
        private int step = 3;
        private Command moveLeft;
        private Command moveRight;
        private Command moveUp;
        private Command moveDown;

        public Dragon(string actorName)
        {
            SetName(actorName);
            animation = new Animation("resources/sprites/dragon_fly.png", 183, 124);
            SetAnimation(animation);
            animation.Start();
            moveLeft = new Move(this, step, -1, 0);
            moveRight = new Move(this, step, 1, 0);
            moveDown = new Move(this, step, 0, 1);
            moveUp = new Move(this, step, 0, -1);
            ChangeMaxHealth(200);
            ChangeHealth(200);
        }

        public void AddPrey()
        {
            player = (Player)GetWorld().GetActors().Find(x => x.GetName() == "player");
        }

        public override void Update()
        {
            base.Update();
            if (GetHealth() == 200)
            {
                SetPhysics(true);
                //animation = new Animation();
            }
            if (IntersectsWithActor(player) && player.GetState() is LivingState)
            {
                this.ChangeHealth(-1);
                player.ChangeHealth(-1);
            }
            if ((player.GetX() - (this.GetX() + GetWidth()) < 200 && player.GetX() - (this.GetX() + GetWidth())  > 0) && (player.GetY() - this.GetY() < 200 && player.GetY() - this.GetY() > -200))
            {
                if (actorOrientation == ActorOrientation.FacingLeft)
                {
                    animation.FlipAnimation();
                    actorOrientation = ActorOrientation.FacingRight;
                }
                moveRight.Execute();
                if (player.GetY() > (GetY() + GetHeight()))
                {
                    moveDown.Execute();
                }
                else if (player.GetY() < GetY())
                {
                    moveUp.Execute();
                }
            }
            else if ((this.GetX() - player.GetX() < 200 && this.GetX() - player.GetX() > 0) && (player.GetY() - this.GetY() < 200 && player.GetY() - this.GetY() > -200))
            {
                if (actorOrientation == ActorOrientation.FacingRight)
                {
                    animation.FlipAnimation();
                    actorOrientation = ActorOrientation.FacingLeft;
                }
                if (player.GetY() > (GetY() + GetHeight()))
                {
                    moveDown.Execute();
                }
                else if ((player.GetY() + player.GetWidth()) < GetY())
                {
                    moveUp.Execute();
                }
                moveLeft.Execute();
            }
        }
    }
}
