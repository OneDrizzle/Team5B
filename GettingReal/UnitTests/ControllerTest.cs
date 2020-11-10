using Microsoft.VisualStudio.TestTools.UnitTesting;
using GettingReal;
using System.Collections.Generic;
using System.Xml.Linq;

namespace UnitTests
{
    [TestClass]
    public class ControllerTest
    {
        VentilationAggregate ag1, ag2, selectedAg;
        Filter f1, f2, f3;
        Controller ct;
        Customer cust;
        List<Filter> filters;
        CustomerRepository customerRepo;
        VentilationAggregateRepository agRepo;
        Building b1;


        [TestInitialize]
        public void Init()
        {
            ag1 = new VentilationAggregate(orderNumber: "1234");
            ag2 = new VentilationAggregate(modelNumber: "model1", orderNumber: "666");
            f1 = new Filter("manufacturer1", "model2", "filterClass3", "type4", 10);
            f2 = new Filter("manu1", "filtClass2", "mod3", "typ4", 5);
            f3 = new Filter("f3", "f3", "f3", "f3", 3);
            ct = new Controller();
            b1 = new Building();
            cust = new Customer();
            filters = new List<Filter>();
        }

        [TestMethod]
        public void AddVentilationAggregateFromController()
        {
            ct.AddVentilationAggregate(ag2);
            selectedAg = ct.GetVentilationAggregate("666");

            Assert.AreEqual("model1", selectedAg.ModelNumber);
        }
       
        [TestMethod]
        public void FilterInfoCanBeRetrievedWithOrderNumberFromController()
        {
            //ct.AddVentilationAggregate(ag1);
            agRepo.AddAggregate(ag1);
            selectedAg = ct.GetVentilationAggregate("1234");
                      
            selectedAg.AddFilter(f1);
            selectedAg.AddFilter(f2);
            selectedAg.AddFilter(f3);
            filters = ct.GetFilters("1234");

            Assert.AreEqual(3,filters[2].LifespanInMonths);
        }

        [TestMethod]
        public void EveryOrderNumberIsUnique()
        {
            ct.AddVentilationAggregate("123");
            ct.AddVentilationAggregate("1223233");
            bool result = ct.AddVentilationAggregate("123");

            Assert.IsTrue(result);

        }




    }
}