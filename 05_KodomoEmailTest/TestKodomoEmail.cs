using _05_KodomoEmailRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _05_KodomoEmailTest
{
    [TestClass]
    public class TestKodomoEmail
    {
        EmailRepo _emailRepo = new EmailRepo();
        [TestMethod]
        public void TestAddCustomersToList()
        {
            Customers newCustomer = new Customers();
            _emailRepo.AddCustomersToList(newCustomer);
            List<Customers> testList = _emailRepo.SeeCustomerList();
            Assert.AreEqual(1, testList.Count);
        }
        [TestMethod]
        public void TestSeeCustomerList()
        {
            Customers newCustomer = new Customers();
            _emailRepo.AddCustomersToList(newCustomer);
            List<Customers> testList = _emailRepo.SeeCustomerList();
            Assert.AreEqual(1, testList.Count);
        }
        [TestMethod]
        public void TestUpdateCustomerList()
        {
            Customers newCustomer = new Customers();
            newCustomer.FirstName = "Joshua";
            _emailRepo.AddCustomersToList(newCustomer);
            bool test = _emailRepo.UpdateCustomerList(newCustomer, newCustomer.FirstName);
            Assert.IsTrue(test);
        }
        [TestMethod]
        public void TestDeleteCustomerFromList()
        {
            Customers customerOne = new Customers();
            customerOne.FirstName = "Joshua";
            Customers customerTwo = new Customers();
            customerOne.FirstName = "Jose";
            _emailRepo.AddCustomersToList(customerOne);
            _emailRepo.AddCustomersToList(customerTwo);
            _emailRepo.DeleteCustomer(customerTwo.FirstName);
            List<Customers> testList = _emailRepo.SeeCustomerList();
            Assert.AreEqual(1, testList.Count);
        }
        [TestMethod]
        public void TestCustomerByName()
        {
            Customers customerOne = new Customers("Joshua", "Lobes", Types.Current, "testEmail");
            _emailRepo.AddCustomersToList(customerOne);
            _emailRepo.FindCustomerByName("Joshua");
            Assert.AreEqual("Joshua", customerOne.FirstName);
        }
    }
}
