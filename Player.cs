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
        // Function to pick up the item and add it to the inventory
        public void PickUpItem(string item)
        {
            inventory.Add(item);
        }
        // Function to display the contents of the player's inventory
        public string GetInventoryContents()
        {
            return string.Join(", ", inventory);
        }
        // Function to display the health of the player
        public int GetHealth()
        {
            return this.Health;
        }
        // Function for a healing item to incrase the player's HP
        public string HealPlayer()
        {
            Console.WriteLine("You took a swig from your flask and feel a pump. You have regained 20 HP.");
            this.Health = this.Health + 20;
            return $"Your HP is now: {this.Health}";
        }
        // Function to check if there is an item in the inventory, allowing you to access the inventory option afterwards
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

        // Function to display the damage taken
        public void GetDmgTaken(int dmg)
        {
            Test.TestForPositiveInteger(dmg);
            Health = Health - dmg;
        }

    }
}