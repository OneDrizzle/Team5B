using Microsoft.VisualStudio.TestTools.UnitTesting;
using GettingReal;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class ControllerTest
    {
        Aggregate ag, selectedAg;
        Filter f1, f2;
        AggregateRepository agRepo;
        Controller ct;
        Customer cust;
        List<Filter> filters;


        [TestInitialize]
        public void Init()
        {
            f1 = new Filter("manufacturer1", "model2", "filterClass3", "type4", 10);
            ag = new Aggregate("model1", "1234");
            ct = new Controller();
            cust = new Customer();
            filters = new List<Filter>();
        }

        [TestMethod]
        public void FilterInfoCanBeRetrievedFromController()
        {
            ag.AddFilter(f1);
            string filterStringFromController = ct.GetFilters();

            Assert.AreEqual("Producent: manufacturer1\nFilterklasse: filterClass2\nModel: model3\nLevetid i måneder: 10", filterStringFromController);
        }

        [TestMethod]
        public void AddAggregateFromController()
        {
            // 
            ct.AddAggregate(modelNumber:"model1", orderNumber:"666", customer: cust);
            Assert.AreEqual(ct.selectedAggregate, agRepo.GetAggregate("666"));

            ct.selectedAggregate.OrderNumber = "555";
            Assert.AreEqual(ct.selectedAggregate, agRepo.GetAggregate("555"));
        }

    }
}