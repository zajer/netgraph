using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("Netgraph.Core.Tests")]
namespace netgraph.core.library
{
    
    internal static class Utils {
        public static int[] FlattenArrayOfArrays(int[][] toFlatten){
            int length = 0;
            foreach(int[] inner in toFlatten){
                length += inner.Length + 1;    
            }
            int[] result = new int[length];
            int idx = 0;
            for(int i=0;i<toFlatten.Length;i++){
                result[idx]=toFlatten[i].Length;
                idx++;
                for(int j=0;j<toFlatten[i].Length;j++){
                    result[idx] = toFlatten[i][j];
                    idx++;
                }
            }
            
            return result;
        }
    }

}