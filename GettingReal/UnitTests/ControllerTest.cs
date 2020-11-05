using Microsoft.VisualStudio.TestTools.UnitTesting;
using GettingReal;

namespace UnitTests
{
    [TestClass]
    public class ControllerTest
    {
        Aggregate ag, selectedAg;
        Filter f1, f2;
        AggregateRepository agRepo;
        Controller ct;


        [TestInitialize]
        public void Init()
        {
            f1 = new Filter("manu1", "model2", "type3", 2);
            ag = new Aggregate("model1", "1234");
            ct = new Controller();
        }

        [TestMethod]
        public void FilterCanBeCreatedAndIsAssociatedWithAggregate()
        {
            selectedAg = ag;
            selectedAg.selectedFilter = f1;

            string getfilterFromController = ct.GetFilterInfo("1234");

            Assert.AreEqual("Producent: manu1\nModel: model2\nType: type3\nLevetid i måneder: 2", getfilterFromController);
        }

    }
}