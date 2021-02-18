using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Claims
{
    public enum ClaimCatagory { Car, Home, Theft };

    public class Claim
    {
        public int ClaimID { get; set; }
        public ClaimCatagory ClaimType { get; set; }
        public string Description { get; set; }
        public int ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                //Claim was within 30 days of incident
                if ((DateOfClaim - DateOfIncident).Days <= 30)
                {
                    return true;
                }
                else
                    return false;
            }
        }
    }
}
