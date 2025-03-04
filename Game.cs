using System;
using System.ComponentModel;
using System.Media;
using System.Runtime.InteropServices;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        private Monster currentMonster;

        public Game()
        {
            // Initialize the game with one room and one player
            currentRoom = new Room("You stumble upon a dark, gloomy room containing a mysterious creature and potential wonders. You notice some sort of scroll on the floor.");
            player = new Player("Explorer", 100);
            currentMonster = new Monster("Minotaur", 20);
        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            Console.WriteLine(currentRoom.GetDescription());
            while (playing == true)
            {
                while (currentMonster.getHealth() > 0)
                {

                    Console.WriteLine($"Explorer's current HP is: {player.Health}");
                    Console.WriteLine($"Minotaur's current HP is: {currentMonster.getHealth()}");
                    string input = this.ExplorerInput();
                    if (input == ("a"))
                    {
                        Console.WriteLine(currentMonster.attackDmg());
                    }
                    else if (input == ("h"))
                    {
                        Console.WriteLine(player.Heal());
                    }
                    else if (input == ("i") && player.CheckForItems() == true)
                    {
                        Console.WriteLine($"Explorer inventory: {player.InventoryContents()}");
                    }

                    else if (input == ("p") && player.CheckForItems() == false)
                    {
                        string PlayerInv = currentRoom.RoomContents();
                        player.PickUpItem(PlayerInv);
                        Console.WriteLine($"The room contains {PlayerInv}, and the player has picked it up.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                    playing = false;
                }
                Console.WriteLine("Congrats, you have slain the minotaur!");

            }



        }
        private string ExplorerInput()
        {
            Console.WriteLine("What do you do?");
            Console.WriteLine("Type a to attack.");
            Console.WriteLine("Type h to heal.");
            if (player.CheckForItems() == false)
            {
                Console.WriteLine("Type p to pickup item.");
            }
            if (player.CheckForItems() == true)
            {
                Console.WriteLine("Type i to view the inventory.");
            }
            string input = Console.ReadLine();
            return input;
        }
    }
}