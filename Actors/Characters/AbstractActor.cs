using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System;

namespace Merlin2.Actors.Characters
{
    public abstract class AbstractActor : IActor
    {
        private IWorld world;
        private Animation animation;
        private string name;

        private int posX = 0;
        private int posY = 0;

        private bool removedFromWorld = true;
        private bool affectedByPhysics = false;

        public AbstractActor()
        {

        }

        public AbstractActor(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public virtual Animation GetAnimation()
        {
            return animation;
        }

        public void SetAnimation(Animation animation)
        {
            this.animation = animation;
        }

        public int GetHeight()
        {
            return animation.GetHeight();
        }

        public int GetWidth()
        {
            return animation.GetWidth();
        }

        public IWorld GetWorld()
        {
            return world;
        }

        public int GetX()
        {
            return posX;
        }

        public int GetY()
        {
            return posY;
        }


        public bool IntersectsWithActor(IActor other)
        {
            if (((this.GetX() + this.GetWidth() > other.GetX()) && (this.GetX() < other.GetX() + other.GetWidth())) && ((this.GetY() + this.GetHeight() > other.GetY()) && (this.GetY() < other.GetY() + other.GetHeight())))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsAffectedByPhysics()
        {
            return affectedByPhysics;
        }

        public void SetPhysics(bool isPhysicsEnabled)
        {
            this.affectedByPhysics = isPhysicsEnabled;
        }

        public void OnAddedToWorld(IWorld world)
        {
            removedFromWorld = false;
            this.world = world;
        }

        public bool RemovedFromWorld()
        {
            return removedFromWorld;
        }

        public void RemoveFromWorld()
        {
            removedFromWorld = true;
        }

        public void SetPosition(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
        }

        public abstract void Update();
    }
}
