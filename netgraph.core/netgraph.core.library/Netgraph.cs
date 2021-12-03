namespace netgraph.core.library
{
    internal class Netgraph : INetgraph
    {
        private INativeNetgraph _nativeProvider;
        public Netgraph(INativeNetgraph nativeImpl){
            _nativeProvider = nativeImpl;
        }

        public bool IsIgraphThreadSafe() { return _nativeProvider.IsIgraphThreadSafe() == 1 ? true : false; }
        
        public int[,] AllIsomorphisms (Graph target, Graph pattern, bool areGraphsDirected) {
            int[,] result;
            int[] flattenedTargetAdjacency = Utils.FlattenArrayOfArrays(target.Adjacency);
            int[] flattenedPatternAdjacency = Utils.FlattenArrayOfArrays(pattern.Adjacency);
            unsafe {
                fixed(
                    int* nativeTargetAdjacency = flattenedTargetAdjacency,
                    nativePatternAdjacency = flattenedPatternAdjacency,
                    nativeTargetColors = target.Colors,
                    nativePatternColors = pattern.Colors
                    ){
                        NatGraph nativeTarget = new NatGraph();
                        NatGraph nativePattern = new NatGraph();
                        nativeTarget.adjacency_data = nativeTargetAdjacency;
                        nativeTarget.number_of_vertices = target.NumberOfVertices;
                        nativeTarget.vertices_colors = nativeTargetColors;
                        nativePattern.adjacency_data = nativePatternAdjacency;
                        nativePattern.number_of_vertices = pattern.NumberOfVertices;
                        nativePattern.vertices_colors = nativePatternColors;
                        int nativeFlag = areGraphsDirected ? 1 : 0;
                        FoundIsomorphisms nativeResult = _nativeProvider.GetAllIsomorphisms(nativeTarget,nativePattern,nativeFlag);
                        result = new int[nativeResult.number_of_isos,pattern.NumberOfVertices];
                        for(int i=0;i<nativeResult.number_of_isos;i++)
                            for(int j=0;j<pattern.NumberOfVertices;j++)
                                result[i,j]=nativeResult.isos[i][j];
                }
            }
            
            return result;
        }
    }
}
