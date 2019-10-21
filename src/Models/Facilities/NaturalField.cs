using System;
using System.Collections.Generic;
using System.Text;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Facilities
{
    public class NaturalField : IFacility<INatural>
    {
        private double _capacity = 10;

        private List<INatural> _plants = new List<INatural>();

        public double Capacity
        {
            get
            {
                return _capacity;
            }
        }

        public List<INatural> Plants
        {
            get
            {
                return _plants;
            }
        }

        public void AddResource(List<INatural> resources)
        {
            throw new System.NotImplementedException();
        }

        public void AddResource(INatural plant)
        {
            _plants.Add(plant);
        }

        private Guid _id = Guid.NewGuid();

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Natural Field {shortId} has {this._plants.Count} rows \n");
            this._plants.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}