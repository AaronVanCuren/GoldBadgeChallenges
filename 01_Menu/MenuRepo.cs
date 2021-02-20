using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Menu
{
    public class MenuRepo
    {
        private readonly List<MenuItem> _menu = new List<MenuItem>();
        public bool AddMeal(MenuItem item)
        {
            int count = _menu.Count;
            _menu.Add(item);
            bool success = _menu.Count > count;
            return success;
        }
        public List<MenuItem> GetMenu()
        {
            return _menu;
        }
        public MenuItem GetMenuItem(string itemNumber)
        {
            foreach (MenuItem item in _menu)
            {
                if (itemNumber.ToLower() == item.ItemNumber.ToLower())
                {
                    return item;
                }Console.WriteLine("Item cannot be found");
            }return null;
        }
        public bool UpdateMenuItem(string originalMenuItem, MenuItem newMenuItem)
        {
            MenuItem oldMenuItem = GetMenuItem(originalMenuItem);
            if (oldMenuItem != null)
            {
                oldMenuItem.Name = newMenuItem.Name;
                oldMenuItem.Description = newMenuItem.Description;
                oldMenuItem.Ingredients = newMenuItem.Ingredients;
                oldMenuItem.Price = newMenuItem.Price;
                oldMenuItem.ItemNumber = newMenuItem.ItemNumber;
                return true;
            }return false;
        }
        public bool DeleteMenuItem(string Name)
        {
            MenuItem contentToDelete = GetMenuItem(Name);
            return _menu.Remove(contentToDelete);
        }
    }
}
