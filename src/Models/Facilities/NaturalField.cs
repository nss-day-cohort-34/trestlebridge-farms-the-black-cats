using System;
using System.Collections.Generic;
using System.Text;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Facilities
{
    public class NaturalField : IFacility<INatural>
    {
        public double Capacity { get; set; }

        private List<INatural> _naturalFields = new List<INatural>();

        public void AddResource(List<INatural> resources)
        {
            throw new System.NotImplementedException();
        }

        public void AddResource(INatural field)
        {
            _naturalFields.Add(field);
        }

        private Guid _id = Guid.NewGuid();

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Natural Field {shortId} has {this._naturalFields.Count} plants \n");
            this._naturalFields.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}