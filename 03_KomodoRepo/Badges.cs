using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoRepo
{
    public class Badges
    {
        public int BadgeId { get; set; }
        public List<string> DoorNames { get; set; } = new List<string>();
        public Badges() { }
        public Badges(int badgeId, List<string> doorNames)
        {
            BadgeId = badgeId;
            DoorNames = doorNames;
        }
    }
    //public class Doors
    //{
    //    public string DoorName { get; set; }
    //    public Doors(string doorName)
    //    {
    //        DoorName = doorName;
    //    }
    //}
}
