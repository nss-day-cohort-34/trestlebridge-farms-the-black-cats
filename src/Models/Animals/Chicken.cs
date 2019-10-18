using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Animals
{
    public class Chicken : IMeatProducing, IFeatherProducing, IEggProducing, IChicken, IResource
    {
        private Guid _id = Guid.NewGuid();
        private double _meatProduced = 1.7;
        private int _eggsProduced = 7;
        private double _feathersProduced = 0.5;


        public double FeedPerDay { get; set; } = 0.9;

        public string Type { get; } = "Chicken";
        private string _shortId
        {
            get
            {
                return this._id.ToString().Substring(this._id.ToString().Length - 6);
            }
        }

        public double Butcher()
        {
            return _meatProduced;
        }

        public int Collect()
        {
            return _eggsProduced;
        }

        public void Eat()
        {
            Console.WriteLine($"Chicken {this._shortId} just ate {this.FeedPerDay}kg of feed");
        }

        public double Pluck()
        {
            return _feathersProduced;
        }
        public override string ToString () {
            return $"Chicken {this._shortId}. Plock!";
        }
    }
}