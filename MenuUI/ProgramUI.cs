using _01_Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuUI
{
    public class ProgramUI
    {
        private readonly MenuRepo _menu = new MenuRepo();
        
        public void Run()
        {
            SeedMenu();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Enter the number of the option you'd like to select:\n" +
                    "1. Show Menu\n" +
                    "2. Find menu item by number or name\n" +
                    "3. Add new menu item\n" +
                    "4. Remove menu item\n" +
                    "5. Update menu item\n" +
                    "6. Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        //-- Show all content
                        /*Console.WriteLine("Star Wars");
                        Console.ReadKey();*/
                        ShowMenu();
                        break;
                    case "2":
                        //-- Find content by title
                        ShowMenuItem();
                        break;
                    case "3":
                        //-- Add new content
                        CreateNewMenuItem();
                        break;
                    case "4":
                        //-- Remove content
                        RemoveMenuItem();
                        break;
                    case "5":
                        //-- Update Content
                        UpdateMenuItem();
                        break;
                    case "0":
                        //-- Exit
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 5.\n" +
                            "or press 6 to exit.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void SeedMenu()
        {
            MenuItem club = new MenuItem("Club", "A club sandwich, also called a clubhouse sandwich, is a sandwich of bread, " +
                    "sliced cooked poultry, ham or fried bacon, lettuce, tomato, and mayonnaise.", new List<string>() { "bun", "ketchup" }, 3, 1);

            MenuItem blt = new MenuItem("BLT", "A BLT is a type of sandwich, named for the initials of its primary ingredients, " +
                "bacon, lettuce and tomato.", new List<string>() { "bun", "ketchup" }, 4, 2);

            MenuItem reuben = new MenuItem("Reuben", "The Reuben sandwich is an American grilled sandwich composed of corned beef, " +
                "Swiss cheese, sauerkraut, and Russian dressing, grilled between slices of rye bread.", new List<string>() { "bun", "ketchup" }, 5, 3);

            _menu.AddMeal(club);
            _menu.AddMeal(blt);
            _menu.AddMeal(reuben);
        }
    }
}
