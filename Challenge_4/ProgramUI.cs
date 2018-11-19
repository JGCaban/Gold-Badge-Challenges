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
        public void Run()
        {
            Badge one = new Badge(1, new List<string>() {"a1", "a5", "d4"});
            Badge two = new Badge(2, new List<string>() {"a1", "a4", "b1", "b2"});
            Badge three = new Badge(3, new List<string>() {"a4", "a5"});
            _badgeRepo.AddBadge(one);
            _badgeRepo.AddBadge(two);
            _badgeRepo.AddBadge(three);
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Welcome to Komodo Security."+ 
                    "\nSelect a menu option: \n" +
                    "\n1. Add another Badge" +
                    "\n2. Edit/Remove doors on an existing badge" +
                    "\n3. Show all badges and their assigned doors" +
                    "\n0. Exit");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        AddBadge();
                        break;
                    case 2:
                        EditBadgeDoors();
                        break;
                    case 3:
                        ShowAllBadges();
                        break;
                    case 0:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }
        }
        private void AddBadge()
        {
            Dictionary<int, List<string>> dictOfBadges = _badgeRepo.GetBadge();
            List<string> listOfDoors = _badgeRepo.GetDoorList();
            Console.Clear();
            Console.WriteLine("Enter your badge ID number: (ex. 1, 9, 13, 256)");
            int badgeID = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Do you want to add a door to this badge? (y/n)");
            var input = Console.ReadLine().ToLower();
            bool addingDoor = _badgeRepo.CheckAnswer(input);
            while (addingDoor)
            {
                Console.WriteLine();
                Console.WriteLine("Enter the letter(s) and number(s) for a single door: (ex. a1, bg15, zd192)");
                var doorName = Console.ReadLine();
                _badgeRepo.AddBadgeDoor(doorName);
                Console.WriteLine();
                Console.WriteLine("Do you want to add another door? (y/n)");
                var newinput = Console.ReadLine().ToLower();
                addingDoor = _badgeRepo.CheckAnswer(newinput);
            }
            Badge newBadge = new Badge(badgeID, listOfDoors);
            _badgeRepo.AddBadge(newBadge);
            Console.WriteLine();
        }
        private void EditBadgeDoors()
        {
            Dictionary<int, List<string>> dictOfBadges = _badgeRepo.GetBadge();
            List<string> listOfDoors = _badgeRepo.GetDoorList();
            Console.Clear();
            Console.WriteLine("Current badges: ");
            foreach (KeyValuePair<int, List<string>> badgeID in _badgeRepo.GetBadge())
            {
                Console.WriteLine($" {badgeID.Key}");
            }
            Console.WriteLine();
            Console.WriteLine("NOTE: All doors that were previously assigned to the badge will be REMOVED.");
            Console.WriteLine("Do you want to continue? (y/n)");
            var input = Console.ReadLine().ToLower();
            if (input != "y") { return; }
            Console.WriteLine();
            {
                Console.WriteLine("Enter the NUMBER for the badge to be edited: ");
                int badgeid = int.Parse(Console.ReadLine());
                foreach (KeyValuePair<int, List<string>> badgeID in _badgeRepo.GetBadge())
                {
                    if (badgeid == badgeID.Key)
                    {
                        Console.WriteLine();
                        Console.WriteLine("This Badge currently has no doors assigned. Do you want to add a door to this badge? (y/n)");
                        var dooranswer = Console.ReadLine().ToLower();
                        bool addingdoors = _badgeRepo.CheckAnswer(dooranswer);
                        while (addingdoors)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Enter the LETTER(s) and NUMBER(s) for a single door: (ex. a1, bg15, zd192)");
                            var doorname = Console.ReadLine();
                            _badgeRepo.AddBadgeDoor(doorname);
                            Console.WriteLine();
                            Console.WriteLine("Do you want to add another door? (y/n)");
                            var answer = Console.ReadLine().ToLower();
                            addingdoors = _badgeRepo.CheckAnswer(answer);
                        }
                    }
                    else { return; }
                }
                dictOfBadges[badgeid] = listOfDoors;
                Console.WriteLine();
            }
        }
        private void ShowAllBadges()
        {
            Console.Clear();
            foreach (KeyValuePair<int, List<string>> badgeID in _badgeRepo.GetBadge())
            {
                Console.WriteLine($"Badge ID: #{badgeID.Key}");
                Console.WriteLine("Can open doors: ");
                foreach(string door in badgeID.Value)
                {
                    Console.WriteLine($" -{door}");
                }
                Console.WriteLine();
            }
        }
    }
}
