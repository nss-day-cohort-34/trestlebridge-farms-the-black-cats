using System;
using Trestlebridge.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Trestlebridge.Models.Processors
{
    public class MeatProcessor : IFacility<IMeatProducing>
    {
        private double _capacity = 7;
        public double Capacity
        {
            get
            {
                return _capacity;
            }
        }

        public List<IMeatProducing> AnimalsToBeProcessed = new List<IMeatProducing>();

        public void AddResource(IMeatProducing resource)
        {
            if (AnimalsToBeProcessed.Count + 1 <= _capacity)
            {
                AnimalsToBeProcessed.Add(resource);
            }
            else
            {
                Console.WriteLine("Meat Processor is full!");
            }
        }

        public void AddResource(List<IMeatProducing> resources)
        {
            if (AnimalsToBeProcessed.Count + resources.Count < _capacity)
            {

                foreach (IMeatProducing animal in resources)
                {
                    AnimalsToBeProcessed.Add(animal);
                }
            }
            else
            {
                Console.WriteLine("Not enough space in this Meat Processor. \nPlease select another...");
            }
        }
    }
}