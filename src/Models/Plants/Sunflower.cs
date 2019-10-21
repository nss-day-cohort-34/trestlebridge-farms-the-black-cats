using System;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Plants
{
    public class Sunflower : IResource, ISeedProducing, INatural, IPlowing
    {
        private Guid _id = Guid.NewGuid();
        private string _shortId
        {
            get
            {
                return this._id.ToString().Substring(this._id.ToString().Length - 6);
            }
        }
        private int _seedsProducedPerRow = 650;
        private double _compostProducedPerRow = 21.6;
        public string Type { get; } = "Sunflower";

        public int Rows { get; set; }

        public int PlantsPerRow { get; set; }

        public double Compost()
        {
            return _compostProducedPerRow;
        }

        public double Harvest()
        {
            return _seedsProducedPerRow;
        }

        public void Plow()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"Sunflower {_shortId}. Prettyum!";
        }

    }
}