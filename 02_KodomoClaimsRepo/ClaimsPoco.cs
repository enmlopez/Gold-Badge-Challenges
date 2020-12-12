using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KodomoClaimsRepo
{
    public class Claims
    {
        public int ClaimId { get; set; }
        public string ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public Claims() { }
        public Claims(int claimId, string claimType, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            ClaimId = claimId;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }
    }
    //public class Home : Car
    //{
    //    public Home(int claimId, string claimType, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
    //    {
    //        ClaimId = claimId;
    //        ClaimType = claimType;
    //        Description = description;
    //        ClaimAmount = claimAmount;
    //        DateOfIncident = dateOfIncident;
    //        DateOfClaim = dateOfClaim;
    //    }
    //}
    //public class Theft : Car
    //{
    //    public Theft(int claimId, string claimType, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
    //    {
    //        ClaimId = claimId;
    //        ClaimType = claimType;
    //        Description = description;
    //        ClaimAmount = claimAmount;
    //        DateOfIncident = dateOfIncident;
    //        DateOfClaim = dateOfClaim;
    //    }
    //}
}
