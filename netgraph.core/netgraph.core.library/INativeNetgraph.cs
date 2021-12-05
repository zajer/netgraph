namespace Netgraph.Core.Library
{
    internal interface INativeNetgraph
    {
        int IsIgraphThreadSafe();
        FoundIsomorphisms GetAllIsomorphisms(
            NatGraph target,
            NatGraph pattern,
            int are_graphs_directed
            );
    }
}
