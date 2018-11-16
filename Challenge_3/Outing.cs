using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    public enum EventType { Golf = 1, Bowling, AmusementPark, Concert }
    public class Outing
    {
        public EventType TypeOfEvent { get; set; }
        public int Attendance { get; set; }
        public DateTime EventDate { get; set; }
        public decimal PerPersonCost { get; set; }
        public decimal EventCost { get; set; }

        public Outing(EventType typeofevent, int attendance, DateTime eventdate, decimal perpersoncost, decimal eventcost)
        {
            TypeOfEvent = typeofevent;
            Attendance = attendance;
            EventDate = eventdate;
            PerPersonCost = perpersoncost;
            EventCost = eventcost;
        }
        public override string ToString() => $"{TypeOfEvent} {Attendance} {EventDate} {PerPersonCost} {EventCost}";
    }
}
