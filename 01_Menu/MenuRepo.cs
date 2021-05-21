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

        public List<MenuItem> GetMenu()
        {
            return _menu;
        }

        public MenuItem GetMenuItem(string itemNumber)
        {
            foreach (MenuItem item in _menu)
            {
                if (itemNumber == item.ItemNumber)
                {
                    return item;
                }
            }
            throw new Exception("Item cannot be found");
        }

        public bool AddMeal(MenuItem item)
        {
            int count = _menu.Count;

            _menu.Add(item);

            bool success = _menu.Count > count;
            return success;
        }

        public bool UpdateMenuItem(string originalName, MenuItem newMenuItem)
        {
            MenuItem oldMenuItem = GetMenuItem(originalName);
            if (oldMenuItem != null)
            {
                oldMenuItem.Name = newMenuItem.Name;
                oldMenuItem.Description = newMenuItem.Description;
                oldMenuItem.Ingredients = newMenuItem.Ingredients;
                oldMenuItem.Price = newMenuItem.Price;
                oldMenuItem.ItemNumber = newMenuItem.ItemNumber;
                return true;
            }
            return false;
        }

        public bool DeleteMenuItem(string itemNumber)
        {
            int count = _menu.Count;

            MenuItem contentToDelete = GetMenuItem(itemNumber);
            _menu.Remove(contentToDelete);

            bool itemDeleted = _menu.Count < count;
            return itemDeleted;
        }
    }
}
