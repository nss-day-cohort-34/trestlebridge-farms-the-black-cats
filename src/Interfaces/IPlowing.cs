namespace Trestlebridge.Interfaces
{
    public interface IPlowing : IResource
    {
        int Rows { get; }
        int PlantsPerRow { get; set; }
        void Plow();
    }
}