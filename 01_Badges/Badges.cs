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
        Badges levelone = new Badges(1000, new List<string>() { "A1", "A2", "A3", "A4" });
        Badges leveltwo = new Badges(2000, new List<string>() { "A1", "A2", "A3", "A4", "B1", "B2", "B3", "B4" });
        Badges levelthree = new Badges(3000, new List<string>() { "A1", "A2", "A3", "A4", "B1", "B2", "B3", "B4", "C1", "C2", "C3", "C4" });
        Badges levelfour = new Badges(4000, new List<string>() { "A1", "A2", "A3", "A4", "B1", "B2", "B3", "B4", "C1", "C2", "C3", "C4", "D1", "D2", "D3", "D4" });
    }
}

