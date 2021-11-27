using System;
using System.Runtime.InteropServices;
namespace netgraph.core.library
{
    public class NetgraphLinux64 : INativeNetgraph
    {

        [DllImport("native/linux-x64/libNetgraphNative.so")]
        static extern int is_igraph_thread_safe();

        public int IsIgraphThreadSafe(){
            return is_igraph_thread_safe();
        }

    }
}
