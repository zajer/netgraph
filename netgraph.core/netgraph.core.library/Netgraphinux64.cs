using System;
using System.Runtime.InteropServices;
namespace netgraph.core.library
{
    public class NetgraphLinux64 : INetgraph
    {

        [DllImport("native/linux-x64/libNetgraphNative.so")]
        static extern int is_igraph_thread_safe();

        public bool IsIgraphThreadSafe() { return is_igraph_thread_safe() == 1 ? true : false; }
        

    }
}
