using System;
using Trestlebridge;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions
{
    public class ProcessResources
    {
        public static void CollectInput(Farm farm)
        {

            Console.WriteLine("1. Meat Processor");
            Console.WriteLine("2. Seed Harvester");
            Console.WriteLine("3. Composter");
            Console.WriteLine("4. Feather Harvester");
            Console.WriteLine("5. Egg Gatherer");

            Console.WriteLine();
            Console.WriteLine("What are you processing today?");

            Console.Write("> ");
            string choice = Console.ReadLine();

            switch (Int32.Parse(choice))
            {
                case 1:
                    // Choose Animals to Process Meat
                    break;
                default:
                    break;
            }
        }
    }
}