using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Menu
{
    public class MenuItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
        public int Price { get; set; }
        public string ItemNumber { get; set; }


        public MenuItem(string name, string info, List<string> ingredients, int cost, string mealNumber)
        {
            Name = name;
            Description = info;
            Ingredients = ingredients;
            Price = cost;
            ItemNumber = mealNumber;
        }

        MenuItem club = new MenuItem("Club", "A club sandwich, also called a clubhouse sandwich, is a sandwich of bread, " +
                "sliced cooked poultry, ham or fried bacon, lettuce, tomato, and mayonnaise.", 
            new List<string>() { "bread", "sliced cooked poultry", "ham", "lettuce", "tomato", "mayonnaise" }, 3, "one");

        MenuItem blt = new MenuItem("BLT", "A BLT is a type of sandwich, named for the initials of its primary ingredients, " +
            "bacon, lettuce and tomato.", new List<string>() { "bread", "bacon", "lettuce", "tomato", "mayonnaise" }, 4, "two");

        MenuItem reuben = new MenuItem("Reuben", "The Reuben sandwich is an American grilled sandwich composed of corned beef, " +
            "Swiss cheese, sauerkraut, and Russian dressing, grilled between slices of rye bread.", 
            new List<string>() { "rye bread", "corned beef", "swiss cheese", "sauerkraut", "russian dressing" }, 5, "three");
    }
}
