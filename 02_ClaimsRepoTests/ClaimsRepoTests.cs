using _01_Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _02_ClaimsRepoTests
{
    [TestClass]    
    public class ClaimsRepoTests
    {
        private ClaimsRepo _repo;
        private Claim home;
        [TestInitialize]
        public void SeedClaims()
        {
            _repo = new ClaimsRepo();
            Claim car = new Claim(1, ClaimCatagory.car, "Car accident on 465", 400.00, new DateTime(18 / 25 / 4), new DateTime(18 / 27 / 4));
            home = new Claim(2, ClaimCatagory.home, "House fire in kitchen", 4000.00, new DateTime(18 / 11 / 4), new DateTime(18 / 12 / 4));
            _repo.AddClaim(car);
            _repo.AddClaim(home);
        }
        [TestMethod]
        public void AddTest()
        {
            Claim newClaim = new Claim(4, ClaimCatagory.theft, "Stolen shoes", 400, new DateTime(21 / 27 / 1), new DateTime(21 / 1 / 2));
            bool wasAdded = _repo.AddClaim(newClaim);
            Console.WriteLine(_repo.GetClaims().Count);
            Console.WriteLine(wasAdded);
            Console.WriteLine(newClaim.ClaimID);
            Assert.IsTrue(wasAdded);
        }
    }
}
