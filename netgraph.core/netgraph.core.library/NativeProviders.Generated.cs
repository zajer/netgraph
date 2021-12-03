using System.Runtime.InteropServices;
namespace netgraph.core.library {
    internal class Linux64NativeProvider : INativeNetgraph
    {
        private const string DLL_NAME = @"native/linux-x64/libNetgraphNative.so";
        
        [DllImport(DLL_NAME)]
        static extern int is_igraph_thread_safe();
        [DllImport(DLL_NAME)]
        static extern FoundIsomorphisms get_all_subisos(
            NatGraph target,
            NatGraph pattern,
            int are_graphs_directed
            );

        public int IsIgraphThreadSafe(){
            return is_igraph_thread_safe();
        }

        public FoundIsomorphisms GetAllIsomorphisms(
            NatGraph target,
            NatGraph pattern,
            int are_graphs_directed
            ){
                return get_all_subisos(
                    target,
                    pattern,
                    are_graphs_directed);
        }
    }
    }
