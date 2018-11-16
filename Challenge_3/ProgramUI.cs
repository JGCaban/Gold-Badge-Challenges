using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    public class ProgramUI
    {
        OutingRepository _outingRepo = new OutingRepository();
        List<Outing> listofOutings;
        public void Run()
        {
            Outing golfOuting = new Outing(EventType.Golf, 10, new DateTime(2018, 06, 23), 15.99m, 159.99m);
            Outing bowlingOuting = new Outing(EventType.Bowling, 30, new DateTime(2018, 09, 01), 8.99m, 89.99m);
            Outing amusementparkOuting = new Outing(EventType.AmusementPark, 50, new DateTime(2018, 11, 09), 30.00m, 1500.00m);
            Outing concertOuting = new Outing(EventType.Concert, 100, new DateTime(2018, 03, 24), 75.00m, 7500.00m);
            listofOutings = _outingRepo.GetOutingList();
            listofOutings.Add(golfOuting);
            listofOutings.Add(bowlingOuting);
            listofOutings.Add(amusementparkOuting);
            listofOutings.Add(concertOuting);
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Choose a menu item: " +
                    "\n1. See all outings" +
                    "\n2. Add an outing" +
                    "\n3. See cost for each outing type" +
                    "\n4. See combine cost for all outings" +
                    "\n0. Exit.");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        SeeOutings();
                        break;
                    case 2:
                        AddOuting();
                        break;
                    case 3:
                        OutingCost();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine($"Total cost of all outings combined is: ${_outingRepo.GetTotalOutingCost()}");
                        Console.WriteLine();
                        break;
                    case 0:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
        }
        private void SeeOutings()
        {
            Console.Clear();
            Console.WriteLine("Type" + "\t\tAttendance" + "\t\tDate" + "\t\tEntry Cost" + "\t\tEventCost");
            foreach (Outing content in _outingRepo.GetOutingList())
            {
                Console.WriteLine($"{content.TypeOfEvent} \t\t{content.Attendance} \t\t{content.EventDate} \t\t{content.PerPersonCost} \t\t{content.EventCost}");       // \t = tab spacing
                Console.WriteLine();
            }
        }
        private void AddOuting()
        {
            Console.Clear();
            Console.WriteLine("Enter the number for the outing you want to create: (Golf-1/Bowling-2/Amusementpark-3/Concert-4)");
            var typeofevent = int.Parse(Console.ReadLine());
            Console.WriteLine("How many people will attend the outing?");
            var attendance = int.Parse(Console.ReadLine());
            Console.WriteLine("On what date is the event taking place? (YYYY, MM, DD)");
            var eventdate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("What is the price per person? (0.00)");
            var perpersoncost = decimal.Parse(Console.ReadLine());
            Console.WriteLine("What is the total cost of the event? (0.00)");
            var eventcost = decimal.Parse(Console.ReadLine());
            Outing outing = new Outing((EventType)typeofevent, attendance, eventdate, perpersoncost, eventcost);        //Adds value to the outing properties
            _outingRepo.AddOutingToList(outing);        //Adds outing to List<Outing>
        }
        private void OutingCost()
        {
            Console.Clear();
            Console.WriteLine("Cost for each individual outing: ");
            Console.WriteLine();
            foreach (Outing content in _outingRepo.GetOutingList())
            {
                Console.WriteLine($"{content.TypeOfEvent} - ${content.EventCost}");
                Console.WriteLine();
            }
        }
    }
}