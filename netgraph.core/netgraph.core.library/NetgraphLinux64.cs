using System.Runtime.InteropServices;
namespace netgraph.core.library
{
    internal class NetgraphLinux64 : INativeNetgraph
    {

        [DllImport("native/linux-x64/libNetgraphNative.so")]
        static extern int is_igraph_thread_safe();
        [DllImport("native/linux-x64/libNetgraphNative.so")]
        static extern FoundIsomorphisms get_all_subisos(
            NatGraph target,
            NatGraph pattern,
            int are_graphs_directed
            /*
            int[][] target_adjacency,
            int ta_size,
            int[] target_vertices_colors,
            int[][] pattern_adjacency,
            int pa_size,
            int[] pattern_vertices_colors,
            int are_graphs_directed
            */
            );

        public int IsIgraphThreadSafe(){
            return is_igraph_thread_safe();
        }

        public FoundIsomorphisms GetAllIsomorphisms(
            NatGraph target,
            NatGraph pattern,
            int are_graphs_directed
            /*
            int[][] target_adjacency,
            int ta_size,
            int[] target_vertices_colors,
            int[][] pattern_adjacency,
            int pa_size,
            int[] pattern_vertices_colors,
            int are_graphs_directed
            */
            ){
                return get_all_subisos(
                    target,
                    pattern,
                    are_graphs_directed);

                    //target_adjacency,ta_size,target_vertices_colors,pattern_adjacency,pa_size,pattern_vertices_colors,are_graphs_directed);
        }
        

    }
}
