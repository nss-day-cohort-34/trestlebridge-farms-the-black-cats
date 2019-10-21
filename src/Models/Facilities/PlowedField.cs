using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using System.Text;

namespace Trestlebridge.Models.Facilities
{
    public class PlowedField : IFacility<IPlowing>
    {
        private List<IPlowing> _plowedFields { get; set; } = new List<IPlowing>();
        public double Capacity { get; set; }
        private Guid _id = Guid.NewGuid();


        public void AddResource(IPlowing resource)
        {
            _plowedFields.Add(resource);
        }

        public void AddResource(List<IPlowing> resources)
        {
            throw new System.NotImplementedException();
        }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Plowed Field {shortId} has {this._plowedFields.Count} plants \n");
            this._plowedFields.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}