using _01_Menu;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _02_MenuRepoTests
{
    [TestClass]
    public class MenuRepoTests
    {
        private MenuRepo _menu;

        [TestInitialize]
        public void Arrange()
        {
            _menu = new MenuRepo();
        }

        [TestMethod]
        public void MyTestMethod()
        {

        }

        [TestMethod]
        public void Menu()
        {
            MenuItem club = new MenuItem("Club", "A club sandwich, also called a clubhouse sandwich, is a sandwich of bread, " +
                "sliced cooked poultry, ham or fried bacon, lettuce, tomato, and mayonnaise.", 
                new List<string>() { "bread", "sliced cooked poultry", "ham", "lettuce", "tomato", "mayonnaise" }, 3, "one");

            MenuItem blt = new MenuItem("BLT", "A BLT is a type of sandwich, named for the initials of its primary ingredients, " +
                "bacon, lettuce and tomato.", new List<string>() { "bread", "bacon", "lettuce", "tomato", "mayonnaise" }, 4, "two");

            MenuItem reuben = new MenuItem("Reuben", "The Reuben sandwich is an American grilled sandwich composed of corned beef, " +
                "Swiss cheese, sauerkraut, and Russian dressing, grilled between slices of rye bread.", 
                new List<string>() { "rye bread", "corned beef", "swiss cheese", "sauerkraut", "russian dressing" }, 5, "three");

            _menu.AddMeal(club);
            _menu.AddMeal(blt);
            _menu.AddMeal(reuben);
        }
    }
}
