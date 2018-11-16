using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> DoorName { get; set; }

        public Badge(int badgeid, List<string> doorname)
        {
            BadgeID = badgeid;
            DoorName = doorname;
        }
        public Badge()
        {

        }
    }
}
