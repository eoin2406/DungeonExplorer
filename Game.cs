using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Media;
using System.Runtime.InteropServices;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player Player;
        private Room CurrentRoom;
        private Monster CurrentMonster;

        public Game()
        {
            // Initialize the game with one room and one player
            CurrentRoom = new Room("After hours of exploring, you are greeted with a gloomy room containing a horrifying creature and a big door at the back. After noticing some sort of scroll on the floor, the beast roars at you with rage. You have disturbed its slumber, you must act fast...");
            Player = new Player("Explorer", 100);
            CurrentMonster = new Monster("Minotaur", 50);
        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            Console.WriteLine(CurrentRoom.GetDescription());
            while (playing == true)
            // Loop to allow the user to make input whilst the game is running. Once the minotaur or the player reach 0HP, these options no longer work as the game has ended
            {
                while (CurrentMonster.GetHealth() > 0 && Player.GetHealth() > 0)
                {

                    Console.WriteLine($"Explorer's current HP is: {Player.GetHealth()}");
                    Console.WriteLine($"Minotaur's current HP is: {CurrentMonster.GetHealth()}");
                    string input = this.ExplorerInput();
                    if (input == ("attack"))
                    {
                        Console.WriteLine(CurrentMonster.GetAttackDmg());
                    }
                    else if (input == ("heal"))
                    {
                        Console.WriteLine(Player.HealPlayer());
                    }
                    else if (input == ("inv") && Player.CheckForItems() == true)
                    {
                        Console.WriteLine($"Explorer inventory: {Player.GetInventoryContents()}");
                    }

                    else if (input == ("pick") && Player.CheckForItems() == false)
                    {
                        string PlayerInv = CurrentRoom.GetRoomContents();
                        Player.PickUpItem(PlayerInv);
                        Console.WriteLine($"The room contains {PlayerInv}, and the player has picked it up.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                    if (CurrentMonster.GetHealth() > 0)
                    {
                        Console.WriteLine(CurrentMonster.GetEnemyAttackDmg(Player));
                    }
                    if (Player.GetHealth() <= 0)
                    {
                        Console.WriteLine("The minotaur lunges once more, causing you to fall to the ground. You have been defeated...");
                        playing = false;
                    }
                    playing = false;
                }
                if (CurrentMonster.GetHealth() <= 0)
                {
                    Console.WriteLine("After a final swing, the minotaur falls to the ground, you notice a shimmering light emitting from its hand... Congratulations!");
                    playing = false;
                }

            }



        }
        // User input options are shown below. ToLower() and Trim() functions are used to allow the user to input capitals or lowercase, whilst also clearing any blank spaces that could potentially have been inputted by the user
        private string ExplorerInput()
        {
            Console.WriteLine("What do you do?");
            Console.WriteLine("Type \"attack\" to use your broadsword on the minotaur.");
            Console.WriteLine("Type \"heal\" to increase your HP.");
            if (Player.CheckForItems() == false)
            {
                Console.WriteLine("Type \"pick\" to pickup the scroll-like item from the ground.");
            }
            if (Player.CheckForItems() == true)
            {
                Console.WriteLine("Type \"inv\" to view your inventory.");
            }
            string input = Console.ReadLine();
            // Debug.Assert is used here throughout user input
            Debug.Assert(input == "inv" || input == "pick" || input == "heal" || input == "attack", "Test failed. Invalid input.");
            return input.ToLower().Trim();
        }
    }
}