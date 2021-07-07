using _01_Claims;
using System;
using System.Collections.Generic;

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
         Console.WriteLine("{0,-10} {1,-10} {2,-30} {3,-10} {4,-20} {5,-20} {6,-10}",
             "ClaimID",
             "Type",
             "Description",
             "Amount",
             "Date of Incident",
             "Date of Claim",
             "Valid\n");

         foreach (Claim claims in listOfClaims)
         {
            DisplayClaim(claims);
         }

         Console.WriteLine("Press any key to return to the main menu: ");
         Console.ReadKey();
      }
      private void DisplayClaim(Claim claims)
      {
         Console.WriteLine("{0,-10} {1,-10} {2,-30} {3,-10} {4,-20} {5,-20} {6,-10}",
             $"{claims.ClaimID}",
             $"{claims.ClaimType}",
             $"{claims.Description}",
             $"{claims.ClaimAmount}",
             $"{claims.DateOfIncident}",
             $"{claims.DateOfClaim}",
             $"{claims.IsValid}\n");
      }
      private void NextClaim()
      {
         Console.Clear();
         var nextClaim = _claims.PeekClaim();

         Console.WriteLine("Here are the details for the next claim to be handled: ");
         Console.WriteLine($"Claim ID: {nextClaim.ClaimID}");
         Console.WriteLine($"Type: { nextClaim.ClaimType}");
         Console.WriteLine($"Description: {nextClaim.Description}");
         Console.WriteLine($"Amount: ${nextClaim.ClaimAmount}");
         Console.WriteLine($"Date of Accident: {nextClaim.DateOfIncident.ToString("MM/dd/yyyy")}");
         Console.WriteLine($"Date of Claim: {nextClaim.DateOfClaim.ToString("MM/dd/yyyy")}");
         Console.WriteLine($"This Claim is Valid: {nextClaim.IsValid}");
         Console.WriteLine("--------------------");

         Console.WriteLine("Do you want to deal with this claim now (Y/N)?");
         string userInput = Console.ReadLine().ToLower();
         switch (userInput)
         {

            case "y":
               {
                  _claims.Dequeue();
                  Console.WriteLine("This claim has been deleted from the Directory.");
                  break;
               }
            case "n":
               {
                  Console.WriteLine("This claim has been returned to the Directory.");
                  break;
               }
            default:
               {
                  Console.WriteLine("You have pressed an invalid key. Please enter either Y or N.");
                  break;
               }
         }
         Console.WriteLine("Press any key to return to the main menu: ");
         Console.ReadKey();
      }

      private void CreateNewClaim()
      {
         Console.Clear();
         Claim newClaim = new Claim();

         Console.WriteLine("Enter the Claim ID: ");
         int claimID = int.Parse(Console.ReadLine());
         newClaim.ClaimID = claimID;

         Console.WriteLine("Enter the Claim Type: \n" +
             "1. Car \n" +
             "2. Home \n" +
             "3. Theft\n");
         int claimType = int.Parse(Console.ReadLine());
         newClaim.ClaimType = (ClaimType)claimType;

         Console.WriteLine("Enter a Claim Description: ");
         newClaim.Description = Console.ReadLine();

         Console.WriteLine("Amount of Damage: ");
         string damageAmount = Console.ReadLine();
         newClaim.ClaimAmount = double.Parse(damageAmount);

         Console.WriteLine("Date of Accident (yyyy, mm, dd): ");
         string accidentDate = Console.ReadLine();
         newClaim.DateOfIncident = DateTime.Parse(accidentDate);

         Console.WriteLine("Date of Claim (yyyy, mm, dd): ");
         string claimDate = Console.ReadLine();
         newClaim.DateOfClaim = DateTime.Parse(claimDate);

         _claims.AddClaim(newClaim);
         Console.WriteLine("Press any key to return to the main menu: ");
         Console.ReadKey();
      }

      private void SeedClaimList()
      {
         Claim car = new Claim(1, ClaimType.Car, "Car accident on 465", 400.00, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27));
         Claim home = new Claim(2, ClaimType.Home, "House fire in kitchen", 4000.00, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12));
         Claim theft = new Claim(3, ClaimType.Theft, "Stolen pancakes", 4.00, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01));
         _claims.AddClaim(car);
         _claims.AddClaim(home);
         _claims.AddClaim(theft);
      }
   }
}
