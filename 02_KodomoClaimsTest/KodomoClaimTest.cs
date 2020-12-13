using _02_KodomoClaimsRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _02_KodomoClaimsTest
{
    [TestClass]
    public class KodomoClaimTest
    {
        [TestMethod]
        public void TestAddClaimsToQu()
        {
            //Arrange
            ClaimsRepo newRepo = new ClaimsRepo();
            Claims newClaim = new Claims();
            newClaim.ClaimId = 1;
            //Act
            newRepo.AddClaimsToQu(newClaim);
            //Assert
            Assert.IsNotNull(newRepo);
        }
        [TestMethod]
        public void TestSeeQueList()
        {
            //Arrange
            ClaimsRepo newRepo = new ClaimsRepo();
            Claims newClaim = new Claims();
            Queue<Claims> claimQu = new Queue<Claims>();

            //Act
            newRepo.AddClaimsToQu(newClaim);
            newRepo.SeeClaimQu();
            //Assert
            Assert.IsNotNull(claimQu);
        }
        [TestMethod]
        public void TestRemovefromQu()
        {
            //Arrange
            ClaimsRepo newRepo = new ClaimsRepo();
            Claims newClaim = new Claims();
            Queue<Claims> claimQu = new Queue<Claims>();
            //Act
            newRepo.AddClaimsToQu(newClaim);
            newRepo.RemoveClaimFromQu();
            //Assert
            Assert.AreEqual(0, claimQu.Count);
        }
    }
}
