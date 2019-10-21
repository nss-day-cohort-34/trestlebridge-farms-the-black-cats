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

            for (int i = 0; i < farm.DuckHouses.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Duck House. Current Duck Count: {farm.DuckHouses[i].Ducks.Count}");
            }

            Console.WriteLine();

            // How can I output the type of animal chosen here?
            Console.WriteLine($"Place the {Duck.GetType().ToString().Split(".")[3]} where?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine());


            if (farm.DuckHouses[choice - 1].Ducks.Count < farm.DuckHouses[choice - 1].Capacity)
            {
                farm.DuckHouses[choice - 1].AddResource(Duck);
            }
            else if(farm.DuckHouses.Where(field => field.Ducks.Count < field.Capacity).ToList().Count > 0){
                Console.Write("Facility is full. Please select another facility. Press any key to continue...");
                Console.ReadLine();
                ChooseDuckHouse.CollectInput(farm, Duck);
            }
            else
            {
                Console.Write("All facilities full. Press any key to continue...");
                Console.ReadLine();
            }

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice);

        }
    }
}