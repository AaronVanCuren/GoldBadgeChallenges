using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Claims
{
    public class ClaimsRepo
    {
        private readonly Queue<Claim> _claims = new Queue<Claim>();

        //See all claims
        public Queue<Claim> GetClaims()
        {
            return _claims;
        }

        //Enter new claim
        public void AddClaim(Claim claim)
        {
            _claims.Enqueue(claim);
        }

        //Take care of next claim
        public void PeekClaim(Claim claim)
        {
            
        }
    }
}
