namespace Netgraph.Core.Library
{
    public interface INetgraph
    {
        bool IsIgraphThreadSafe();
        int[,] AllSubIsomorphisms(Graph target,Graph pattern,bool areGraphsDirected);
        int[,] AllIsomorphisms(Graph target,Graph pattern,bool areGraphsDirected);
    }
}
