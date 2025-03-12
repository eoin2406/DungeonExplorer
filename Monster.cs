using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Monster
    {
        private int Health { get; set; }
        private string Name { get; set; }
        public Monster(string Name, int Health)
        {
            this.Name = Name;
            this.Health = Health;
        }
        // Method to display the health of the minotaur
        public int GetHealth()
        {
            return this.Health;
        }
        // Method to display the damage done to the minotaur
        public string GetAttackDmg()
        {
            this.Health = this.Health - 10;
            return $"You swing your broadsword, attacking the minotaur. It now has {this.Health} HP.";
        }
        // Method to display the damage done to the player
        public string GetEnemyAttackDmg(Player player)
        {
            int Dmg = 15;
            player.GetDmgTaken(Dmg);
            return $"The minotaur lunges at you, causing you to stumble backwards. You received {Dmg} damage.";
        }
    }
}
