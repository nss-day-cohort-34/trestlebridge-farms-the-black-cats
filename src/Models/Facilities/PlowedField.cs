using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using System.Text;

namespace Trestlebridge.Models.Facilities
{
    public class PlowedField : IFacility<IPlowing>
    {
        private List<IPlowing> _plants { get; set; } = new List<IPlowing>();
        private double _capacity = 13;
        private Guid _id = Guid.NewGuid();

        public double Capacity
        {
            get
            {
                return _capacity;
            }
        }

        public List<IPlowing> Plants
        {
            get
            {
                return _plants;
            }
        }

        public void AddResource(IPlowing resource)
        {
            _plants.Add(resource);
        }

        public void AddResource(List<IPlowing> resources)
        {
            throw new System.NotImplementedException();
        }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Plowed Field {shortId} has {this._plants.Count} plants \n");
            this._plants.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}