namespace Trestlebridge.Interfaces
{
    public interface IChicken
    {
        double FeedPerDay { get; set; }
        void Eat();
    }
}