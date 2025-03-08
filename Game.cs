using System;
using System.ComponentModel;
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
            CurrentRoom = new Room("You stumble upon a gloomy room containing a horrifying creature and potential wonders. After noticing some sort of scroll on the floor, the beast glares at you with rage, knowing you have disturbed its slumber. You must act fast...");
            Player = new Player("Explorer", 100);
            CurrentMonster = new Monster("Minotaur", 50);
        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            Console.WriteLine(CurrentRoom.GetDescription());
            while (playing == true)
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
            return input;
        }
    }
}