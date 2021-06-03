using Merlin2d.Game;
using Merlin2.Actors.State;
using Merlin2.Actors.Items;
using Merlin2d.Game.Items;
using System;

namespace Merlin2.Actors.Characters
{
    public class Player : AbstractCharacter, IMovable
    {
        private IPlayerState state;
        private Message curMessage;
        private Backpack backpack;

        public Player(string actorName)
        {
            state = new SleepingState(this);
            SetPhysics(true);
            SetName(actorName);
            curMessage = new Message($"Player HP: {GetHealth()}", 10, 10, 30, new Color(255,255,255), Merlin2d.Game.Enums.MessageDuration.Indefinite);
            backpack = new Backpack(4);
        }

        public IInventory GetBackpack()
        {
            return backpack;
        }

        public IPlayerState GetState()
        {
            return state;
        }

        public override Animation GetAnimation()
        {
            return state.GetAnimation();
        }

        public void WakeUp()
        {
            state = new LivingState(this);
        }

        public override void Die()
        {
            if (state is LivingState)
            {
                state = new DyingState(this);
            }
        }

        public override void Update()
        {
            GetWorld().ShowInventory(backpack);
            base.Update();
            GetWorld().RemoveMessage(curMessage);
            curMessage.SetText($"Player HP: {GetHealth()} , Player Mana: {GetMana()}");
            GetWorld().AddMessage(curMessage);
            state.Update();
        }

        public void ChangeMana(int delta)
        {
            if (GetMaxMana() < GetMana() + delta)
            {
                mana = 0;
                mana += GetMaxMana();
            }
            else
            {
                mana += delta;
            }
        }

        public int GetMana()
        {
            return mana;
        }

        public void Cast()
        {
            
        }
    }
}