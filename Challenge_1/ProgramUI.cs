using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    class ProgramUI
    {
        MenuRepository _menuRepo = new MenuRepository();
        List<Menu> menuItem;
        public void Run()
        {
            RunMenu();
        }
        private void RunMenu()
        {
            menuItem = _menuRepo.GetMenuItemList();
            bool running = true;
            while (running)
            {
                Console.WriteLine("Welcome to Komodo Cafe menu editor.\n" +
                    "\n1. Add menu item" +
                    "\n2. Delete menu item" +
                    "\n3. See all menu items" +
                    "\n0. Exit");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        AddItem();
                        break;
                    case 2:
                        DeleteItem();
                        break;
                    case 3:
                        SeeAllItems();
                        break;
                    case 0:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Entry.");
                        break;
                }
            }
        }
        private void AddItem()
        {
            Console.Clear();
            Menu newContent = new Menu();
            Console.WriteLine("What is the meal item number?");
            newContent.MealNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("\nWhat is the item's name?");
            newContent.MealName = Console.ReadLine();
            Console.WriteLine("\nWhat is the item's description?");
            newContent.MealDescription = Console.ReadLine();
            Console.WriteLine("\nWhat is the item's ingredients?");
            newContent.MealIngredients = Console.ReadLine();
            Console.WriteLine("\nWhat is the item's price?");
            newContent.MealPrice = decimal.Parse(Console.ReadLine());
            _menuRepo.AddMenuItemToList(newContent);
        }
        private void DeleteItem()
        {
            Console.Clear();
            Console.WriteLine("Enter the item number for the item you would like to remove.");
            foreach (Menu content in _menuRepo.GetMenuItemList())
            {
                Console.WriteLine();
            }
            int removeMenuItem = int.Parse(Console.ReadLine());

            foreach (Menu meal in _menuRepo.GetMenuItemList())
            {
                if (removeMenuItem == meal.MealNumber)
                {
                    _menuRepo.RemoveMenuItemFromList(meal);
                    break;
                }
            }
        }
        private void SeeAllItems()
        {
            Console.Clear();
            foreach (Menu content in _menuRepo.GetMenuItemList())
            {
                Console.WriteLine($"#{content.MealNumber} {content.MealName}");
                Console.WriteLine(content.MealDescription);
                Console.WriteLine($"Contains: {content.MealIngredients}");
                Console.WriteLine($"Price: ${content.MealPrice}");
                Console.WriteLine();
            }
        }
    }
}
