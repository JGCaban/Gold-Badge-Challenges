using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    class ProgramUI
    {
        BadgeRepository _badgeRepo = new BadgeRepository();
        Dictionary<int, List<string>> dictOfBadges = new Dictionary<int, List<string>>();
        List<string> listOfDoors = new List<string>();
        public void Run()
        {
            AddBadge();
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Welcome to Komodo Security."+ 
                    "Select a menu option: " +
                    "\n1. Add another Badge" +
                    "\n2. Add/Edit doors on an existing badge" +
                    "\n3. Delete all doors on an existing badge" +
                    "\n4. Show all badges their assigned doors" +
                    "\n0. Exit");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        AddBadge();
                        break;
                    case 2:
                        AddDoorName();
                        break;
                    case 3:
                        DeleteBadgeDoors();
                        break;
                    case 4:
                        ShowAllBadges();
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }
        }
        private void AddBadge()
        {
            Console.Clear();
            Console.WriteLine("Enter your badge ID number: (1-3)");
            int BadgeID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter up to 3 door names assign to that ID: (ex. a1, a4, a5, b1, b2, d4)");
            var DoorName = Console.ReadLine();
            listOfDoors.Add(DoorName);
            dictOfBadges.Add(BadgeID, listOfDoors);
            Console.WriteLine();
        }
        private void AddDoorName()
        {
            Console.Clear();
            Console.WriteLine("");
        }
        private void DeleteBadgeDoors()
        {

        }
        private void ShowAllBadges()
        {
            Console.Clear();
            foreach (KeyValuePair<int, List<string>> BadgeID in dictOfBadges)
            {
                Console.WriteLine("");
            }
        }
    }
}
