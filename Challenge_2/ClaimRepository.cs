using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    public class ClaimRepository
    {
        Queue<Claim> _queueofClaims = new Queue<Claim>();

        public void EnqueueClaimInQueue(Claim content)
        {
            _queueofClaims.Enqueue(content);
        }

        public Queue<Claim> GetClaimQueue()
        {
            return _queueofClaims;
        }
    }
}
