using BattleshipLiteLibrary.Models;
using System;
using System.Collections.Generic;

namespace ModelsLibrary
{
    public static class GameLogic
    {
        public static void InitializeGrid(PlayerInfoModel model)
        {
            List<string> letters = new List<string> { "A", "B", "C", "D", "E" };
            
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

            foreach (string letter in letters)
            {               
                foreach (int number in numbers)
                {                   
                    AddGridSpot(model, letter, number);
                }
            
            }
            
            ShowGrid(letters, numbers);
        }

        private static void ShowGrid(List<string> letters, List<int> numbers)
        {
            Console.WriteLine();
            Console.WriteLine("Place your ships on the shotgrid:\n");
            
            foreach (string letter in letters)
            {
                foreach (int number in numbers)
                {
                    Console.Write(letter+number+" ");
                    if (number == 5)
                    {
                        Console.WriteLine();
                    }
                }
            }
        }

        private static void AddGridSpot(PlayerInfoModel model, string letter, int number)
        {
            GridSpotModel spot = new GridSpotModel
            {
                SpotLetter = letter,
                SpotNumber = number,
                Status = Models.GridSpotStatus.Empty
            };

            model.ShotGrid.Add(spot);
            
        }


        public static bool PlayerStillActive(PlayerInfoModel player)
        {
            bool isActive = false;

            foreach (var ship in player.ShipLocations)
            {
                if (ship.Status != Models.GridSpotStatus.Sunk)
                {
                    isActive = true;
                }          
            }
            return isActive;
        }

        public static bool PlaceShip(PlayerInfoModel model, string location)
        {
            bool output = false;
            
            (string row, int column) = SplitShotIntoRowsAndColums(location);

            bool isLocationValid = ValidateGridLocation(model, row, column);
            bool isSpotOpen = ValidateShipLocation(model, row, column);

            if (isLocationValid && isSpotOpen)
            {
                model.ShipLocations.Add(new GridSpotModel
                {
                    SpotLetter = row.ToUpper(),
                    SpotNumber = column,
                    Status = Models.GridSpotStatus.Ship
                });
                output = true;
            }
            return output;
        }

        private static bool ValidateShipLocation(PlayerInfoModel model, string row, int column)
        {
            bool isLocationValid = true;

            foreach (var ship in model.ShipLocations)
            {
                if (ship.SpotLetter == row.ToUpper() && ship.SpotNumber == column)
                {
                    isLocationValid = false;
                }
            }
                return isLocationValid;
        }

        private static bool ValidateGridLocation(PlayerInfoModel model, string row, int column)
        {
            bool isLocationValid = false;

            foreach (var spot in model.ShotGrid)
            {
                if (spot.SpotLetter == row.ToUpper() && spot.SpotNumber == column)
                {
                    isLocationValid = true;
                }
            }
            return isLocationValid;
        }

        public static int GetShotCount(PlayerInfoModel player)
        {
            int shotCount = 0;

            foreach (var shot in player.ShotGrid)
            {
                if (shot.Status != Models.GridSpotStatus.Empty)
                {
                    shotCount += 1;
                }
            }

            return shotCount;
        }

        public static (string row, int column) SplitShotIntoRowsAndColums(string shot)
        {
            string row = "";
            int column = 0;

            if (shot.Length != 2)
            {
                Console.Clear();
                throw new ArgumentException("This was an invalid shot type.");
            }
                       
            char[] shotArray = shot.ToCharArray();

            row = shotArray[0].ToString();
            column = int.Parse(shotArray[1].ToString());

            return (row, column);
        }

        public static bool ValidateShot(PlayerInfoModel player, string row, int column)
        {
            bool isValidShot = false;

            foreach (var gridSpot in player.ShotGrid)
            {
                if (gridSpot.SpotLetter == row.ToUpper() && gridSpot.SpotNumber == column)
                {
                    if (gridSpot.Status == Models.GridSpotStatus.Empty)
                    {
                        isValidShot = true;
                    }
                }
            }
            return isValidShot;
        }

        public static bool IdentefyShotResult(PlayerInfoModel opponent, string row, int column)
        {
            bool isAHit = false;

            foreach (var ship in opponent.ShipLocations)
            {
                if (ship.SpotLetter == row.ToUpper() && ship.SpotNumber == column)
                {
                    isAHit = true;
                    ship.Status = Models.GridSpotStatus.Sunk;
                }
            }
            return isAHit;
        }

        public static void MarkShotResult(PlayerInfoModel player, string row, int column, bool isAHit)
        {
            foreach (var gridSpot in player.ShotGrid)
            {
                if (gridSpot.SpotLetter == row.ToUpper() && gridSpot.SpotNumber == column)
                {
                    if (isAHit)
                    {
                        gridSpot.Status = Models.GridSpotStatus.Hit;
                    }
                    else
                    {
                        gridSpot.Status = Models.GridSpotStatus.Miss;
                    }
                }
            }
        }
    }

}
