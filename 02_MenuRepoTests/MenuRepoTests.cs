using _01_Menu;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _02_MenuRepoTests
{
    [TestClass]
    public class MenuRepoTests
    {
        [TestMethod]
        public void Menu()
        {
            MenuItem club = new MenuItem("Club", "A club sandwich, also called a clubhouse sandwich, is a sandwich of bread, " +
                "sliced cooked poultry, ham or fried bacon, lettuce, tomato, and mayonnaise.", new List<string>() { "bun", "ketchup" }, 3, 1);

            MenuItem blt = new MenuItem("BLT", "A BLT is a type of sandwich, named for the initials of its primary ingredients, " +
                "bacon, lettuce and tomato.", new List<string>() { "bun", "ketchup" }, 4, 2);

            MenuItem reuben = new MenuItem("Reuben", "The Reuben sandwich is an American grilled sandwich composed of corned beef, " +
                "Swiss cheese, sauerkraut, and Russian dressing, grilled between slices of rye bread.", new List<string>() { "bun", "ketchup" }, 5, 3);

            _menu.AddMealToMenu(club);
            _menu.AddMealToMenu(blt);
            _menu.AddMealToMenu(reuben);
        }
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
        public void AddTest()
        {
            StreamingContent content = new StreamingContent(
                "Galaxy Quest", "Sci Fi actors inadvertently go on a real Sci Fi adventure", Maturity.PG, 5, GenreType.Comedy);
            // Act
            bool wasAdded = _repo.AddContentToDirectory(content);

            Console.WriteLine(_repo.GetContents().Count);

            Console.WriteLine(wasAdded);
            Console.WriteLine(content.Title);

            // Assert
            Assert.IsTrue(wasAdded);
        }
    }
    }
}
