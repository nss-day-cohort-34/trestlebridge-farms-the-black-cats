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
                Console.WriteLine($"{counter}. Chicken House. Current Chicken Count: {farm.ChickenHouses[i].Chickens.Count}");
                counter++;
            }
            Console.WriteLine("====================");
            for (int i = 0; i < farm.GrazingFields.Count; i++)
            {
                Console.WriteLine($"{counter}. Grazing Field. Current Animal Count: {farm.GrazingFields[i].Animals.Count}");
                counter++;
            }
            Console.Write("Which facility has the animals you would like to process from?");
            int choice = Int32.Parse(Console.ReadLine());

            Console.Clear();
            Program.DisplayBanner();

            if (choice <= farm.ChickenHouses.Count)
            {

                Console.WriteLine($"How many chickens would you like to process?");
                int numberOfChickens = Int32.Parse(Console.ReadLine());
                if (numberOfChickens == 1)
                {
                    meatProcessor.AddResource((IMeatProducing)farm.ChickenHouses[choice - 1].Chickens.First());
                    farm.ChickenHouses[choice - 1].Chickens.RemoveRange(0, 1);
                    Program.DisplayBanner();
                    Console.WriteLine($"Successfully added {numberOfChickens} to the meat processor");
                    Console.Write("Are you ready to process?(y/n)");
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
                        Console.WriteLine("Press return to continue...or else");
                        Console.ReadLine();
                    }
                    else if (response == "n")
                    {
                        Program.DisplayBanner();
                        ChooseMeatFacility.CollectInput(farm, meatProcessor);
                    }
                    else
                    {
                        Console.Write("You're a dingus. Try again.");
                        response = Console.ReadLine();
                    }
                }
                else
                {
                    List<IChicken> chickensToProcess = farm.ChickenHouses[choice - 1].Chickens.Take(numberOfChickens).ToList();
                    meatProcessor.AddResource(chickensToProcess.Select(c => (IMeatProducing)c).ToList());
                    farm.ChickenHouses[choice - 1].Chickens.RemoveRange(0, numberOfChickens);
                    Program.DisplayBanner();
                    Console.WriteLine($"Successfully added {numberOfChickens} to the meat processor");
                    Console.Write("Are you ready to process?(y/n)");
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
                        Console.WriteLine("Press return to continue...or else");
                        Console.ReadLine();
                    }
                    else if (response == "n")
                    {
                        Program.DisplayBanner();
                        ChooseMeatFacility.CollectInput(farm, meatProcessor);
                    }
                    else
                    {
                        Console.Write("You're a dingus. Try again.");
                        response = Console.ReadLine();
                    }
                }
            }
            else
            {
                int index = choice - farm.ChickenHouses.Count() - 1;
                // Group animals by their type to display their counts
                List<IGrouping<string, IGrazing>> groupedAnimals = farm.GrazingFields[index].Animals.GroupBy(anml => anml.Type).ToList();

                foreach (IGrouping<string, IGrazing> anml in groupedAnimals)
                {
                    Console.WriteLine($"{anml.Key}: {anml.Count()}");
                }
            }
        }
    }
}