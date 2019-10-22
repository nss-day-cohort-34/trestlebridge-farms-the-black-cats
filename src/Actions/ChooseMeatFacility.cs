using System;
using System.Collections.Generic;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Processors;

namespace Trestlebridge.Actions
{
    public class ChooseMeatFacility
    {
        public static void CollectInput(Farm farm, MeatProcessor meatProcessor)
        {
            int counter = 1;
            for (int i = 0; i < farm.ChickenHouses.Count; i++)
            {
                Console.WriteLine($"{counter}. Chicken House ({farm.ChickenHouses[i].Chickens.Count} Chickens)");
                counter++;
            }
            Console.WriteLine("===================================");
            for (int i = 0; i < farm.GrazingFields.Count; i++)
            {
                Console.WriteLine($"{counter}. Grazing Field ({farm.GrazingFields[i].Animals.Count} Animals)");
                counter++;
            }
            Console.Write("Which facility has the animals you would like to process from? ");
            int choice = Int32.Parse(Console.ReadLine());

            Console.Clear();
            Program.DisplayBanner();

            if (choice <= farm.ChickenHouses.Count)
            {

                Console.WriteLine($"How many chickens would you like to process? ");
                int numberOfChickens = Int32.Parse(Console.ReadLine());
                if (numberOfChickens == 1)
                {
                    meatProcessor.AddResource((IMeatProducing)farm.ChickenHouses[choice - 1].Chickens.First());
                    farm.ChickenHouses[choice - 1].Chickens.RemoveRange(0, numberOfChickens);
                    Program.DisplayBanner();
                    Console.WriteLine($"Successfully added {numberOfChickens} to the meat processor");
                    ProcessAnimals(meatProcessor, farm);
                }
                else
                {
                    List<IChicken> chickensToProcess = farm.ChickenHouses[choice - 1].Chickens.Take(numberOfChickens).ToList();
                    meatProcessor.AddResource(chickensToProcess.Select(c => (IMeatProducing)c).ToList());
                    farm.ChickenHouses[choice - 1].Chickens.RemoveRange(0, numberOfChickens);
                    Program.DisplayBanner();
                    Console.WriteLine($"Successfully added {numberOfChickens} to the meat processor");
                    ProcessAnimals(meatProcessor, farm);
                }
            }
            else
            {
                int animalIndex = 1;
                int index = choice - farm.ChickenHouses.Count() - 1;
                // Group animals by their type to display their counts
                List<IGrouping<string, IGrazing>> groupedAnimals = farm.GrazingFields[index].Animals.GroupBy(anml => anml.Type).ToList();

                foreach (IGrouping<string, IGrazing> anml in groupedAnimals)
                {
                    Console.WriteLine($"{animalIndex}. {anml.Key}: {anml.Count()}");
                    animalIndex++;
                }
                Console.WriteLine("===================================");
                Console.Write("Which resource should be processed? ");
                int selection = Int32.Parse(Console.ReadLine());
                Console.WriteLine($"You selected: {groupedAnimals[selection - 1].Key}. I hope you're happy...\nHow many do you want to murder? ");
                int numberToMurder = Int32.Parse(Console.ReadLine());

                foreach (IGrazing animal in groupedAnimals[selection - 1].Take(numberToMurder))
                {
                    meatProcessor.AddResource((IMeatProducing)animal);
                    farm.GrazingFields[index].Animals.Remove(animal);
                }
                Program.DisplayBanner();
                Console.WriteLine($"Successfully added {numberToMurder} to the meat processor");
                ProcessAnimals(meatProcessor, farm);
            }
        }
        public static void ProcessAnimals(MeatProcessor meatProcessor, Farm farm)
        {
            Console.Write("Are you ready to process?(y/n) ");
            string response = Console.ReadLine();
            if (response == "y")
            {
                double meatProduced = 0;
                foreach (IMeatProducing animal in meatProcessor.AnimalsToBeProcessed)
                {
                    meatProduced += animal.Butcher();
                }
                Program.DisplayBanner();
                Console.WriteLine($"Meat Produced: {meatProduced}kg.");
                Console.WriteLine("Press return to continue...or else ");
                Console.ReadLine();
            }
            else if (response == "n")
            {
                Program.DisplayBanner();
                ChooseMeatFacility.CollectInput(farm, meatProcessor);
            }
            else
            {
                Console.Write("You're a dingus. Try again. ");
                response = Console.ReadLine();
            }
        }
    }
}