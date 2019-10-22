using System;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Plants
{
    public class Wildflower : IResource, INatural
    {
        private Guid _id = Guid.NewGuid();
        private string _shortId
        {
            get
            {
                return this._id.ToString().Substring(this._id.ToString().Length - 6);
            }
        }
        private double _compostProducedPerRow = 30.3;

        public string Type { get; } = "Wildflower";

        public int Rows { get; set; }

        public int PlantsPerRow { get; set; }

        public double Compost()
        {
            return _compostProducedPerRow;
        }

        public override string ToString () {
            return $"Wildflowers {_shortId}. Pretty!";
        }
    }
}