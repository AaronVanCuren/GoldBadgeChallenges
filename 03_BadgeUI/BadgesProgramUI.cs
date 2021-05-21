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
            Seed();
            RunMenu();
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
                    "3. List all badges\n" +
                    "0. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
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
                            "or presss 0 to exit");
                        Console.ReadKey();
                        break;
                }
            }

        }

        private void ShowAllBadges()
        {
            Console.Clear();
            Dictionary<string, List<string>> listOfBadges = _access.GetAllBadges();

            foreach (KeyValuePair<string, List<string>> badge in listOfBadges)
            {
                Console.Write($" Badge #: {badge.Key} \n" +
                " Door Access: ");
                foreach (string door in badge.Value)
                {
                    Console.Write($"{door}, ");
                }
                Console.WriteLine("");
                Console.WriteLine("----------------");
            }

            Console.WriteLine("Press any key to continue... ");
            Console.ReadKey();
        }

        private void AddBadge()
        {
            Console.Clear();
            Console.WriteLine("What is the number on the badge:");
            string badge = Console.ReadLine();

            Console.WriteLine("List a door that this badge needs access to");
            List<string> door = new List<string> { Console.ReadLine() };

            bool wasAdded = true;
            while (wasAdded)
            {
                Console.WriteLine("Any other doors (Y/N)?");
                string response = Console.ReadLine().ToLower();
                switch (response)
                {
                    case "y":
                        {
                            Console.WriteLine("List a door that it needs access to: ");
                            door.Add(Console.ReadLine());
                            break;
                        }
                    case "n":
                        {
                            wasAdded = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please type either Y or N.");
                            break;
                        }
                }
            }
            _access.AddBadge(badge, door);
        }

        private void UpdateBadge()
        {
            Console.Clear();
            Console.WriteLine("What is the badge number to update?");
            string badge = Console.ReadLine();
            Console.WriteLine("What would you like to do? \n" +
                "1. Remove a Door \n" +
                "2. Add a Door \n");
            string door = Console.ReadLine();
            switch (door)
            {
                case "1":
                    {
                        Console.WriteLine("Which door would you like to remove?");
                        string removeDoor = Console.ReadLine();
                        _access.RemoveDoor(badge, removeDoor);
                        BadgeAccess(badge);
                        Console.WriteLine("Press any key to continue....");
                        Console.ReadKey();
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("Which door would you like to add?");
                        string addDoor = Console.ReadLine();
                        _access.AddDoorAccess(badge, addDoor);
                        BadgeAccess(badge);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Please select either 1 or 2.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
            }
        }

        private void BadgeAccess(string badgeAccess)
        {
            Console.WriteLine($"{badgeAccess} has access to: ");
            Badges badge = _access.GetBadgeByID(badgeAccess);
            foreach (string door in badge.Doors)
            {
                Console.Write($"{door} \n");
            }
        }

        public void Seed()
        {
            Badges levelone = new Badges("1000", new List<string>() { "A1", "A2", "A3", "A4" });
            Badges leveltwo = new Badges("2000", new List<string>() { "A1", "A2", "A3", "A4", "B1", "B2", "B3", "B4" });
            Badges levelthree = new Badges("3000", new List<string>() { "A1", "A2", "A3", "A4", "B1", "B2", "B3", "B4", "C1", "C2", "C3", "C4" });
            Badges levelfour = new Badges("4000", new List<string>() { "A1", "A2", "A3", "A4", "B1", "B2", "B3", "B4", "C1", "C2", "C3", "C4", "D1", "D2", "D3", "D4" });

            _access.AddBadge(levelone.BadgeID, levelone.Doors);
            _access.AddBadge(leveltwo.BadgeID, leveltwo.Doors);
            _access.AddBadge(levelthree.BadgeID, levelthree.Doors);
            _access.AddBadge(levelfour.BadgeID, levelfour.Doors);
        }
    }
}
