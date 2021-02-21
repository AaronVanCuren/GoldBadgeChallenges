using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Badges
{
    public class Badges
    {
        public int BadgeID { get; set; }
        public List<string> Doors { get; set; }
        public Badges() { }
        public Badges(int badgeId, List<string> doors)
        {
            BadgeID = badgeId;
            Doors = doors;
        }
    }
}

