namespace Trestlebridge.Interfaces
{
    public interface INatural
    {
        int Rows { get; }
        int PlantsPerRow { get; set; }
        void Harvest();
    }
}