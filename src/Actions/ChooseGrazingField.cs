using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions
{
    public class ChooseGrazingField
    {
        public static void CollectInput(Farm farm, IGrazing animal)
        {
            Console.Clear();

            for (int i = 0; i < farm.GrazingFields.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Grazing Field");
            }

            Console.WriteLine();

            // How can I output the type of animal chosen here?
            Console.WriteLine($"Place the {animal.GetType().ToString().Split(".")[3]} where?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine());


            if (farm.GrazingFields[choice - 1].Animals.Count < farm.GrazingFields[choice - 1].Capacity)
            {
                farm.GrazingFields[choice - 1].AddResource(animal);
            }
            else if(farm.GrazingFields.Where(field => field.Animals.Count < field.Capacity).ToList().Count > 0){
                Console.Write("Facility is full. Please select another facility. Press any key to continue...");
                Console.ReadLine();
                ChooseGrazingField.CollectInput(farm, animal);
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