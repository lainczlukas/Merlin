using Merlin2.Actors.State;
using Merlin2.Commands;
using Merlin2.Strategy;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using System;

namespace Merlin2.Actors.Characters
{
    public class Skeleton : AbstractCharacter, IMovable, IStalker
    {
        private Command moveLeft;
        private Command moveRight;
        private Animation animation;
        ActorOrientation actorOrientation = ActorOrientation.FacingRight;
        private Random random = new Random();
        private Player player;
        private int counter = 59;
        private int x;
        private int step = 2;

        public Skeleton(string name)
        {
            animation = new Animation("resources/sprites/enemy.png", 33, 47);
            SetAnimation(animation);
            animation.Start();
            SetPhysics(true);
            SetName(name);

            moveLeft = new Move(this, step, -1, 0);
            moveRight = new Move(this, step, 1, 0);
        }

        public void AddPrey()
        {
            player = (Player)GetWorld().GetActors().Find(x => x.GetName() == "player");
        }

        public override void Update()
        {
            base.Update();
            if (IntersectsWithActor(player) && player.GetState() is LivingState)
            {
                player.ChangeHealth(-1);
                this.ChangeHealth(-3);
            }
            if ((player.GetX() - this.GetX() < step && player.GetX() - this.GetX() > -1*step)  && (player.GetY() - this.GetY() < 150 && player.GetY() - this.GetY() > -150))
            {
            }
            else if ((player.GetX() - this.GetX() < 150 && player.GetX() - this.GetX() > 0) && (player.GetY() - this.GetY() < 150 && player.GetY() - this.GetY() > -150))
            {
                if (actorOrientation == ActorOrientation.FacingLeft)
                {
                    animation.FlipAnimation();
                    actorOrientation = ActorOrientation.FacingRight;
                }
                moveRight.Execute();
            }
            else if ((this.GetX() - player.GetX() < 150 && this.GetX() - player.GetX() > 0) && (player.GetY() - this.GetY() < 150 && player.GetY() - this.GetY() > -150))
            {
                if (actorOrientation == ActorOrientation.FacingRight)
                {
                    animation.FlipAnimation();
                    actorOrientation = ActorOrientation.FacingLeft;
                }
                moveLeft.Execute();
            }
            else
            {
                counter++;
                if (counter >= 60)
                {
                    counter = 0;
                    x = random.Next(1, 3);
                }
                if (x == 1)
                {
                    if (actorOrientation == ActorOrientation.FacingRight)
                    {
                        animation.FlipAnimation();
                        actorOrientation = ActorOrientation.FacingLeft;
                    }
                    moveLeft.Execute();
                } 
                else
                {
                    if (actorOrientation == ActorOrientation.FacingLeft)
                    {
                        animation.FlipAnimation();
                        actorOrientation = ActorOrientation.FacingRight;
                    }
                    moveRight.Execute();
                }
            }
        }
    }
}
