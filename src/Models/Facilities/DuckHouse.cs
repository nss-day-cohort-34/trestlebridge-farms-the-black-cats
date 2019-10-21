using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Actions;


namespace Trestlebridge.Models.Facilities
{
    public class DuckHouse : IFacility<IChicken>
    {
        private int _capacity = 12;
        private Guid _id = Guid.NewGuid();

        private List<IChicken> _ducks = new List<IChicken>();

        public double Capacity
        {
            get
            {
                return _capacity;
            }
        }

        public List<IChicken> Ducks
        {
            get
            {
                return _ducks;
            }
        }

        public void AddResource(IChicken duck)
        {
            _ducks.Add(duck);
        }

        public void AddResource(List<IChicken> Ducks)
        {
            // TODO: implement this...
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Duck House {shortId} has {this._ducks.Count} Ducks\n");
            this._ducks.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}