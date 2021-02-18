using _01_Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ClaimsUI
{
    class ProgramUI
    {
        private readonly ClaimsRepo _claims = new ClaimsRepo();

        public void Run()
        {
            SeedClaimList();
            RunMenu();
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
                    "6. Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        //-- Show all content
                        SeeAllClaims();
                        break;
                    case "2":
                        //-- Find content by title
                        NextClaim();
                        break;
                    case "3":
                        //-- Add new content
                        CreateNewClaim();
                        break;
                    case "4":
                        //-- Remove content
                        RemoveClaim();
                        break;
                    case "0":
                        //-- Exit
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 4\n" +
                            "or enter 6 to exit.");
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

            foreach(Claim claims in listOfClaims)
            {
                Console.WriteLine(claims);
            }
        }

        private void CreateNewClaim();

        private void RemoveClaim();

        private void SeedClaimList()
        {
            Claim car = new Claim(1, ClaimCatagory.car, "Car accident on 465", 400.00, DateTime.Parse(string s), DateTime.Parse(string s), true);
            Claim home = new Claim(2, ClaimCatagory.home, "House fire in kitchen", 4000.00, DateTime.Parse(string s), DateTime.Parse(string s), true);
            Claim theft = new Claim(3, ClaimCatagory.theft, "Stolen pancakes", 4.00, DateTime.Parse(string s), DateTime.Parse(string s), true);

            _claims.AddClaim(car);
            _claims.AddClaim(home);
            _claims.AddClaim(theft);
        }
    }
}
