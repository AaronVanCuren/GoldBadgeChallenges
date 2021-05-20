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
            Console.WriteLine("{0,-10}{1,-10}{2,-30}{3,-10}{4,-20}{5,-20}{6,-10}", 
                "ClaimID", "Type", "Description", "Amount", "Date of Incident", "Date of Claim", "Valid\n");
            foreach (Claim claims in listOfClaims)
            {
                DisplayClaim(claims);
            }
            Console.ReadKey();
        }
        private void DisplayClaim(Claim claims)
        {
            Console.WriteLine("{0,-10}{1,-10}{2,-30}{3,-10}{4,-20}{5,-20}{6,-10}", 
                $"{claims.ClaimID}", $"{claims.ClaimType}", $"{claims.Description}", $"{claims.ClaimAmount}", 
                $"{claims.DateOfIncident}", $"{claims.DateOfClaim}", $"{claims.IsValid}\n");
        }
        private void NextClaim()
        {
            string answer;
            Console.Clear();
            Console.WriteLine("Do you want to deal with this claim now(y/n)?");
            _claims.PeekClaim();
            answer = Console.ReadLine();
            if(answer == "y")
            {
                Console.WriteLine("Claim is dequeuing...");
                _claims.Dequeue();
            }
            else if (answer == "n")
            {
                Console.WriteLine("Returning to menu");
                RunMenu();
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
        private void CreateNewClaim()
        {
            Console.Clear(); 
        }
        private void SeedClaimList()
        {
            Claim car = new Claim(1, ClaimCatagory.Car, "Car accident on 465", 400.00, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27));
            Claim home = new Claim(2, ClaimCatagory.Home, "House fire in kitchen", 4000.00, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12));
            Claim theft = new Claim(3, ClaimCatagory.Theft, "Stolen pancakes", 4.00, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01));
            _claims.AddClaim(car);
            _claims.AddClaim(home);
            _claims.AddClaim(theft);
        }
    }
}
