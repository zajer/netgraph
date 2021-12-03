using System;
namespace netgraph.core.library
{
    public struct Graph {
        public int[][] Adjacency {get; init;}
        public int[] Colors {get; init;}
        public int NumberOfVertices {get;init;}
        public Graph(int[][] verticesAdjacency, int[] verticesColors){
            if (verticesAdjacency.Length != verticesColors.Length)
                if ( verticesColors.Length != 0 )
                    throw new ArgumentException("Graph has to have either all vertices colored or none");
            Adjacency = verticesAdjacency;
            Colors = verticesColors;
            NumberOfVertices=Adjacency.Length;
        }
    }
}