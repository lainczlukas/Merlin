using Merlin2.Actors.Characters;
using Merlin2d.Game;

namespace Merlin2.Actors.State
{
    public class DyingState : IPlayerState
    {
        private Animation animation;
        private Message msg;

        public DyingState(Player player)
        {
            animation = new Animation("resources/sprites/player_dead.png", 47, 24);
            player.SetAnimation(animation);
            animation.Start();
            msg = new Message("YOU DIED! press esc", -90, -50, 30, new Color(255,255,255), Merlin2d.Game.Enums.MessageDuration.Indefinite);
            msg.SetAnchorPoint(player);
            player.GetWorld().AddMessage(msg);
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
