using _02_KodomoClaimsRepo;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02_KodomoClaims
{
    class ClaimsUI
    {
        private ClaimsRepo _claimsRepo = new ClaimsRepo();

        public void Run()
        {
            SeedClaims();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Choose a menu item:\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit");

                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        SeeAllClaims();
                        break;
                    case 2:
                        HandleNextClaim();
                        break;
                    case 3:
                        AddNewClaim();
                        break;
                    case 4:
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        Console.Clear();
                        break;
                }

            }
        }
        private void SeeAllClaims()
        {
            Console.Clear();
            Queue<Claims> claimsQu = _claimsRepo.SeeClaimQu();
            Console.WriteLine("ClaimID" + "  " + "Type" + "      " + "Description" + "               " + "Amount" + "         " + "DateOfAccident" + "     " + "DateOfClaim" + "     " + "IsValid");
            foreach (Claims claims in claimsQu)
            {
                Console.WriteLine($"{claims.ClaimId,-9}" +
                    $"{claims.ClaimType,-9} " +
                    $"{claims.Description,-25} " +
                    $"{claims.ClaimAmount,-15:C2}" +
                    $"{claims.DateOfIncident.ToString("MM/dd/yyyy"),-19}" +
                    $"{claims.DateOfClaim.ToString("MM/dd/yyyy"),-16}" +
                    $"{claims.IsValid}\n");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            Console.Clear();
        }
        private void HandleNextClaim()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Claims firstIn = _claimsRepo.NextClaim();
                Console.WriteLine("Here are the details for the next claim to be handled\n\n" +
                    $"Claim ID: {firstIn.ClaimId}\n" +
                    $"Type: {firstIn.ClaimType}\n" +
                    $"Description: {firstIn.Description}\n" +
                    $"Amount: {firstIn.ClaimAmount:C2}\n" +
                    $"DateOfAccident: {firstIn.DateOfIncident.ToString("MM/dd/yyyy")}\n" +
                    $"DateOfClaim: {firstIn.DateOfClaim.ToString("MM/dd/yyyy")}\n" +
                    $"IsValid: {firstIn.IsValid}\n\n" +
                    $"Do you want to deal with this claim now? (y/n)");
                string input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    _claimsRepo.RemoveClaimFromQu();
                }
                else if (input == "n")
                {
                    keepRunning = false;
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Please try again");
                    Thread.Sleep(750);
                }
            }

        }
        private void AddNewClaim()
        {
            Claims newClaim = new Claims();
            Console.WriteLine("Enter the claim ID:");
            int i1 = int.Parse(Console.ReadLine());
            newClaim.ClaimId = i1;

            Console.WriteLine("Enter the claim type:");
            string i2 = Console.ReadLine();
            newClaim.ClaimType = i2;

            Console.WriteLine("Enter a claim description:");
            string i3 = Console.ReadLine();
            newClaim.Description = i3;

            Console.WriteLine("Amount of damage:");
            double i4 = double.Parse(Console.ReadLine());
            newClaim.ClaimAmount = i4;

            Console.WriteLine("Date Of Accident:  (mm/dd/yyyy)");
            DateTime i5 = DateTime.Parse(Console.ReadLine());
            newClaim.DateOfIncident = i5;

            Console.WriteLine("Date Of Claim:  (mm/dd/yyyy)");
            DateTime i6 = DateTime.Parse(Console.ReadLine());
            newClaim.DateOfClaim = i6;

            DateTime testOne = new DateTime(2018, 10, 01);
            DateTime testTwo = new DateTime(2018, 10, 31);
            TimeSpan test = testTwo - testOne;

            TimeSpan oneMonth = i6 - i5;
            if(oneMonth <= test)
            {
                newClaim.IsValid = true;
                Console.WriteLine("This claim is valid");
            }
            else
            {
                newClaim.IsValid = false;
                Console.WriteLine("This claim is not valid");
            }

            _claimsRepo.AddClaimsToQu(newClaim);
            Console.ReadLine();
            Console.Clear();
        }
        private void SeedClaims()
        {
            DateTime carDateStart = new DateTime(2018, 4, 25);
            DateTime carDateEnd = new DateTime(2018, 4, 27);
            DateTime homeDateStart = new DateTime(2018, 4, 11);
            DateTime homeDateEnd = new DateTime(2018, 4, 12);
            DateTime theftDateStart = new DateTime(2018, 4, 27);
            DateTime theftDateEnd = new DateTime(2018, 6, 01);

            Claims carClaim = new Claims(1, "Car", "Car accident on 465", 400.00, carDateStart, carDateEnd, true);
            Claims homeClaim = new Claims(2, "Home", "House fire in Kitchen", 4000.00, homeDateStart, homeDateEnd, true);
            Claims theftClaim = new Claims(3, "Theft", "Stolen pancakes", 4.00, theftDateStart, theftDateEnd, false);

            _claimsRepo.AddClaimsToQu(carClaim);
            _claimsRepo.AddClaimsToQu(homeClaim);
            _claimsRepo.AddClaimsToQu(theftClaim);
        }

    }
}
