using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    public class MenuRepository
    {
        List<Menu> _listOfMenuContent = new List<Menu>();
        public void AddMenuItemToList(Menu menuitem)
        {
            _listOfMenuContent.Add(menuitem);
        }
        public void RemoveMenuItemFromList(Menu menuitem)
        {
            _listOfMenuContent.Remove(menuitem);
        }
        public List<Menu> GetMenuItemList()
        {
            return _listOfMenuContent;
        }
    }
}
