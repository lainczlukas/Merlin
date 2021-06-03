using Merlin2.Actors.Characters;
using Merlin2d.Game;
using Merlin2d.Game.Items;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Merlin2.Actors.Items
{
    public class Backpack : IPotionsInventory
    {
        private int capacity;
        private IItem[] inventory;

        private int highestPosition = 0;

        public Backpack(int capacity)
        {
            this.capacity = capacity;
            inventory = new IItem[capacity];
        }

        public void AddItem(IItem item)
        {
            try
            {
                inventory[highestPosition++] = item;
            }
            catch
            {
                highestPosition--;
            }
        }

        public int GetCapacity()
        {
            return capacity;
        }

        public int GetHighestPosition()
        {
            return highestPosition;
        }

        public IEnumerator<IItem> GetEnumerator()
        {
            for (int i = 0; i < capacity; i++)
            {
                if (inventory[i] == null)
                {
                    continue;
                }
                yield return inventory[i];
            }
        }

        public IItem GetItem()
        {
            return inventory[0];            
        }

        public void RemoveItem(IItem item)
        {
            for (int i = 0; i < capacity; i++)
            {
                if (inventory[i].GetName() == item.GetName())
                {
                    RemoveItem(i);
                    InventoryTrim();
                    highestPosition--;
                    break;
                }
            }
        }

        private void InventoryTrim()
        {
            for (int i = 0; i < highestPosition -1; i++)
            {
                if (inventory[i] == null)
                {
                    inventory[i] = inventory[i + 1];
                    inventory[i + 1] = null;
                }
            }
        }

        public void RemoveItem(int index)
        {
            inventory[index] = null;
        }

        public void ShiftLeft()
        {
            if (highestPosition > 1)
            {
                IItem temp1 = inventory[0];
                IItem temp2 = inventory[highestPosition - 1];
                for (int i = highestPosition-1; i >= 0; i--)
                {
                    inventory[i] = temp1;
                    temp1 = temp2;
                    if (i > 0)
                    {
                        temp2 = inventory[i-1];
                    }
                }
            }
        }

        public void ShiftRight()
        {
            if (highestPosition > 1)
            {
                IItem temp1 = inventory[highestPosition-1];
                IItem temp2 = inventory[0];
                for (int i = 0; i < highestPosition; i++)
                {
                    inventory[i] = temp1;
                    temp1 = temp2;
                    if (i < highestPosition - 1)
                    {
                        temp2 = inventory[i + 1];
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}