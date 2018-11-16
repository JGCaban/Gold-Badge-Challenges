using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    public class Menu
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public string MealIngredients { get; set; }
        public decimal MealPrice { get; set; }

        public Menu(int mealnumber, string mealname, string mealdescription, string mealingredients, decimal mealprice)
        {
            MealNumber = mealnumber;
            MealName = mealname;
            MealDescription = mealdescription;
            MealIngredients = mealingredients;
            MealPrice = mealprice;
        }

        public Menu()
        {

        }
    }
}
