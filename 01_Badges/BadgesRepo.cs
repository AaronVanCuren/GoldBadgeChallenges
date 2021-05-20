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

        public bool AddBadge(string badge, List<string> doors)
        {
            int count = _access.Count();
            _access.Add(badge, doors);
            bool wasAdded = _access.Count() > count;
            return wasAdded;
        }

        public bool AddDoorAccess(string badgeID, string doorID)
        {
            int count = _access.Count();
            _access[badgeID].Add(doorID);
            bool wasAdded = _access.Count() < count;
            return wasAdded;
        }

        public bool RemoveDoor(string badgeId, string door)
        {
            int count = _access.Count();
            _access[badgeId].Remove(door);
            bool wasRemoved = _access.Count() < count;
            return wasRemoved;
        }

        public Dictionary<string, List<string>> GetAllBadges()
        {
            return _access;
        }

        public Badges GetBadgeByID(string badgeId)
        {
            Badges badge = new Badges(badgeId, _access[badgeId]);
            if (badge == null)
            {
                throw new Exception("No badge found with that ID");
            }
            return badge;
        }
    }
}