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
            f1 = new Filter("manufacturer1", "filterClass2", "model3", 10);
            ag = new Aggregate("model1", "1234");
            ct = new Controller();
        }

        [TestMethod]
        public void FilterInfoCanBeRetrievedFromController()
        {
            ag.AddFilter(f1);
            string filterStringFromController = ct.GetFilterInfo("1234");

            Assert.AreEqual("Producent: manufacturer1\nFilterklasse: filterClass2\nModel: model3\nLevetid i måneder: 10", filterStringFromController);
        }

    }
}