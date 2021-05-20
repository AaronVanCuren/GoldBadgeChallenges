using _01_Badges;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _02_BadgeRepoTests
{
    [TestClass]
    public class BadgeRepoTests
    {
        private BadgesRepo _accessRepo;
        private Badges _levelOne;
        private Badges levelTwo;

        [TestInitialize]
        public void SeedBadges()
        {
            _accessRepo = new BadgesRepo();
            _levelOne = new Badges("1000", new List<string>() { "A1", "A2", "A3", "A4" });
            levelTwo = new Badges("2000", new List<string>() { "A1", "A2", "A3", "A4", "B1", "B2", "B3", "B4" });
            Badges levelthree = new Badges("3000", new List<string>() { "A1", "A2", "A3", "A4", "B1", "B2", "B3", "B4", "C1", "C2", "C3", "C4" });
            _accessRepo.AddBadge(_levelOne.BadgeID, _levelOne.Doors);
            _accessRepo.AddBadge(levelTwo.BadgeID, levelTwo.Doors);
            _accessRepo.AddBadge(levelthree.BadgeID, levelthree.Doors);
        }

        [TestMethod]
        public void AddBadgeTest()
        {
            Badges badge = new Badges("4000", new List<string>() { "A1", "A2", "A3", "A4", "B1", "B2", "B3", "B4", "C1", "C2", "C3", "C4", "D1", "D2", "D3", "D4" });
            bool badgeAdded = _accessRepo.AddBadge(badge.BadgeID, badge.Doors);
            Console.WriteLine(_accessRepo.GetAllBadges().Count);
            Console.WriteLine(badgeAdded);
            Console.WriteLine(badge.BadgeID);
            Assert.IsTrue(badgeAdded);
        }
    }
}
