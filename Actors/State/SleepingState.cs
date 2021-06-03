using Merlin2.Actors.Characters;
using Merlin2d.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin2.Actors.State
{
    public class SleepingState : IPlayerState
    {
        private Animation animation;

        public SleepingState(Player player)
        {
            animation = new Animation("resources/sprites/player_sleep.png", 47, 24);
            player.SetAnimation(animation);
            animation.Start();
        }

        public Animation GetAnimation()
        {
            return animation;
        }

        public void Update()
        {
        }
    }
}
