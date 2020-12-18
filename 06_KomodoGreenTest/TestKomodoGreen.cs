using _06_KomodoGreenRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _06_KomodoGreenTest
{
    [TestClass]
    public class TestKomodoGreen
    {
        KomodoCarRepo testRepo = new KomodoCarRepo();
        [TestMethod]
        public void TestAddCarToList()
        {
            Cars car = new Cars();
            car.Vin = 1;
            testRepo.AddCartoList(car);
            Cars testCar = testRepo.GetCarByVin(car.Vin);
            Assert.AreEqual(1, testCar.Vin);
        }
        [TestMethod]
        public void TestSeeCarList()
        {
            Cars car = new Cars();
            List<Cars> testList = new List<Cars>();
            testRepo.AddCartoList(car);
            testList = testRepo.SeeCarList();
            Assert.IsNotNull(testList);
        }
        [TestMethod]
        public void TestUpdateCarOnList()
        {
            Cars car = new Cars(1, TypeOfCar.Electric, "New Model", "New Brand", 500, 50000, 5000);
            testRepo.AddCartoList(car);
            bool ShouldBeTrue = testRepo.UpdateCarOnList(1, car);
            Assert.IsTrue(ShouldBeTrue);
        }
        [TestMethod]
        public void TestDeleteCarFromList()
        {
            Cars car = new Cars(1, TypeOfCar.Electric, "New Model", "New Brand", 500, 50000, 5000);
            Cars carTwo = new Cars(2, TypeOfCar.Electric, "New Model", "New Brand", 500, 50000, 5000);
            testRepo.AddCartoList(car);
            testRepo.AddCartoList(carTwo);
            testRepo.DeleteCarFromList(1);
            List<Cars> testList = testRepo.SeeCarList();
            Assert.AreEqual(1, testList.Count);
        }
        [TestMethod]
        public void TestGetCarByVin()
        {
            Cars car = new Cars();
            car.Vin = 1;
            testRepo.AddCartoList(car);
            Cars testCar = testRepo.GetCarByVin(car.Vin);
            Assert.AreEqual(1, testCar.Vin);
        }
    }
}
