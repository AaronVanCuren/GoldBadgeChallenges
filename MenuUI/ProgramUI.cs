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
                        ShowMenu();
                        break;
                    case "2":
                        //-- Find content by number/name
                        ShowMenuItem();
                        break;
                    case "3":
                        //-- Add new menu item
                        CreateNewMenuItem();
                        break;
                    case "4":
                        //-- Remove menu item
                        RemoveMenuItem();
                        break;
                    case "5":
                        //-- Update menu item
                        UpdateMenuItem();
                        break;
                    case "0":
                        //-- Exit program
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

        public void ShowMenu()
        {
            Console.Clear();
            List<MenuItem> Menu = _menu.GetMenu();
            foreach (MenuItem item in Menu)
            {
                DisplayMenu(item);
            }
            Console.ReadKey();
        }

        public void DisplayMenu(MenuItem item)
        {
            Console.WriteLine($"Meal: {item.Name}\n" +
                $"Description: {item.Description}\n" +
                $"Ingredients: {item.Ingredients}\n" +
                $"Price: {item.Price}\n" +
                $"Meal Number: {item.ItemNumber}\n");
        }

        public void ShowMenuItem()
        {
            string itemNumber = GetMenuItem();
            MenuItem item = _menu.GetMenuItem(itemNumber);
            if (item != null)
            {
                DisplayMenu(item);
            }
            else
            {
                Console.WriteLine("Invalid menu item.");
            }

            Console.ReadKey();
        }

        private string GetMenuItem()
        {
            Console.Clear();
            Console.WriteLine("Enter a meal item number\n");
            string item = Console.ReadLine();
            return item;
        }

        public void CreateNewMenuItem()
        {
            Console.Clear();
            MenuItem item = new MenuItem();

            Console.WriteLine("Please enter meal name: ");
            item.Name = Console.ReadLine();

            Console.WriteLine("Please enter a description: ");
            item.Description = Console.ReadLine();

            Console.WriteLine("Please enter a list of ingredients: ");
            item.Ingredients = new List<string>() { };

            Console.WriteLine("Please enter a price: ");
            item.Price = Console.Read();

            Console.WriteLine("Pleaes enter a menu item number (Ex. one, two...etc): ");
            item.ItemNumber = Console.ReadLine();

        }

        public void RemoveMenuItem()
        {
            Console.Clear();
            Console.WriteLine("Which menu item would you like to remove?");

            List<MenuItem> menuItems = _menu.GetMenu();

            int count = 0;

            foreach (MenuItem item in menuItems)
            {
                count++;
                Console.WriteLine($"{count}. {item.Name}");
            }

            int targetMenuItem = int.Parse(Console.ReadLine());
            int targetMenuItems = targetMenuItem - 1;

            if (targetMenuItems >= 0 && targetMenuItems < menuItems.Count)
            {
                MenuItem desiredMenuItem = menuItems[targetMenuItems];

                if (_menu.DeleteMenuItem(desiredMenuItem.Name))
                {
                    Console.WriteLine($"{desiredMenuItem.Name} was successfully removed.");
                }
                else
                {
                    Console.WriteLine("I'm sorry, I can't do that.");
                }
            }
            else
            {
                Console.WriteLine("No content has that ID.");
            }
            Console.ReadKey();
        }

        public void UpdateMenuItem()
        {

        }

        private void SeedMenu()
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
