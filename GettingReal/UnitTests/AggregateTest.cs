using Microsoft.VisualStudio.TestTools.UnitTesting;
using GettingReal;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;

namespace UnitTests
{
    [TestClass]
    public class AggregateTest
    {


        VentilationAggregateRepository agRepo;
        VentilationAggregate ag1, ag2, selectedAg; 
        Filter f1, f2;
        List<Filter> filters;
        List<VentilationAggregate> ventilationAggregates;
        List<Building> buildingList;
        CustomerRepository customerRepo;
        BuildingRepository buildingRepo;
        Customer c1, selectedCustomer;
        Building b1, b2, selectedBuilding;

        [TestInitialize]
        public void Init()
        {
            ag1 = new VentilationAggregate(orderNumber:"1234");
            ag2 = new VentilationAggregate(orderNumber:"5678");
            f1 = new Filter("manufacturer1", "filterClass2", "model3","type4", 10);
            f2 = new Filter("manu1", "filtClass2", "mod3","typ4", 5);
            c1 = new Customer(name: "Jens");
            b1 = new Building("Scandic");
            b2 = new Building("Arla");
            buildingList = new List<Building>();
            filters = new List<Filter>();
            ventilationAggregates = new List<VentilationAggregate>();
            agRepo = new VentilationAggregateRepository();
            agRepo.AddVentilationAggregate("4567");
            customerRepo = new CustomerRepository();
        }

        [TestMethod]
        public void VentilationAggregateCanBeInstantiatedWithParameters()
        {
          
            Assert.AreEqual("1234", ag1.OrderNumber);
        }

        [TestMethod]
        public void BuildingCanGetListOfVentilationAggregates()
        {
            b1.AddVentilationAggregate(ag1);
            b1.AddVentilationAggregate(ag2);
            //foreach (VentilationAggregate aggregate in b1.GetListOfVentilationAggregates())
            //    ventilationAggregates.Add(aggregate);
            ventilationAggregates = b1.GetListOfVentilationAggregates();

            Assert.AreEqual("1234", ventilationAggregates[0].OrderNumber);
            Assert.AreEqual("5678", ventilationAggregates[1].OrderNumber);
        }

        [TestMethod]
        public void CustomerCanGetListOfBuildings()
        {
            c1.AddBuilding(b1);
            c1.AddBuilding(b2);

            buildingList = c1.GetListOfBuildings();
            Assert.AreEqual("Scandic", buildingList[0].Name);
            Assert.AreEqual("Arla", buildingList[1].Name);
        }

        [TestMethod]
        public void FilterCanBeRetrievedFromAggregate()
        {
            ag1.AddFilter(f1);
            filters = ag1.GetListOfFilters();
            Assert.AreEqual("type4", filters[0].Type);

            ag1.AddFilter(f2);
            filters = ag1.GetListOfFilters();
            Assert.AreEqual("filtClass2", filters[1].Filterclass);
        }


        [TestMethod]
        public void EmptyTest()
        {
            //Assert.AreEqual();
        }


        // PERSISTANCE //
 


        //public void EveryOrderNumberIsUnique()
        //{
        //    bool resultat = ct.Addag()

        //    agRepo.Load();

        //    bool resultat;
        //    int counter = 0;

        //    for (int i = 0; i < navne.Count; i++)
        //    {
        //        string temp = navne[i];
        //        for (int j = 0; j < navne.Count; j++)
        //        {
        //            if (temp == navne[j])
        //                counter++;
        //        }
        //        counter--;
        //    }
        //    if (counter > 0)
        //        resultat = false;
        //    else
        //        resultat = true;

        //    Assert.AreEqual(2, agRepo.Count());
        //}

    }
}
