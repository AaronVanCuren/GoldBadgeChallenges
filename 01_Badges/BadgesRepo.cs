using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Badges
{
    public class BadgesRepo
    {
        private readonly Dictionary<int, List<string>> _access = new Dictionary<int, List<string>>();
        public void AddBadge(Badges badges)
        {
            _access.Add(badges.BadgeID, badges.Doors);
        }
        public Dictionary<int, List<string>> GetAllBadges()
        {
            return _access;
        }
    }
}
