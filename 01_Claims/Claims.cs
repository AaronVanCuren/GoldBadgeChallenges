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
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                //Claim was within 30 days of incident
                if ((DateOfClaim.Date - DateOfIncident.Date).Days <= 30)
                {
                    return true;
                }else
                    return false;
            }
        }
        public Claim() { }
        public Claim(int claimId, ClaimCatagory claimType, string description, double claimAmount, DateTime incidentDate, DateTime claimDate)
        {
            ClaimID = claimId;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = incidentDate;
            DateOfClaim = claimDate;
        }
    }
}
