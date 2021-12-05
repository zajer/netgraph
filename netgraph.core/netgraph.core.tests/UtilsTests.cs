using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace netgraph.core.tests
{
    [TestClass]
    public class UtilsTests
    {
        [TestMethod]
        public void FlattenArrayOfArraysTest1()
        {
            int[] expectedResult = {1,7,3,99,44,12};
            int[][] input = { new int[] { 7 }, new int[] {99,44,12}};
            int[] result = Netgraph.Core.Library.Utils.FlattenArrayOfArrays(input);
            CollectionAssert.AreEqual(expectedResult,result);
        }
    }
}
