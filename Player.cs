using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<string> inventory = new List<string>();

        public Player(string name, int health)
        {
            Name = name;
            Health = health;
        }
        public void PickUpItem(string item)
        {
            inventory.Add(item);
        }
        public string GetInventoryContents()
        {
            return string.Join(", ", inventory);
        }
        public int GetHealth()
        {
            return this.Health;
        }
        public string HealPlayer()
        {
            Console.WriteLine("You took a swig from your flask and feel a pump. You have regained 20 HP.");
            this.Health = this.Health + 20;
            return $"Your HP is now: {this.Health}";
        }
        public bool CheckForItems()
        {
            if (inventory.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void GetDmgTaken(int dmg)
        {
            Health = Health - dmg;
        }

    }
}