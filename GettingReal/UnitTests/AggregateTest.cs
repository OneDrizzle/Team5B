using Microsoft.VisualStudio.TestTools.UnitTesting;
using GettingReal;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class AggregateTest
    {
        VentilationAggregateRepository agRepo;
        VentilationAggregate ag; 
        Filter f1, f2;
        List<Filter> filters;
        CustomerRepository customerRepo;

        [TestInitialize]
        public void Init()
        {
            ag = new VentilationAggregate("1234");
            f1 = new Filter("manufacturer1", "filterClass2", "model3","type4", 10);
            f2 = new Filter("manu1", "filtClass2", "mod3","typ4", 5);
            filters = new List<Filter>();
            agRepo = new VentilationAggregateRepository();
            agRepo.AddAggregate("model7", "4567");
            customerRepo = new CustomerRepository();
        }

        [TestMethod]
        public void AggregateCanBeInstantiatedWithParameters()
        {
            Assert.AreEqual("1234",ag.OrderNumber);
        }

        [TestMethod]
        public void FilterCanBeRetrievedFromAggregate()
        {
            ag.AddFilter(f1);
            filters = ag.GetFilters();
            Assert.AreEqual("type4", filters[0].Type);

            ag.AddFilter(f2);
            filters = ag.GetFilters();
            Assert.AreEqual("filtClass2", filters[1].FilterClass);
        }


        [TestMethod]
        public void AggregateCanBeCreatedFromRepo()
        {
            agRepo.AddAggregate(modelNumber: "111");
            Assert.AreEqual(1,agRepo.Count());
        }

        [TestMethod]
        public void EveryOrderNumberIsUnique()
        {
            agRepo.AddAggregate(orderNumber: "666", modelNumber: "A5");
            agRepo.AddAggregate(orderNumber: "555");
            agRepo.AddAggregate(orderNumber: "666", modelNumber: "B6");
            Assert.AreEqual(2, agRepo.Count());
        }

        [TestMethod]
        public void EmptyTest()
        {
            //Assert.AreEqual();
        }




    }
}
