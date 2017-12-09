namespace Algorithms.DataStructures.Graphs
{
    public interface IWeightedEdge
    {
        double Cost { get; }
    }

    public class SimpleWeightedEdge : IWeightedEdge
    {
        public SimpleWeightedEdge(double cost)
        {
            Cost = cost;
        }

        public double Cost { get; set; }
    }
}
