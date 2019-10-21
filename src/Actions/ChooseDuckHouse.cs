using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions
{
    public class ChooseDuckHouse
    {
        public static void CollectInput(Farm farm, Duck Duck)
        {
            Console.Clear();

            if (farm.DuckHouses.Count() == 0 || farm.DuckHouses.Where(field => field.Ducks.Count == field.Capacity).ToList().Count == farm.DuckHouses.Count())
            {
                Console.WriteLine("There are no available duck houses. Try creating a new one.");
                Console.WriteLine("Press return... or else");
                Console.ReadLine();
            }
            else
            {
                for (int i = 0; i < farm.DuckHouses.Count; i++)
                {
                    // Only display duck houses that have room
                    if (farm.DuckHouses[i].Ducks.Count < farm.DuckHouses[i].Capacity)
                    {
                        Console.WriteLine($"{i + 1}. Duck House. Current Duck Count: {farm.DuckHouses[i].Ducks.Count}");
                    }
                }

                Console.WriteLine();

                // How can I output the type of animal chosen here?
                Console.WriteLine($"Place the {Duck.GetType().ToString().Split(".")[3]} where?");

                Console.Write("> ");
                try
                {
                    int choice = Int32.Parse(Console.ReadLine());


                    if (farm.DuckHouses[choice - 1].Ducks.Count < farm.DuckHouses[choice - 1].Capacity)
                    {
                        farm.DuckHouses[choice - 1].AddResource(Duck);
                    }
                    else if (farm.DuckHouses.Where(field => field.Ducks.Count < field.Capacity).ToList().Count > 0)
                    {
                        Console.Write("Facility is full. Please select another facility. Press any key to continue...");
                        Console.ReadLine();
                        ChooseDuckHouse.CollectInput(farm, Duck);
                    }
                    else
                    {
                        Console.Write("All facilities full. Press any key to continue...");
                        Console.ReadLine();
                    }
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Please enter one of the specified options...\nI love you.\nPress return to continue");
                    Console.ReadLine();
                    ChooseDuckHouse.CollectInput(farm, Duck);
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    Console.WriteLine("The duck house you selected does not exist\nPress return to continue");
                    Console.ReadLine();
                    ChooseDuckHouse.CollectInput(farm, Duck);
                }
            }
        }
    }
}