using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Badges
{
    public class Badges
    {
        public string BadgeID { get; set; }

        public List<string> Doors { get; set; }

        public Badges() { }

        public Badges(string badgeId, List<string> doors)
        {
            BadgeID = badgeId;
            Doors = doors;
        }
    }
}

