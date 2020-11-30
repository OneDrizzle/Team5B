using BattleshipLiteLibrary.Models;
using ModelsLibrary;
using ModelsLibrary.Models;
using System;

namespace BattleshipLiteUI
{
    class Program
    {
        static void Main(string[] args)
        {
            WelcomeMessage();
            PlayerInfoModel activePlayer = CreatePlayer("Player 1");
            
            WelcomeMessage();
            PlayerInfoModel opponent = CreatePlayer("Player 2");
            
            PlayerInfoModel winner = null;

            do
            {
                DisplayShotGrid(activePlayer);

                RecordPlayerShot(activePlayer, opponent);

                Console.ReadKey();

                bool doesGameContinue = GameLogic.PlayerStillActive(opponent);

                if (doesGameContinue == true)
                {
                    //Swap using a temp variable.

                    //PlayerInfoModel tempHolder = opponent;
                    //opponent = activePlayer;
                    //activePlayer = tempHolder;

                    //Swap using Tuple.
                    (activePlayer, opponent) = (opponent, activePlayer);
                }

                else
                {
                    winner = activePlayer;
                }

            } while (winner == null);

            IdentefyWinner(winner);

            Console.ReadLine();
        }

        private static void IdentefyWinner(PlayerInfoModel winner)
        {
            Console.Clear();
            Console.WriteLine("-------------------------------");
            Console.WriteLine("------WE HAVE A WINNER!!!------");
            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Congratulations to {winner.UsersName}");
            Console.WriteLine("-------------------------------");
            Console.WriteLine();
            Console.WriteLine($"{winner.UsersName} used { GameLogic.GetShotCount(winner) } shots to win the game.");
        }

        private static void RecordPlayerShot(PlayerInfoModel activePlayer, PlayerInfoModel opponent)
        {
            bool isShotValid = false;
            string row = "";
            int column = 0;

            do
            {
                string shot = AskForShot(activePlayer);
                try
                {
                    (row, column) = GameLogic.SplitShotIntoRowsAndColums(shot);
                    isShotValid = GameLogic.ValidateShot(activePlayer, row, column);
                }
                catch (Exception)
                {
                    isShotValid = false;
                }

                if (isShotValid == false)
                {
                    Console.WriteLine("\nYou already made this shot! Try again.\n");
                }

                // The Bang = ! can be hard to read
            } while (!isShotValid);

            bool isAHit = GameLogic.IdentefyShotResult(opponent, row, column);

            GameLogic.MarkShotResult(activePlayer, row, column, isAHit);

            DisplayShotResult(row, column, isAHit);
        }

        private static void DisplayShotResult(string row, int column, bool isAHit)
        {
            Console.Clear();
            if (isAHit)
            {
                Console.WriteLine("     ------------");
                Console.WriteLine($"    {row.ToUpper()}{column} - is a HIT!");
                Console.WriteLine("     ------------");
            }
            else
            {
                Console.WriteLine("     ------------");
                Console.WriteLine($"    {row.ToUpper()}{column} - is a MISS!");
                Console.WriteLine("     ------------");
            }
            
        }

        private static string AskForShot(PlayerInfoModel player)
        {
            
            Console.Write($"{ player.UsersName }´s turn. Enter your shot: ");
            string output = Console.ReadLine();
            
            return output;
        }

        private static void DisplayShotGrid(PlayerInfoModel activePlayer)
        {
            Console.Clear();
            string currentRow = activePlayer.ShotGrid[0].SpotLetter;

            foreach (var gridSpot in activePlayer.ShotGrid)
            {
                if (gridSpot.SpotLetter != currentRow)
                {
                    Console.WriteLine();
                    currentRow = gridSpot.SpotLetter;
                }

                if (gridSpot.Status == GridSpotStatus.Empty)
                {
                    Console.Write($" {gridSpot.SpotLetter}{gridSpot.SpotNumber} ");
                }

                else if (gridSpot.Status == GridSpotStatus.Hit)
                {
                    Console.Write("  X ");
                }

                else if (gridSpot.Status == GridSpotStatus.Miss)
                {
                    Console.Write("  O ");
                }

                else
                {
                    Console.Write("   ? ");
                }

            }

            Console.WriteLine();
            Console.WriteLine();
        }

        private static void WelcomeMessage()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("Welcome to Battleship Lite");
            Console.WriteLine("--------Made by Nick--------");
            Console.WriteLine();
        }

        private static PlayerInfoModel CreatePlayer(string playerTitle)
        {
            PlayerInfoModel output = new PlayerInfoModel();

            Console.WriteLine($"{ playerTitle } information.\n");

            //Ask for users for their name
            output.UsersName = AskForUserName();

            //Load up the shotgrid
            GameLogic.InitializeGrid(output);            

            //Ask for ship placements
            AskShipPlacement(output);

            //Clear screen
            Console.Clear();

            return output;
        }

        private static string AskForUserName()
        {
            Console.Write("What is your name: ");
            string output = Console.ReadLine();
            Console.Clear();
            WelcomeMessage();

            return output;
        }

        private static void AskShipPlacement(PlayerInfoModel model)
        {
            do
            {
                Console.Write($"\nWhere do you want to place your ship number { model.ShipLocations.Count + 1}: ");
                string location = Console.ReadLine();

                bool isValidLocation = false;

                try
                {
                    isValidLocation = GameLogic.PlaceShip(model, location);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

                if (isValidLocation == false)
                {
                    Console.WriteLine("That was not a valid location. Please try again.");
                }

            } while (model.ShipLocations.Count < 5);

            Console.WriteLine();
            Console.WriteLine("You placed all your ships. You are now ready...\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }



    }
}
