using System;
using System.Collections.Generic;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions
{
    public class ChoosePlantField
    {
        public static void CollectInput(Farm farm, INatural plant)
        {
            Console.Clear();

            if (farm.NaturalFields.Count() == 0 || farm.NaturalFields.Where(field => field.Plants.Count == field.Capacity).ToList().Count == farm.NaturalFields.Count())
            {
                Console.WriteLine("There are no available natural fields. Try creating a new one.");
                Console.WriteLine("Press return... or else");
                Console.ReadLine();
            }
            else
            {
                for (int i = 0; i < farm.NaturalFields.Count; i++)
                {
                    // Only display plowed fields that have room
                    if (farm.NaturalFields[i].Plants.Count < farm.NaturalFields[i].Capacity)
                    {
                        Console.WriteLine("=================================================");
                        Console.WriteLine($"{i + 1}. Natural Field. Current Plant Count: {farm.NaturalFields[i].Plants.Count}");

                        // Group Natural Fields by their type to display their counts
                        List<IGrouping<string, INatural>> groupedNaturalFields = farm.NaturalFields[i].Plants.GroupBy(plnt => plnt.Type).ToList();

                        foreach (IGrouping<string, INatural> plnt in groupedNaturalFields)
                        {
                            Console.WriteLine($"{plnt.Key}: {plnt.Count()} rows");
                        }
                        Console.WriteLine("=================================================");
                    }
                }

                Console.WriteLine();

                // How can I output the type of plant chosen here?
                Console.WriteLine($"Place the {plant.Type} where?");

                Console.Write("> ");
                try
                {
                    int choice = Int32.Parse(Console.ReadLine());


                    if (farm.NaturalFields[choice - 1].Plants.Count < farm.NaturalFields[choice - 1].Capacity)
                    {
                        farm.NaturalFields[choice - 1].AddResource(plant);
                    }
                    else if (farm.NaturalFields.Where(field => field.Plants.Count < field.Capacity).ToList().Count > 0)
                    {
                        Console.Write("Facility is full. Please select another facility. Press return to continue...");
                        Console.ReadLine();
                        ChoosePlantField.CollectInput(farm, plant);
                    }
                    else
                    {
                        Console.Write("All facilities full. Press return to continue...");
                        Console.ReadLine();
                    }
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Please enter one of the specified options...\nI love you.\nPress return to continue");
                    Console.ReadLine();
                    ChoosePlantField.CollectInput(farm, plant);
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    Console.WriteLine("The plant field you selected does not exist\nPress return to continue");
                    Console.ReadLine();
                    ChoosePlantField.CollectInput(farm, plant);
                }
            }
        }
        public static void CollectInput(Farm farm, IPlowing plant)
        {
            Console.Clear();

            if (farm.PlowedFields.Count() == 0 || farm.PlowedFields.Where(field => field.Plants.Count == field.Capacity).ToList().Count == farm.PlowedFields.Count())
            {
                Console.WriteLine("There are no available plowed fields. Try creating a new one.");
                Console.WriteLine("Press return... or else");
                Console.ReadLine();
            }
            else
            {
                for (int i = 0; i < farm.PlowedFields.Count; i++)
                {
                    // Only display plowed fields that have room
                    if (farm.PlowedFields[i].Plants.Count < farm.PlowedFields[i].Capacity)
                    {
                        Console.WriteLine("=================================================");
                        Console.WriteLine($"{i + 1}. Plowed Field. Current Plant Count: {farm.PlowedFields[i].Plants.Count}");

                        // Group Plowed Fields by their type to display their counts
                        List<IGrouping<string, IPlowing>> groupedPlowedFields = farm.PlowedFields[i].Plants.GroupBy(plnt => plnt.Type).ToList();

                        foreach (IGrouping<string, IPlowing> plnt in groupedPlowedFields)
                        {
                            Console.WriteLine($"{plnt.Key}: {plnt.Count()} rows");
                        }
                        Console.WriteLine("=================================================");
                    }
                }

                Console.WriteLine();

                // How can I output the type of plant chosen here?
                Console.WriteLine($"Place the {plant.Type} where?");

                Console.Write("> ");
                try
                {


                    int choice = Int32.Parse(Console.ReadLine());


                    if (farm.PlowedFields[choice - 1].Plants.Count < farm.PlowedFields[choice - 1].Capacity)
                    {
                        farm.PlowedFields[choice - 1].AddResource(plant);
                    }
                    else if (farm.PlowedFields.Where(field => field.Plants.Count < field.Capacity).ToList().Count > 0)
                    {
                        Console.Write("Facility is full. Please select another facility. Press return to continue...");
                        Console.ReadLine();
                        ChoosePlantField.CollectInput(farm, plant);
                    }
                    else
                    {
                        Console.Write("All facilities full. Press return to continue...");
                        Console.ReadLine();
                    }
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Please enter one of the specified options...\nI love you.\nPress return to continue");
                    Console.ReadLine();
                    ChoosePlantField.CollectInput(farm, plant);
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    Console.WriteLine("The plant field you selected does not exist\nPress return to continue");
                    Console.ReadLine();
                    ChoosePlantField.CollectInput(farm, plant);
                }
            }
        }
        public static void CollectInput<T>(Farm farm, T plant) where T : INatural, IPlowing
        {
            int counter = 0;

            List<NaturalField> availableNaturalFields = farm.NaturalFields.Where(field => field.Plants.Count < field.Capacity).ToList();
            List<PlowedField> availablePlowedFields = farm.PlowedFields.Where(field => field.Plants.Count < field.Capacity).ToList();

            Console.Clear();
            if (availableNaturalFields.Count() == 0 && availablePlowedFields.Count() == 0)
            {
                Console.WriteLine("There are no available fields. Try creating a new one.");
                Console.WriteLine("Press return... or else");
                Console.ReadLine();
            }
            else
            {
                for (int i = 0; i < farm.PlowedFields.Count; i++)
                {
                    // Only display plowed fields that have room
                    if (farm.PlowedFields[i].Plants.Count < farm.PlowedFields[i].Capacity)
                    {
                        Console.WriteLine("=================================================");
                        Console.WriteLine($"{counter + 1}. Plowed Field. Current Plant Count: {farm.PlowedFields[i].Plants.Count}");

                        // Group Plowed Fields by their type to display their counts
                        List<IGrouping<string, IPlowing>> groupedPlowedFields = farm.PlowedFields[i].Plants.GroupBy(plnt => plnt.Type).ToList();

                        foreach (IGrouping<string, IPlowing> plnt in groupedPlowedFields)
                        {
                            Console.WriteLine($"{plnt.Key}: {plnt.Count()} rows");
                        }
                        Console.WriteLine("=================================================");
                    }
                    counter++;
                }

                for (int i = 0; i < farm.NaturalFields.Count; i++)
                {
                    // Only display plowed fields that have room
                    if (farm.NaturalFields[i].Plants.Count < farm.NaturalFields[i].Capacity)
                    {
                        Console.WriteLine("=================================================");
                        Console.WriteLine($"{counter + 1}. Natural Field. Current Plant Count: {farm.NaturalFields[i].Plants.Count}");

                        // Group Natural Fields by their type to display their counts
                        List<IGrouping<string, INatural>> groupedNaturalFields = farm.NaturalFields[i].Plants.GroupBy(plnt => plnt.Type).ToList();

                        foreach (IGrouping<string, INatural> plnt in groupedNaturalFields)
                        {
                            Console.WriteLine($"{plnt.Key}: {plnt.Count()} rows");
                        }
                        Console.WriteLine("=================================================");
                    }
                    counter++;
                }

                Console.WriteLine();

                // How can I output the type of plant chosen here?
                Console.WriteLine($"Place the {plant.Type} where?");

                Console.Write("> ");
                try
                {


                    int choice = Int32.Parse(Console.ReadLine());

                    if (choice <= farm.PlowedFields.Count)
                    {
                        if (farm.PlowedFields[choice - 1].Plants.Count < farm.PlowedFields[choice - 1].Capacity)
                        {
                            farm.PlowedFields[choice - 1].AddResource(plant);
                        }
                        else if (farm.PlowedFields.Where(field => field.Plants.Count < field.Capacity).ToList().Count > 0)
                        {
                            Console.Write("Facility is full. Please select another facility. Press return to continue...");
                            Console.ReadLine();
                            ChoosePlantField.CollectInput(farm, plant);
                        }
                        else
                        {
                            Console.Write("Facility is full. Press return to continue...");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        int index = choice - farm.PlowedFields.Count - 1;
                        if (farm.NaturalFields[index].Plants.Count < farm.NaturalFields[index].Capacity)
                        {
                            farm.NaturalFields[index].AddResource(plant);
                        }
                        else if (farm.NaturalFields.Where(field => field.Plants.Count < field.Capacity).ToList().Count > 0)
                        {
                            Console.Write("Facility is full. Please select another facility. Press return to continue...");
                            Console.ReadLine();
                            ChoosePlantField.CollectInput(farm, plant);
                        }
                        else
                        {
                            Console.Write("Facility is full. Press return to continue...");
                            Console.ReadLine();
                        }
                    }
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Please enter one of the specified options...\nI love you.\nPress return to continue");
                    Console.ReadLine();
                    ChoosePlantField.CollectInput(farm, plant);
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    Console.WriteLine("The plant field you selected does not exist\nPress return to continue");
                    Console.ReadLine();
                    ChoosePlantField.CollectInput(farm, plant);
                }
            }
        }
    }
}