namespace netgraph.core.library {
    internal unsafe struct FoundIsomorphisms
    {
        public int number_of_isos { get; init; }
        public int** isos { get; init;}
    }
}