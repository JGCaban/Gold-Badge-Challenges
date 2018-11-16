using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    public class OutingRepository
    {
        List<Outing> _listofOutings = new List<Outing>();

        public void AddOutingToList(Outing content)
        {
            _listofOutings.Add(content);
        }
        public List<Outing> GetOutingList()
        {
            return _listofOutings;
        }
        public decimal GetTotalOutingCost()
        {
            decimal totalEventCost = 0;
            foreach (Outing outing in _listofOutings)
            {
                totalEventCost += outing.EventCost; 
            }
            return totalEventCost;
        }
    }
}
