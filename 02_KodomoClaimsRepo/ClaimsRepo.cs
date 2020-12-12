using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KodomoClaimsRepo
{
    public class ClaimsRepo
    {
        Queue<Claims> quClaims = new Queue<Claims>();

        //Create
        public void AddClaimsToQu(Claims newClaim)
        {
           quClaims.Enqueue(newClaim);
        }
        //Read
        public Queue<Claims> SeeClaimQu()
        {
            return quClaims;
        }
        //Update?

        //Remove
        public void RemoveClaimFromQu()
        {
            quClaims.Dequeue();
        }
        public Claims NextClaim()
        {
           return quClaims.Peek();
        }
    }
}
