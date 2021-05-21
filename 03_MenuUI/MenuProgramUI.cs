using _01_Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_MenuUI
{
    public class MenuProgramUI
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
                    "2. Add new menu item\n" +
                    "3. Update menu item\n" +
                    "4. Remove menu item\n" +
                    "0. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ShowMenu();
                        break;
                    case "2":
                        CreateNewMenuItem();
                        break;
                    case "3":
                        UpdateMenuItem();
                        break;
                    case "4":
                        RemoveMenuItem();
                        break;
                    case "0":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 4.\n" +
                            "or press 0 to exit.");
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
                DisplayMeal(item);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private string GetMenuItemFromUser()
        {
            Console.WriteLine("Enter a meal item number (#1, #2, #3...etc)\n");
            string item = Console.ReadLine();
            return item;
        }

        public void DisplayMeal (MenuItem item)
        {
            string ingredients = string.Join(", ", item.Ingredients);

            Console.WriteLine($"Meal: {item.Name}\n" +
                $"Description: {item.Description}\n" +
                $"Ingredients: {ingredients}\n" +
                $"Price: {item.Price:C2}\n" +
                $"Meal Number: {item.ItemNumber}\n");
        }

        public void CreateNewMenuItem()
        {
            Console.Clear();
            MenuItem item = new MenuItem();

            Console.WriteLine("Please enter meal name: ");
            item.Name = Console.ReadLine();

            Console.WriteLine("Please enter a description: ");
            item.Description = Console.ReadLine();

            Console.WriteLine("Please enter a an ingredient: ");
            item.Ingredients = new List<string>() { Console.ReadLine() };

            bool wasAdded = true;
            while (wasAdded)
            {
                Console.WriteLine("Want to add another ingredient (Y/N)?");
                string response = Console.ReadLine().ToLower();
                switch (response)
                {
                    case "y":
                        {
                            Console.WriteLine("What ingrediant would you like to add?");
                            item.Ingredients.Add(Console.ReadLine());
                            break;
                        }
                    case "n":
                        {
                            wasAdded = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please type either Y or N.");
                            break;
                        }
                }
            }

            Console.WriteLine("Please enter a price: ");
            item.Price = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter a menu item number (Ex. #1, #2, #3...etc): ");
            item.ItemNumber = Console.ReadLine();

            _menu.AddMeal(item);
        }

        public void UpdateMenuItem()
        {
            MenuItem meals;
            do
            {
                string itemNumber = GetMenuItemFromUser();
                meals = _menu.GetMenuItem(itemNumber);
                if (itemNumber == "cancel")
                {
                    return;
                }
            } while (meals == null);

            Console.WriteLine("What would you like to update?\n" +
                "1. Name\n" +
                "2. Description\n" +
                "3. Ingredients\n" +
                "4. Price\n" +
                "5. Item Number\n");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("Enter a new name: ");
                    meals.Name = Console.ReadLine();
                    break;
                case "2":
                    Console.WriteLine("Enter a new description: ");
                    meals.Description = Console.ReadLine();
                    break;
                case "3":
                    Console.WriteLine("Would you like to add or remove an ingredient?\n" +
                        "1. Add Ingredient\n" +
                        "2. Remove Ingredient\n" +
                        "3. Keep ingredient list\n");
                    string ingredientInput = Console.ReadLine();
                    switch (ingredientInput)
                    {
                        case "1":
                            Console.WriteLine("Please enter an ingredient you would like to add: ");
                            meals.Ingredients = new List<string>() { Console.ReadLine() };

                            bool wasAdded = true;
                            while (wasAdded)
                            {
                                Console.WriteLine("Want to add another ingredient (Y/N)?");
                                string response = Console.ReadLine().ToLower();
                                switch (response)
                                {
                                    case "y":
                                        {
                                            Console.WriteLine("What ingredient would you like to add?");
                                            meals.Ingredients.Add(Console.ReadLine());
                                            break;
                                        }
                                    case "n":
                                        {
                                            wasAdded = false;
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("Please type either Y or N.");
                                            break;
                                        }
                                }
                            }
                            break;
                        case "2":
                            Console.WriteLine("Please enter an ingredient you would like to remove:");
                            meals.Ingredients.Remove(Console.ReadLine());

                            bool wasRemoved = true;
                            while (wasRemoved)
                            {
                                Console.WriteLine("Want to remove another ingredient (Y/N)?");
                                string response = Console.ReadLine().ToLower();
                                switch (response)
                                {
                                    case "y":
                                        {
                                            Console.WriteLine("What ingredient would you like to remove?");
                                            meals.Ingredients.Remove(Console.ReadLine());
                                            break;
                                        }
                                    case "n":
                                        {
                                            wasRemoved = false;
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("Please type either Y or N.");
                                            break;
                                        }
                                }
                            }
                            break;
                        case "3":
                            break;
                        default:
                            Console.WriteLine("Please enter a valid number between 1 and 3");
                            Console.ReadKey();
                            break;
                    }
                    break;
                case "4":
                    Console.WriteLine("Enter a new price:");
                    meals.Price = int.Parse(Console.ReadLine());
                    break;
                case "5":
                    Console.WriteLine("Enter a new item number (ex. #1):");
                    meals.ItemNumber = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Please enter a valid number between 1 and 5.\n");
                    Console.ReadKey();
                    break;
            }
        }

        public void RemoveMenuItem()
        {
            Console.Clear();
            Console.WriteLine("These are the available menu items you can remove.\n");
            List<MenuItem> Menu = _menu.GetMenu();
            foreach (MenuItem item in Menu)
            {
                DisplayMeal(item);
            }
            Console.WriteLine("\nWhich menu item would you like to remove?\n");
            string itemNumber = GetMenuItemFromUser();
            _menu.DeleteMenuItem(itemNumber);
           
        }
        private void SeedMenu()
        {
            MenuItem club = new MenuItem("Club", "A club sandwich, also called a clubhouse sandwich, is a sandwich of bread, " +
                    "sliced cooked poultry, ham or fried bacon, lettuce, tomato, and mayonnaise.",
                    new List<string>() { "bread", "sliced cooked poultry", "ham", "lettuce", "tomato", "mayonnaise" }, 3, "#1");

            MenuItem blt = new MenuItem("BLT", "A BLT is a type of sandwich, named for the initials of its primary ingredients, " +
                "bacon, lettuce and tomato.", new List<string>() { "bread", "bacon", "lettuce", "tomato", "mayonnaise" }, 4, "#2");

            _menu.AddMeal(club);
            _menu.AddMeal(blt);
        }
    }
}
