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

            for (int i = 0; i < farm.ChickenHouses.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Chicken House. Current Chicken Count: {farm.ChickenHouses[i].Chickens.Count}");
            }

            Console.WriteLine();

            // How can I output the type of animal chosen here?
            Console.WriteLine($"Place the {chicken.GetType().ToString().Split(".")[3]} where?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine());


            if (farm.ChickenHouses[choice - 1].Chickens.Count < farm.ChickenHouses[choice - 1].Capacity)
            {
                farm.ChickenHouses[choice - 1].AddResource(chicken);
            }
            else if(farm.ChickenHouses.Where(field => field.Chickens.Count < field.Capacity).ToList().Count > 0){
                Console.Write("Facility is full. Please select another facility. Press any key to continue...");
                Console.ReadLine();
                ChooseChickenHouse.CollectInput(farm, chicken);
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