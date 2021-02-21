using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Badges
{
    public class BadgesRepo
    {
        private readonly Dictionary<string, List<string>> _access = new Dictionary<string, List<string>>();
        public bool AddBadge(Badges badges)
        {
            int count = _access.Count;
            _access.Add(badges.BadgeID, badges.Doors);
            bool badgeAdded = _access.Count > count;
            return badgeAdded;
        }
        public Dictionary<string, List<string>> GetAllBadges()
        {
            return _access;
        }
        public string GetBadgeByID(string badgeId)
        {
            Dictionary<string, List<string>>.KeyCollection keys = _access.Keys;
            foreach(string badge in keys)
            {                
                if(badgeId == badge)
                {
                    return badge;
                }
            }
            throw new Exception("No badge found with that ID");
        }
        public List<string> GetDoorsByID(string badgeId)
        {
            foreach(KeyValuePair<string, List<string>> badge in _access)
            {
                if($"{badgeId}" == $"{badge}")
                {
                    foreach(string value in badge.Value)
                    {
                        Console.WriteLine($"{value}");
                    }
                }
            }
            throw new Exception("No badge found with that ID");
        }
        public bool UpdateBadge(string badgeId)
        {
            Console.WriteLine("What is the badge number to update:");
            badgeId = Console.ReadLine();
            GetBadgeByID(badgeId);
            Console.WriteLine($"{badgeId} has access to the following doors:");
            GetDoorsByID(badgeId);
            Console.WriteLine("What would you like to do?\n" +
                "   1. Remove a door\n" +
                "   2. Add a Door\n" +
                "   Please enter a number for the option you would like.");
            int userInput;
            userInput = Console.Read();
            if(userInput == 1)
            {
                int count = GetDoorsByID(badgeId).Count();
                RemoveDoor(badgeId);
                bool doorRemoved = GetDoorsByID(badgeId).Count() < count;
                Console.WriteLine("Door removed");
                Console.WriteLine($"{badgeId} has access to the following doors:");
                GetDoorsByID(badgeId);
                return doorRemoved;
            }
            else if(userInput == 2)
            {
                int count = GetDoorsByID(badgeId).Count();
                AddDoor(badgeId);
                bool doorAdded = GetDoorsByID(badgeId).Count() > count;
                Console.WriteLine("Door added");
                Console.WriteLine($"{badgeId} has access to the following doors:");
                GetDoorsByID(badgeId);
                return doorAdded;
            }
            else
            {
                Console.WriteLine("Invalid option");
                Console.ReadKey();
                return false;
            }
        }
        public bool AddDoor(string badgeId)
        {
            int count = GetDoorsByID(badgeId).Count();
            Console.WriteLine("List a door that this badge needs access to");
            string door = Console.ReadLine();
            _access[badgeId].Add(door);
            bool doorAdded = GetDoorsByID(badgeId).Count() > count;
            return doorAdded;
        }
        public bool RemoveDoor(string badgeId)
        {
            int count = GetDoorsByID(badgeId).Count();
            Console.WriteLine("Which door would you like to remove?");
            string door = Console.ReadLine();
            _access[badgeId].Remove(door);
            bool doorRemoved = GetDoorsByID(badgeId).Count() < count;
            return doorRemoved;
        }
    }
}
