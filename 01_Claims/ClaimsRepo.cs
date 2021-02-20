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
        public bool AddClaim(Claim claim)
        {
            int count = _claims.Count;
            _claims.Enqueue(claim);
            bool newClaim = _claims.Count > count;
            return newClaim;
        }
        //Take care of next claim
        public void PeekClaim(Claim claim)
        {
            _claims.Peek();
        }
    }
}
