namespace Algorithms.DataStructures.Graphs
{
    public interface IWeightedEdge
    {
        double Cost { get; }
    }

    public class SimpleWeightedEdge : IWeightedEdge
    {
        public double Cost { get; set; }
    }
}
