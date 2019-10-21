namespace Trestlebridge.Interfaces
{
    public interface INatural : IResource
    {
        int Rows { get; }
        int PlantsPerRow { get; set; }
        double Compost();
    }
}