using System;

namespace netgraph.core.library
{
    public class Factory
    {
        public INetgraph GetNetgraphProvider(){
            return new NetgraphLinux64();
        }
    }
}
