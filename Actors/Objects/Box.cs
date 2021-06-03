using Merlin2.Actors.Characters;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System.Collections.Generic;

namespace Merlin2.Actors.Objects
{
    public class Box : AbstractCharacter
    {
        private Animation animation;
        List<ICharacter> characters;
        private bool directionLeft = true;
        public Box(string actorName)
        {
            animation = new Animation("resources/sprites/box.png", 50, 50);
            SetAnimation(animation);
            animation.Start();
            SetName(actorName);
            SetPhysics(true);
            characters = new List<ICharacter>();
        }

        public void AddCharacters() 
        {
            foreach (IActor actor in GetWorld().GetActors())
            {
                if (actor is ICharacter && actor.GetName() != "box")
                {
                    characters.Add((ICharacter)actor);
                }
            }
        }

        public override void Update()
        {
            foreach (IActor character in characters)
            {
                while (IntersectsWithActor(character) && GetWorld().IntersectWithWall(this) == false)                   
                {
                    if (GetX() > character.GetX())
                    {
                        SetPosition(GetX() + 2, GetY());
                        directionLeft = false;
                    }
                    else if (GetX()+GetWidth() < character.GetX() + character.GetWidth())
                    {
                        SetPosition(GetX() - 2, GetY());
                        directionLeft = true;
                    } 
                    else
                    {
                        break;
                    }
                }
            }
            while (GetWorld().IntersectWithWall(this))
            {
                if (directionLeft)
                {
                    SetPosition(GetX() + 1, GetY());
                } 
                else
                {
                    SetPosition(GetX() - 1, GetY());
                }
            }
        }
    }
}