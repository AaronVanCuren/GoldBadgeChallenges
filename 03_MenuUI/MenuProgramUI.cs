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
                    "2. Find menu item by number or name\n" +
                    "3. Add new menu item\n" +
                    "4. Remove menu item\n" +
                    "5. Update menu item\n" +
                    "0. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ShowMenu();
                        break;
                    case "2":
                        ShowMenuItem();
                        break;
                    case "3":
                        CreateNewMenuItem();
                        break;
                    case "4":
                        RemoveMenuItem();
                        break;
                    case "5":
                        UpdateMenuItem();
                        break;
                    case "0":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 5.\n" +
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
                DisplayMenu(item);
            }Console.ReadKey();
        }
        public void ShowMenuItem()
        {
            string itemNumber = GetMenuItemFromUser();
            MenuItem item = _menu.GetMenuItem(itemNumber);
            if (item != null)
            {
                DisplayMenu(item);
            }else
            {
                Console.WriteLine("Invalid menu item.");
            }Console.ReadKey();
        }
        private string GetMenuItemFromUser()
        {
            Console.Clear();
            Console.WriteLine("Enter a meal item number (#1, #2, #3...etc)\n");
            string item = Console.ReadLine();
            return item;
        }
        public void DisplayMenu(MenuItem item)
        {
            Console.WriteLine($"Meal: {item.Name}\n" +
                $"Description: {item.Description}\n" +
                $"Ingredients: {item.Ingredients}\n" +
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
            Console.WriteLine("Please enter a list of ingredients: ");
            item.Ingredients = new List<string>() { };
            Console.WriteLine("Please enter a price: ");
            item.Price = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter a menu item number (Ex. #1, #2, #3...etc): ");
            item.ItemNumber = Console.ReadLine();
            _menu.AddMeal(item);
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
                }else
                {
                    Console.WriteLine("I'm sorry, I can't do that.");
                }
            }else
            {
                Console.WriteLine("No content has that ID.");
            }
            Console.ReadKey();
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
                "3. Ingredietns\n" +
                "4. Price\n" +
                "5. Item Number\n");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.WriteLine("Enter a new name:");
                    string newName = Console.ReadLine();
                    meals.Name = newName;
                    break;
                case "2":
                    Console.WriteLine("Enter a new description:");
                    string newDescription = Console.ReadLine();
                    meals.Description = newDescription;
                    break;
                case "3":
                    Console.WriteLine("Enter a new list of ingredients where each ingredient is seperated by a comma:");
                    bool continueToAdd = true;
                    string answer;
                    while (continueToAdd)
                    {
                        Console.Clear();
                        var ingredients = new List<string>() { };
                        Console.WriteLine("Add an ingredient:");
                        string newIngredient = Console.ReadLine();
                        ingredients.Add(newIngredient);
                        Console.WriteLine("Would you like to add another ingredient(y/n)?");
                        answer = Console.ReadLine();           
                        if (answer == "n")
                        {
                            continueToAdd = false;
                        }
                    }
                    break;
                case "4":
                    Console.WriteLine("Enter a new price:");
                    int newPrice = Console.Read();
                    meals.Price = newPrice;
                    break;
                case "5":
                    Console.WriteLine("Enter a new item number (ex. #1):");
                    string newItemNumber = Console.ReadLine();
                    meals.ItemNumber = newItemNumber;
                    break;
                default:
                    Console.WriteLine("Please enter a valid number between 1 and 5.\n");
                    Console.ReadKey();
                    break;
            }
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
