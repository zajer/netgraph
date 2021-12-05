namespace Netgraph.Core.Library
{
    public interface INetgraph
    {
        bool IsIgraphThreadSafe();
        int[,] AllIsomorphisms(Graph target,Graph pattern,bool areGraphsDirected);
    }
}
