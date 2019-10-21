using System;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Plants
{
    public class Wildflower : IResource, INatural
    {
        private double _compostProducedPerRow = 30.3;

        public string Type { get; } = "Wildflower";

        public int Rows { get; set; }

        public int PlantsPerRow { get; set; }

        public double Compost()
        {
            return _compostProducedPerRow;
        }

        public override string ToString () {
            return $"Wildflowers. Pretty!";
        }
    }
}