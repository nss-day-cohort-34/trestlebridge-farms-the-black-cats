using System.Collections.Generic;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Facilities
{
    public class PlowedField : IFacility<IPlowing>
    {
        public double Capacity { get; set; }

        public void AddResource(IPlowing resource)
        {
            throw new System.NotImplementedException();
        }

        public void AddResource(List<IPlowing> resources)
        {
            throw new System.NotImplementedException();
        }
    }
}