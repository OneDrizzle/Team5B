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
            ag = new Aggregate("1234");
            f1 = new Filter("manufacturer1", "filterClass2", "model3", 10);
        }

        [TestMethod]
        public void AggregateCanBeInstantiatedWithParameters()
        {
            Assert.AreEqual("model1",ag.ModelNumber);
        }

        [TestMethod]
        public void FilterCanBeCreatedAndAssociatedWithAggregate()
        {
            ag.AddFilter(f1);
            Assert.AreEqual(f1, ag.filter);
        }

        [TestMethod]
        public void FilterInfoCanBeRetrievedFromAggregateClass()
        {
            ag.AddFilter(f1);
            Assert.AreEqual("Producent: manufacturer1\nFilterklasse: filterClass2\nModel: model3\nLevetid i måneder: 10", ag.GetFilterInfo());
        }

        [TestMethod]
        public void test()
        {
            //Assert.AreEqual();
        }




    }
}
