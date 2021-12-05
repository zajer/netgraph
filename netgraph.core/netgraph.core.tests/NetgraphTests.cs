using Microsoft.VisualStudio.TestTools.UnitTesting;
using Netgraph.Core.Library;
namespace netgraph.core.tests
{
    [TestClass]
    public class NetgraphTests
    {
        [TestMethod]
        public void GetAllSubisomorphisms_NoColors_NotDirected()
        {
            int[][] targetAdjacency = { new int[]{2}, new int[]{0,3}, new int[]{}, new int[]{} };
            int[][] patternAdjacency = { new int[]{1,2}, new int[]{}, new int[]{} };
            int[] targetColors = {};
            int[] patternColors = {};
            Graph target = new Graph(targetAdjacency,targetColors);
            Graph pattern = new Graph(patternAdjacency,patternColors);
            var fact = new Factory();
            var inet = fact.GetNetgraphProvider();
            var result = inet.AllIsomorphisms(target,pattern,false);
            int expectedNumberOfIsos = 4;
            Assert.AreEqual(expectedNumberOfIsos,result.GetUpperBound(0)+1);
        }
        [TestMethod]
        public void GetAllSubisomorphisms_NoColors_Directed()
        {
            int[][] targetAdjacency = { new int[]{2}, new int[]{0,3}, new int[]{}, new int[]{} };
            int[][] patternAdjacency = { new int[]{1,2}, new int[]{}, new int[]{} };
            int[] targetColors = {};
            int[] patternColors = {};
            Graph target = new Graph(targetAdjacency,targetColors);
            Graph pattern = new Graph(patternAdjacency,patternColors);
            var fact = new Factory();
            var inet = fact.GetNetgraphProvider();
            var result = inet.AllIsomorphisms(target,pattern,true);
            int expectedNumberOfIsos = 2;
            Assert.AreEqual(expectedNumberOfIsos,result.GetUpperBound(0)+1);   
        }
        [TestMethod]
        public void GetAllSubisomorphisms_Colors_NotDirected()
        {
            int[][] targetAdjacency = { new int[]{2}, new int[]{0,3}, new int[]{}, new int[]{} };
            int[][] patternAdjacency = { new int[]{1,2}, new int[]{}, new int[]{} };
            int[] targetColors = {0,0,2,2};
            int[] patternColors = {0,0,2};
            Graph target = new Graph(targetAdjacency,targetColors);
            Graph pattern = new Graph(patternAdjacency,patternColors);
            var fact = new Factory();
            var inet = fact.GetNetgraphProvider();
            var result = inet.AllIsomorphisms(target,pattern,false);
            int expectedNumberOfIsos = 2;
            Assert.AreEqual(expectedNumberOfIsos,result.GetUpperBound(0)+1);
            
        }
        [TestMethod]
        public void GetAllSubisomorphisms_Colors_Directed()
        {
            int[][] targetAdjacency = { new int[]{2}, new int[]{0,3}, new int[]{}, new int[]{} };
            int[][] patternAdjacency = { new int[]{1,2}, new int[]{}, new int[]{} };
            int[] targetColors = {0,0,2,2};
            int[] patternColors = {0,0,2};
            Graph target = new Graph(targetAdjacency,targetColors);
            Graph pattern = new Graph(patternAdjacency,patternColors);
            var fact = new Factory();
            var inet = fact.GetNetgraphProvider();
            var result = inet.AllIsomorphisms(target,pattern,true);
            int expectedNumberOfIsos = 1;
            Assert.AreEqual(expectedNumberOfIsos,result.GetUpperBound(0)+1);
            
        }
    }
}
