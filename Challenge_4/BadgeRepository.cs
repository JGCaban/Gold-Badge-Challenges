using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    public class BadgeRepository
    {
        Dictionary<int, List<string>> _dictOfBadges = new Dictionary<int, List<string>>();
        List<string> _listOfDoors = new List<string>();

        public void AddBadge(Badge content)
        {
            _dictOfBadges.Add(content.BadgeID, content.DoorName);
        }
        public void AddDoorName(string door)
        {
            _listOfDoors.Add(door);
        }
        public void RemoveBadge(int BadgeID)
        {
            _dictOfBadges.Remove(BadgeID);
        }
        public Dictionary<int, List<string>> GetBadge()
        {
            return _dictOfBadges;
        }
        public List<string> GetDoorList()
        {
            return _listOfDoors;
        }
    }
}
