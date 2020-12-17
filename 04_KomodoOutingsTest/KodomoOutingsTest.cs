using _04_KomodoOutingsRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _04_KomodoOutingsTest
{
    [TestClass]
    public class KodomoOutingsTest
    {
        OutingRepository _testRepo = new OutingRepository();
        [TestMethod]
        public void TestAddingOutingToList()
        {
            Outings newOuting = new Outings();
            _testRepo.AddOutingToList(newOuting);
            Assert.IsNotNull(newOuting);
        }
        [TestMethod]
        public void TestSeeList()
        {
            Outings newOuting = new Outings();
            _testRepo.AddOutingToList(newOuting);
            List<Outings> newList = _testRepo.SeeOutingsList();
            Assert.AreEqual(newList.Count, 1);
        }
        [TestMethod]
        public void TestTotalCostPerType()
        {
            Outings newOuting = new Outings();
            newOuting.EventTypes =(enumEventTypes)1;
            newOuting.CostPerPerson = 100.00;
            newOuting.NumberOfAttendees = 100;
            _testRepo.AddOutingToList(newOuting);
            double totalCostPerType = _testRepo.TestCostPerType(enumEventTypes.Golf);

            Assert.AreEqual(10000, totalCostPerType);
        }
        [TestMethod]
        public void TestTotalCostEvents()
        {
            DateTime test = new DateTime(2020, 4, 16);
            Outings newOuting = new Outings((enumEventTypes)1, 100, test, 300);
            Outings newOuting2 = new Outings((enumEventTypes)2, 100, test, 300);
            _testRepo.AddOutingToList(newOuting);
            _testRepo.AddOutingToList(newOuting2);
            double totalCost = _testRepo.TotalCostEvents();
            Assert.AreEqual(60000, totalCost);
        }
    }
}
