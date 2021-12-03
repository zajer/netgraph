namespace netgraph.core.library
{
    public interface INetgraph
    {
        bool IsIgraphThreadSafe();
        int[,] AllIsomorphisms(Graph target,Graph pattern,bool areGraphsDirected);
    }
}
