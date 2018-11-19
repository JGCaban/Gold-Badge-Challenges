using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    public class BadgeRepository
    {
        Dictionary<int, List<string>> dictOfBadges = new Dictionary<int, List<string>>();
        List<string> listOfDoors = new List<string>();

        public void AddBadge(Badge content)
        {
            dictOfBadges.Add(content.BadgeID, content.DoorName);
        }
        public void AddBadgeDoor(string door)
        {
            listOfDoors.Add(door);
        }
        public void RemoveBadge(int badge)
        {
            dictOfBadges.Remove(badge);
        }
        public void RemoveDoor(string doors)
        {
            listOfDoors.Remove(doors);
        }
        public Dictionary<int, List<string>> GetBadge()
        {
            return dictOfBadges;
        }
        public List<string> GetDoorList()
        {
            return listOfDoors;
        }
        public bool CheckAnswer(string input)
        {
            if (input == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
