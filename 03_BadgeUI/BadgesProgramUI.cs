using _01_Badges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgeUI
{
    public class BadgesProgramUI
    {
        private readonly BadgesRepo _access = new BadgesRepo();
        public void Run()
        {
            SeedDoors();
            RunMenu();
            Console.ReadKey();
        }
        public void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Hello Security Admin, What would you like to do?\n\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges");
                string userInput = Console.ReadLine();
                switch(userInput)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        UpdateBadge();
                        break;
                    case "3":
                        ShowAllBadges();
                        break;
                    case "0":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 3\n" +
                            "or presss 4 to exit");
                        Console.ReadKey();
                        break;
                }
            }

        }
            private void AddBadge()
            {
                Console.Clear();
            }
            private void UpdateBadge()
            {
                Console.Clear();
            }
            private void ShowAllBadges()
            {
                Console.Clear();
                Dictionary<int, List<string>> listOfBadges = _access.GetAllBadges();                
            }
        public void SeedDoors()
        {
            Badges levelone = new Badges(1000, new List<string>() { "A1", "A2", "A3", "A4" });
            Badges leveltwo = new Badges(2000, new List<string>() { "A1", "A2", "A3", "A4", "B1", "B2", "B3", "B4" });
            Badges levelthree = new Badges(3000, new List<string>() { "A1", "A2", "A3", "A4", "B1", "B2", "B3", "B4", "C1", "C2", "C3", "C4" });
            Badges levelfour = new Badges(4000, new List<string>() { "A1", "A2", "A3", "A4", "B1", "B2", "B3", "B4", "C1", "C2", "C3", "C4", "D1", "D2", "D3", "D4" });
        }
    }
}
