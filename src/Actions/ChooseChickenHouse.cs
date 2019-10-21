using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions
{
    public class ChooseChickenHouse
    {
        public static void CollectInput(Farm farm, Chicken chicken)
        {
            Console.Clear();

            if (farm.ChickenHouses.Count() == 0)
            {
                Console.WriteLine("There are no chicken houses. Try creating one.");
                Console.WriteLine("Press return... or else");
                Console.ReadLine();

            }
            else
            {
                for (int i = 0; i < farm.ChickenHouses.Count; i++)
                {
                    // Only display chicken houses that have room
                    if (farm.ChickenHouses[i].Chickens.Count < farm.ChickenHouses[i].Capacity)
                    {
                        Console.WriteLine($"{i + 1}. Chicken House. Current Chicken Count: {farm.ChickenHouses[i].Chickens.Count}");
                    }
                }

                Console.WriteLine();

                // How can I output the type of animal chosen here?
                Console.WriteLine($"Place the {chicken.GetType().ToString().Split(".")[3]} where?");

                Console.Write("> ");
                try
                {
                    int choice = Int32.Parse(Console.ReadLine());

                    if (farm.ChickenHouses[choice - 1].Chickens.Count < farm.ChickenHouses[choice - 1].Capacity)
                    {
                        farm.ChickenHouses[choice - 1].AddResource(chicken);
                    }
                    else if (farm.ChickenHouses.Where(field => field.Chickens.Count < field.Capacity).ToList().Count > 0)
                    {
                        Console.Write("Facility is full. Please select another facility. Press any key to continue...");
                        Console.ReadLine();
                        ChooseChickenHouse.CollectInput(farm, chicken);
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
                    ChooseChickenHouse.CollectInput(farm, chicken);
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    Console.WriteLine("The chicken house you selected does not exist\nPress return to continue");
                    Console.ReadLine();
                    ChooseChickenHouse.CollectInput(farm, chicken);
                }
                /*
                    Couldn't get this to work. Can you?
                    Stretch goal. Only if the app is fully functional.
                 */
                // farm.PurchaseResource<IGrazing>(animal, choice);
            }
        }
    }
}