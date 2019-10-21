using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions
{
    public class CreateFacility
    {
        public static void CollectInput(Farm farm)
        {
            Console.WriteLine("1. Grazing field");
            Console.WriteLine("2. Plowed field");
            Console.WriteLine("3. Natural field");
            Console.WriteLine("4. Chicken House");
            Console.WriteLine("5. Duck House");


            Console.WriteLine();
            Console.WriteLine("Choose what you want to create");

            Console.Write("> ");
            string input = Console.ReadLine();

            switch (Int32.Parse(input))
            {
                case 1:
                    farm.AddGrazingField(new GrazingField());
                    Console.WriteLine("Grazing Field Added!!!");
                    Console.Write("Press any key to continue");
                    Console.ReadLine();
                    break;
                case 2:
                    farm.AddPlowedField(new PlowedField());
                    Console.WriteLine("Plowed Field Added!!!");
                    Console.Write("Press any key to continue");
                    Console.ReadLine();
                    break;
                case 3:
                    farm.AddNaturalField(new NaturalField());
                    Console.WriteLine("Natural Field Added!!!");
                    Console.Write("Press any key to continue");
                    Console.ReadLine();
                    break;
                case 4:
                    farm.AddChickenHouse(new ChickenHouse());
                    Console.WriteLine("Chicken House Added!!!");
                    Console.Write("Press any key to continue");
                    Console.ReadLine();
                    break;
                case 5:
                    farm.AddDuckHouse(new DuckHouse());
                    Console.WriteLine("Duck House Added!!!");
                    Console.Write("Press any key to continue");
                    Console.ReadLine();
                    break;
                default:
                    break;
            }
        }
    }
}