namespace netgraph.core.library
{
    internal unsafe struct NatGraph {
        public int number_of_vertices { get; set;}
        public int* adjacency_data { get; set; } //flattened 2d array where inner arrays can vary in length
        public int* vertices_colors { get; set;}
    }
}