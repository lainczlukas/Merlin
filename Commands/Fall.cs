using Merlin2d.Game.Actors;

namespace Merlin2.Commands
{
    public class Fall<T> : IAction<T> where T : IActor
    {
        private int speed;

        public Fall(int speed)
        {
            this.speed = speed;
        }

        public int GetSpeed()
        {
            return speed;
        }

        public void SetSpeed(int speed)
        {
            this.speed = speed;
        }

        public void Execute(T t)
        {
            t.SetPosition(t.GetX(), t.GetY() + speed);
            while (t.GetWorld().IntersectWithWall(t))
            {
                t.SetPosition(t.GetX(), t.GetY() - 1);
            }
        }
    }
}
