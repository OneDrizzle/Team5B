using Microsoft.VisualStudio.TestTools.UnitTesting;
using GettingReal;

namespace UnitTests
{
    [TestClass]
    public class AggregateTest
    {
        Aggregate ag;
        Filter f1, f2;


        [TestInitialize]
        public void Init()
        {
            ag = new Aggregate("model1","1234");
            f1 = new Filter("manufacturer", "model", "type", 10);
        }

        [TestMethod]
        public void AggregateCanBeInstantiatedWithParameters()
        {
            Assert.AreEqual("model1",ag.ModelNumber);
        }

        [TestMethod]
        public void FilterCanBeCreatedAndIsAssociatedWithAggregate()
        {
            f2 = ag.GetFilter("manufacturer", "model", "type", 10);
            Assert.AreEqual(f1,f2);
        }

        [TestMethod]
        public void test()
        {
            //Assert.AreEqual();
        }




    }
}
