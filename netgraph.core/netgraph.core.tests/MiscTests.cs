using Microsoft.VisualStudio.TestTools.UnitTesting;
using netgraph.core.library;

namespace netgraph.core.tests
{
    [TestClass]
    public class MiscTests
    {
        [TestMethod]
        public void TestIfIgraphIsCompiledWithTLS()
        {
            var fact = new Factory();
            var inet = fact.GetNetgraphProvider();
            Assert.IsTrue(inet.IsIgraphThreadSafe());
        }
    }
}
