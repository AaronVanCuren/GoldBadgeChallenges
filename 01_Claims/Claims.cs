using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Claims
{
    public enum ClaimCatagory { car, home, theft };
    public class Claim
    {
        public int ClaimID { get; set; }
        public ClaimCatagory ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
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
                }else
                    return false;
            }
        }
        public Claim() { }
        public Claim(int claimId, ClaimCatagory claimType, string description, double claimAmount, DateTime incidentDate, DateTime claimDate, bool validity)
        {
            ClaimID = claimId;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = incidentDate;
            DateOfClaim = claimDate;
        }
        Claim car = new Claim(1, ClaimCatagory.car, "Car accident on 465", 400.00, new DateTime(18 / 25 / 4), new DateTime(18 / 27 / 4), true);
        Claim home = new Claim(2, ClaimCatagory.home, "House fire in kitchen", 4000.00, new DateTime(18 / 11 / 4), new DateTime(18 / 12 / 4), true);
        Claim theft = new Claim(3, ClaimCatagory.theft, "Stolen pancakes", 4.00, new DateTime(18 / 27 / 4), new DateTime(18 / 1 / 6), true);
    }
}
