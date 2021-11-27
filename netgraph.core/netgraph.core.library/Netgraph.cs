using System;
namespace netgraph.core.library
{
    internal class Netgraph : INetgraph
    {

        private INativeNetgraph _nativeProvider;
        public Netgraph(INativeNetgraph nativeImpl){
            _nativeProvider = nativeImpl;
        }

        public bool IsIgraphThreadSafe() { return _nativeProvider.IsIgraphThreadSafe() == 1 ? true : false; }
        

    }
}
