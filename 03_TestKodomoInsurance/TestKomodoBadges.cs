using _03_KomodoRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _03_TestKodomoInsurance
{
    [TestClass]
    public class TestKomodoBadges
    {
        private InsuranceRepo _insuranceRepo = new InsuranceRepo();

        [TestMethod]
        public void TestAddBadgesToDict()
        {
            Badges newBadge = new Badges();
            newBadge.BadgeId = 1;

            _insuranceRepo.AddBadgestoDict(newBadge);
            Assert.IsNotNull(newBadge);
        }
        [TestMethod]
        public void TestAddDoorsToBadge()
        {
            Badges newBadge = new Badges();
            newBadge.BadgeId = 20;
            _insuranceRepo.AddBadgestoDict(newBadge);
            Badges testBadge = _insuranceRepo.GetBadgeById(20);

            string newDoor = "A5";

            _insuranceRepo.AddDoorsToBadge(testBadge.BadgeId, newDoor);

            Assert.AreEqual(1, newBadge.DoorNames.Count);
        }
        [TestMethod]
        public void TestAddDoorsUsingBadgeClass()
        {
            List<string> doors = new List<string>() { "A1", "A2", "A3" };
            string anotherDoor = "A4";
            var testBadge = new Badges(5, doors);

            _insuranceRepo.AddDoorsUsingBadgeClass(testBadge, anotherDoor);

            Assert.AreEqual(4, doors.Count);
        }
        [TestMethod]
        public void TestGetEntireDict()
        {
            Dictionary<int, Badges> testDict = _insuranceRepo.GetEntireDict();

            Assert.IsNotNull(testDict);
        }
        [TestMethod]
        public void TestUpdateDict()
        {
            List<string> doors = new List<string>();
            string firstDoor = "A1";
            Badges testBadge = new Badges(5, doors);

            _insuranceRepo.AddDoorsUsingBadgeClass(testBadge, firstDoor);
            _insuranceRepo.AddBadgestoDict(testBadge);
            testBadge.DoorNames.Add("A2");

            bool updatedBadge = _insuranceRepo.UpdateDict(testBadge.BadgeId, testBadge);

            Assert.IsTrue(updatedBadge);
        }
        [TestMethod]
        public void TestDeleteDoorFromBadge()
        {
            List<string> doors = new List<string>();
            string firstDoor = "A1";
            Badges testBadge = new Badges(5, doors);

            _insuranceRepo.AddDoorsUsingBadgeClass(testBadge, firstDoor);
            _insuranceRepo.AddBadgestoDict(testBadge);

            _insuranceRepo.DelDoorFromBadge(testBadge.BadgeId, firstDoor);

            Assert.AreEqual(testBadge.DoorNames.Count, 0);
        }
        [TestMethod]
        public void TestGetBadgebyId()
        {
            List<string> doors = new List<string>() { "A1" };
            Badges newBadge = new Badges(5, doors);
            _insuranceRepo.AddBadgestoDict(newBadge);
            Badges testBadge = _insuranceRepo.GetBadgeById(newBadge.BadgeId);

            Assert.AreEqual(newBadge.BadgeId, testBadge.BadgeId);
        }
    }
}
