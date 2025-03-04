using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private List<string> inventory = new List<string>();

        public Room(string description)
        {
            this.description = description;
            this.inventory.Add("an old map");
        }

        public string GetDescription()
        {
            return description;
        }
        public string RoomContents()
        {
            return ("an old map");
        }
    }
}