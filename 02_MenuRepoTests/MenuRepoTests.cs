﻿using _01_Menu;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _02_MenuRepoTests
{
    [TestClass]
    public class MenuRepoTests
    {
        private MenuRepo _menu;
        private MenuItem _club;

        [TestInitialize]
        public void SeedMenu()
        {
            _menu = new MenuRepo();

            _club = new MenuItem("Club", "A club sandwich, also called a clubhouse sandwich, is a sandwich of bread, " +
                "sliced cooked poultry, ham or fried bacon, lettuce, tomato, and mayonnaise.", 
                new List<string>() { "bread", "sliced cooked poultry", "ham", "lettuce", "tomato", "mayonnaise" }, 3, "#1");

            MenuItem blt = new MenuItem("BLT", "A BLT is a type of sandwich, named for the initials of its primary ingredients, " +
                "bacon, lettuce and tomato.", new List<string>() { "bread", "bacon", "lettuce", "tomato", "mayonnaise" }, 4, "#2");

            _menu.AddMeal(_club);
            _menu.AddMeal(blt);
        }

        [TestMethod]
        public void AddTest()
        {
            //Arrange
            MenuItem reuben = new MenuItem("Reuben", "The Reuben sandwich is an American grilled sandwich composed of corned beef, " +
                "Swiss cheese, sauerkraut, and Russian dressing, grilled between slices of rye bread.",
                new List<string>() { "rye bread", "corned beef", "swiss cheese", "sauerkraut", "russian dressing" }, 5, "#3");            
            //Act
            bool success = _menu.AddMeal(reuben);
            Console.WriteLine(_menu.GetMenu().Count);
            Console.WriteLine(success);
            Console.WriteLine(reuben.Name);
            //Assert
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void GetTest()
        {
            MenuItem searchMeal = _menu.GetMenuItem("#1");
            Assert.AreEqual(searchMeal, _club);
        }

        [TestMethod]
        public void UpdateTest()
        {
            MenuItem newMenuItem = new MenuItem("BLT", "A BLT is a type of sandwich, named for the initials of its primary ingredients, " +
                "bacon, lettuce and tomato.", new List<string>() { "bread", "bacon", "lettuce", "tomato", "mayonnaise" }, 5, "#2");
            bool updated = _menu.UpdateMenuItem("BLT", newMenuItem);
            Assert.IsTrue(updated);
            MenuItem updatedMenuItem = _menu.GetMenuItem("#2");
            int expected = 5;
            int actual = updatedMenuItem.Price;
            Assert.AreEqual(expected, actual);
            Console.WriteLine(updatedMenuItem.Price);
        }

        [TestMethod]
        public void DeleteTest()
        {
            bool itemDeleted = _menu.DeleteMenuItem("#1");
            Assert.IsTrue(itemDeleted);
        }
    }
}
