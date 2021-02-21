using _01_Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _02_ClaimsRepoTests
{
    [TestClass]    
    public class ClaimsRepoTests
    {
        private ClaimsRepo _repo;
        private Claim _home;
        [TestInitialize]
        public void SeedClaims()
        {
            _repo = new ClaimsRepo();
            Claim car = new Claim(1, ClaimCatagory.Car, "Car accident on 465", 400.00, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27));
            _home = new Claim(2, ClaimCatagory.Home, "House fire in kitchen", 4000.00, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12));
            _repo.AddClaim(car);
            _repo.AddClaim(_home);
        }
        [TestMethod]
        public void AddTest()
        {
            Claim newClaim = new Claim(4, ClaimCatagory.Theft, "Stolen shoes", 4.00, new DateTime(2021, 01, 15), new DateTime(2021, 02, 02));
            bool wasAdded = _repo.AddClaim(newClaim);
            Console.WriteLine(_repo.GetClaims().Count);
            Console.WriteLine(wasAdded);
            Console.WriteLine(newClaim.ClaimID);
            Assert.IsTrue(wasAdded);
        }
        [TestMethod]
        public void DequeueTest()
        {
            bool wasDequeued = _repo.Dequeue();
            Assert.IsTrue(wasDequeued);
        }
    }
}
