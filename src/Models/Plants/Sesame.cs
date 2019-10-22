using System;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Plants
{
    public class Sesame : IResource, ISeedProducing, IPlowing
    {
        private Guid _id = Guid.NewGuid();
        private string _shortId
        {
            get
            {
                return this._id.ToString().Substring(this._id.ToString().Length - 6);
            }
        }
        private int _seedsProduced = 520;
        public string Type { get; } = "Sesame";

        public int Rows => throw new NotImplementedException();

        public int PlantsPerRow { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public double Harvest () {
            return _seedsProduced;
        }

        public void Plow()
        {
            throw new NotImplementedException();
        }

        public override string ToString () {
            return $"Sesame {_shortId}. Yum!";
        }
    }
}