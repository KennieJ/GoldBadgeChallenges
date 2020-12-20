using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimsRepository
{
    public class ClaimsRepository
    {
        private Queue<Claims> _queueOfClaims = new Queue<Claims>();

        //Create
        public void AddClaimToQueue(Claims claim)
        {
            _queueOfClaims.Enqueue(claim);
        }

        //Read
        public Queue<Claims> GetClaimsQueue()
        {
            return _queueOfClaims;
        }

        //Update: not requested by Komodo
        

        //Delete: Agent dealt with claim
        public bool RemoveClaimFromQueue()
        {
            int initialCount = _queueOfClaims.Count;
            _queueOfClaims.Dequeue();

            if(initialCount > _queueOfClaims.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //helper
        public Claims GetClaimByID(string claimID)
        {
            foreach(Claims claim in _queueOfClaims)
            {
                if(claim.ClaimID.ToLower() == claimID.ToLower())
                {
                    return claim;
                }
            }

            return null;
        }
    }
}
