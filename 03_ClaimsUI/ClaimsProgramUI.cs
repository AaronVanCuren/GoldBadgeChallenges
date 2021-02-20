using _01_Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ClaimsUI
{
    public class ClaimsProgramUI
    {
        private readonly ClaimsRepo _claims = new ClaimsRepo();
        public void Run()
        {
            SeedClaimList();
            RunMenu();
            Console.ReadKey();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Enter the number of the option you'd like to select:\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter new claim\n" +
                    "4. Remove Claim\n" +
                    "5. Update streaming content\n" +
                    "0. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        NextClaim();
                        break;
                    case "3":
                        CreateNewClaim();
                        break;
                    case "0":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 3\n" +
                            "or enter 0 to exit.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void SeeAllClaims()
        {
            Console.Clear();
            Queue<Claim> listOfClaims = _claims.GetClaims();
            Console.WriteLine($"ClaimID" +
                $"Type" +
                $"Description" +
                $"Amount" +
                $"Date of Incident" +
                $"Date of Claim" +
                $"Valid\n");
            foreach (Claim claims in listOfClaims)
            {
                DisplayClaim(claims);
            }
            Console.ReadKey();
        }
        private void DisplayClaim(Claim claims)
        {
            Console.WriteLine($"{claims.ClaimID}" +
                $"{claims.ClaimType}" +
                $"{claims.Description}" +
                $"{claims.ClaimAmount}" +
                $"{claims.DateOfIncident}" +
                $"{claims.DateOfClaim}" +
                $"{claims.IsValid}\n");
        }

        private void NextClaim()
        {
            Console.Clear();
            Queue<Claim> listOfClaims = _claims.GetClaims();
            foreach (Claim claims in listOfClaims)
            {
                Console.WriteLine(claims);
            }
        }
        private void CreateNewClaim()
        {
            Console.Clear();
        }
        private void SeedClaimList()
        {
            Claim car = new Claim(1, ClaimCatagory.car, "Car accident on 465", 400.00, new DateTime(18/25/4), new DateTime(18/27/4));
            Claim home = new Claim(2, ClaimCatagory.home, "House fire in kitchen", 4000.00, new DateTime(18/11/4), new DateTime(18/12/4));
            Claim theft = new Claim(3, ClaimCatagory.theft, "Stolen pancakes", 4.00, new DateTime(18/27/4), new DateTime(18/1/6));
            _claims.AddClaim(car);
            _claims.AddClaim(home);
            _claims.AddClaim(theft);
        }
    }
}
