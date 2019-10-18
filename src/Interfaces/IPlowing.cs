namespace Trestlebridge.Interfaces
{
    public interface IPlowing
    {
        int Rows { get; }
        int PlantsPerRow { get; set; }
        void Plow();
    }
}