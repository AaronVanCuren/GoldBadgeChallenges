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

        public bool AddMeal(MenuItem content)
        {
            int count = _menu.Count;
            _menu.Add(content);
            bool success = _menu.Count > count;
            return success;
        }

        public List<MenuItem> GetContents()
        {
            return _menu;
        }

        public MenuItem GetMenuItem(string Name)
        {
            foreach (MenuItem content in _menu)
            {
                if (Name.ToLower() == content.Name.ToLower())
                {
                    return content;
                }
                Console.WriteLine("Item cannot be found");
            }
            return null;
        }

        public bool UpdateMenuContent(string originalMenuItem, MenuItem newMenuItem)
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
            }
            return false;
        }

        public bool DeleteMenuItem(string Name)
        {
            MenuItem contentToDelete = GetMenuItem(Name);
            return _menu.Remove(contentToDelete);
        }
    }
}
