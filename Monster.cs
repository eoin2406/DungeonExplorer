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
        public int getHealth()
        {
            return this.Health;
        }
        public string attackDmg()
        {
            this.Health = this.Health - 10;
            return $"You swing your broadsword and attack the minotaur, it now has {this.Health} HP.";
        }
    }
}
