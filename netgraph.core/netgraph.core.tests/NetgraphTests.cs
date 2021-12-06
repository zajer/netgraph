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
            bool areGraphsDirected = false;
            Graph target = new Graph(targetAdjacency,targetColors);
            Graph pattern = new Graph(patternAdjacency,patternColors);
            var fact = new Factory();
            var inet = fact.GetNetgraphProvider();
            var result = inet.AllSubIsomorphisms(target,pattern,areGraphsDirected);
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
            bool areGraphsDirected = true;
            Graph target = new Graph(targetAdjacency,targetColors);
            Graph pattern = new Graph(patternAdjacency,patternColors);
            var fact = new Factory();
            var inet = fact.GetNetgraphProvider();
            var result = inet.AllSubIsomorphisms(target,pattern,areGraphsDirected);
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
            bool areGraphsDirected = false;
            Graph target = new Graph(targetAdjacency,targetColors);
            Graph pattern = new Graph(patternAdjacency,patternColors);
            var fact = new Factory();
            var inet = fact.GetNetgraphProvider();
            var result = inet.AllSubIsomorphisms(target,pattern,areGraphsDirected);
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
            bool areGraphsDirected = true;
            Graph target = new Graph(targetAdjacency,targetColors);
            Graph pattern = new Graph(patternAdjacency,patternColors);
            var fact = new Factory();
            var inet = fact.GetNetgraphProvider();
            var result = inet.AllSubIsomorphisms(target,pattern,areGraphsDirected);
            int expectedNumberOfIsos = 1;
            Assert.AreEqual(expectedNumberOfIsos,result.GetUpperBound(0)+1);
            
        }
        [TestMethod]
        public void GetAllIsomorphisms_NoColors_NotDirected()
        {
            int[][] targetAdjacency = { new int[]{}, new int[]{}, new int[]{0,1}, new int[]{2} };
            int[][] patternAdjacency = { new int[]{1}, new int[]{2,3}, new int[]{}, new int[]{} };
            int[] targetColors = {};
            int[] patternColors = {};
            bool areGraphsDirected = false;
            Graph target = new Graph(targetAdjacency,targetColors);
            Graph pattern = new Graph(patternAdjacency,patternColors);
            var fact = new Factory();
            var inet = fact.GetNetgraphProvider();
            var result = inet.AllIsomorphisms(target,pattern,areGraphsDirected);
            int expectedNumberOfIsos = 6;
            Assert.AreEqual(expectedNumberOfIsos,result.GetUpperBound(0)+1);
        }
        [TestMethod]
        public void GetAllIsomorphisms_NoColors_NotDirected_test2()
        {
            int[][] targetAdjacency = { new int[]{}, new int[]{}, new int[]{0,1}, new int[]{2} };
            int[][] patternAdjacency = { new int[]{1,2}, new int[]{}, new int[]{} };
            int[] targetColors = {};
            int[] patternColors = {};
            bool areGraphsDirected = false;
            Graph target = new Graph(targetAdjacency,targetColors);
            Graph pattern = new Graph(patternAdjacency,patternColors);
            var fact = new Factory();
            var inet = fact.GetNetgraphProvider();
            var result = inet.AllIsomorphisms(target,pattern,areGraphsDirected);
            int expectedNumberOfIsos = 0;
            Assert.AreEqual(expectedNumberOfIsos,result.GetUpperBound(0)+1);
        }
        [TestMethod]
        public void GetAllIsomorphisms_NoColors_Directed()
        {
            int[][] targetAdjacency = { new int[]{}, new int[]{}, new int[]{0,1}, new int[]{2} };
            int[][] patternAdjacency = { new int[]{1}, new int[]{2,3}, new int[]{}, new int[]{} };
            int[] targetColors = {};
            int[] patternColors = {};
            bool areGraphsDirected = true;
            Graph target = new Graph(targetAdjacency,targetColors);
            Graph pattern = new Graph(patternAdjacency,patternColors);
            var fact = new Factory();
            var inet = fact.GetNetgraphProvider();
            var result = inet.AllIsomorphisms(target,pattern,areGraphsDirected);
            int expectedNumberOfIsos = 2;
            Assert.AreEqual(expectedNumberOfIsos,result.GetUpperBound(0)+1);
        }
        [TestMethod]
        public void GetAllIsomorphisms_Colors_NotDirected()
        {
            int[][] targetAdjacency = { new int[]{}, new int[]{}, new int[]{0,1}, new int[]{2} };
            int[][] patternAdjacency = { new int[]{1}, new int[]{2,3}, new int[]{}, new int[]{} };
            int[] targetColors = {0,1,1,0};
            int[] patternColors = {0,1,0,1};
            bool areGraphsDirected = false;
            Graph target = new Graph(targetAdjacency,targetColors);
            Graph pattern = new Graph(patternAdjacency,patternColors);
            var fact = new Factory();
            var inet = fact.GetNetgraphProvider();
            var result = inet.AllIsomorphisms(target,pattern,areGraphsDirected);
            int expectedNumberOfIsos = 2;
            Assert.AreEqual(expectedNumberOfIsos,result.GetUpperBound(0)+1);
        }
        [TestMethod]
        public void GetAllIsomorphisms_Colors_Directed()
        {
            int[][] targetAdjacency = { new int[]{}, new int[]{}, new int[]{0,1}, new int[]{2} };
            int[][] patternAdjacency = { new int[]{1}, new int[]{2,3}, new int[]{}, new int[]{} };
            int[] targetColors = {0,1,1,0};
            int[] patternColors = {0,1,0,1};
            bool areGraphsDirected = true;
            Graph target = new Graph(targetAdjacency,targetColors);
            Graph pattern = new Graph(patternAdjacency,patternColors);
            var fact = new Factory();
            var inet = fact.GetNetgraphProvider();
            var result = inet.AllIsomorphisms(target,pattern,areGraphsDirected);
            int expectedNumberOfIsos = 1;
            Assert.AreEqual(expectedNumberOfIsos,result.GetUpperBound(0)+1);
        }     
    }
}
