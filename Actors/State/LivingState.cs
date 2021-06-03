using Merlin2.Actors.Characters;
using Merlin2.Actors.Objects;
using Merlin2.Commands;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using System;

namespace Merlin2.Actors.State
{
    public class LivingState : IPlayerState
    {
        private Animation animation;
        private Command moveLeft;
        private Command moveRight;
        private Command jump;
        private Player player;
        private ActorOrientation actorOrientation = ActorOrientation.FacingRight;
        private int counter = 0;
        private int counterShiftRight = 20;
        private int counterShiftLeft = 20;
        private int counterUse = 20;
        private int counterSpell = 0;

        public LivingState(Player player)
        {
            this.player = player;
            animation = new Animation("resources/sprites/player.png", 28, 47);
            player.SetAnimation(animation);
            animation.Start();
            moveLeft = new Move(player, 4, -1, 0);
            moveRight = new Move(player, 4, 1, 0);
            jump = new Jump(player, 7, 0, -1);
            player.SetPosition(player.GetX(), player.GetY() - 23);
            Message msg = new Message("Objective: Kill everyone!", -30, -30, 20, new Color(255,255,255), (Merlin2d.Game.Enums.MessageDuration)300);
            msg.SetAnchorPoint(player);
            player.GetWorld().AddMessage(msg);
        }

        public Animation GetAnimation()
        {
            return animation;
        }

        private bool IntersectsWithGround(IActor movable)
        {
            return movable.GetWorld().IsWall(movable.GetX() / 16 + 1, (movable.GetY() + movable.GetWidth()) / 16 + 1);
        }

        public void Update()
        {   
            if (counterSpell < 20)
            {
                counterSpell++;
            }
            if (Input.GetInstance().IsKeyDown(Input.Key.R) && player.GetMana() >= 10 && counterSpell == 20 && player.GetMana() >= 10)
            {
                counterSpell = 0;
                player.ChangeMana(-10);
                player.ChangeHealth(5);
            }
            if (counterShiftLeft < 20)
            {
                counterShiftLeft++;
            }
            if (counterShiftRight < 20)
            {
                counterShiftRight++;
            }
            if (counterUse < 20)
            {
                counterUse++;
            }
            if (Input.GetInstance().IsKeyDown(Input.Key.Q) && counterShiftLeft == 20)
            {
                player.GetBackpack().ShiftLeft();
                counterShiftLeft = 0;
            }
            if (Input.GetInstance().IsKeyDown(Input.Key.W) && counterShiftRight == 20)
            {
                player.GetBackpack().ShiftRight();
                counterShiftRight = 0;
            }
            if (Input.GetInstance().IsKeyDown(Input.Key.E) && counterUse == 20)
            {
                IUsable item = (IUsable)player.GetBackpack().GetItem();
                if (item != null)
                {
                    item.Use(player);
                }
                counterUse = 0;
            }
            if (IntersectsWithGround(player))
            {
                counter = 0;
            }            
            if (Input.GetInstance().IsKeyDown(Input.Key.UP) && counter < 60)
            {
                jump.Execute();
                counter++;
            }            
            if (Input.GetInstance().IsKeyDown(Input.Key.LEFT))
            {
                if (actorOrientation == ActorOrientation.FacingRight)
                {
                    animation.FlipAnimation();
                    actorOrientation = ActorOrientation.FacingLeft;
                }
                animation.Start();
                moveLeft.Execute();
            }
            else if (Input.GetInstance().IsKeyDown(Input.Key.RIGHT))
            {
                if (actorOrientation == ActorOrientation.FacingLeft)
                {
                    animation.FlipAnimation();
                    actorOrientation = ActorOrientation.FacingRight;
                }
                animation.Start();
                moveRight.Execute();
            }
            else
            {
                animation.Stop();
            }
        }
    }
}
