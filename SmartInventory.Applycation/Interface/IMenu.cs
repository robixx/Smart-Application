using SmartInventory.Applycation.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Applycation.Interface
{
    public interface IMenu
    {
        Task<(string Message, bool Status, List<MenuDto> menulist)> getMenuAsync();
    }
}
