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
        // Function to display the description of the room
        public string GetDescription()
        {
            return description;
        }
        // Function to show the items found in the room, currently only an old map
        public string GetRoomContents()
        {
            string item = inventory[0];
            return item;
        }
    }
}