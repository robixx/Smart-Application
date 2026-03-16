
using SmartInventory.Applycation.Interface;
using SmartInventory.Applycation.ModelView;
using SmartInventory.Infrastructure.DataConnect;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace SmartInventory.Infrastructure.Services
{
    public class MenuService : IMenu
    {

        private readonly DatabaseConnection _connection;

        public MenuService (DatabaseConnection connection)
        {
            _connection = connection;
        }
        public async Task<(string Message, bool Status, List<MenuDto> menulist)> getMenuAsync()
        {
            try
            {


                // Call SP using FromSqlRaw
                var allMenus = await _connection.Menu
                    .FromSqlRaw("EXEC sp_GetMenus")
                    .ToListAsync();

                // Separate parent menus
                var parentMenus = allMenus
                    .Where(m => m.ParentMenuId == 0)
                    .OrderBy(m => m.DisplayOrder)
                    .ToList();

                // Map to MenuDto
                var menuList = parentMenus.Select(p => new MenuDto
                {
                    MenuId = p.MenuId,
                    MenuName = p.MenuName,
                    Icon = p.Icon,
                    MenuUrl=p.MenuUrl,
                    AreaName=p.AreaName,
                    ActionController=p.ActionController,
                    ActionMethod=p.ActionMethod,
                    submenu = allMenus
                                .Where(c => c.ParentMenuId == p.MenuId)
                                .OrderBy(c => c.DisplayOrder)
                                .Select(c => new SubmenuDto
                                {
                                    MenuId = c.MenuId,
                                    MenuName = c.MenuName,
                                    MenuUrl = c.MenuUrl,
                                    AreaName = c.AreaName,
                                    ActionController = c.ActionController,
                                    ActionMethod = c.ActionMethod,
                                    ParentMenuId = c.ParentMenuId,
                                    Icon = c.Icon,
                                    DisplayOrder = c.DisplayOrder
                                }).ToList()
                }).ToList();

                return ("Menu loaded successfully", true, menuList);



            }
            catch (Exception ex)
            {
                return ($"Service ->{nameof(MenuService)}: Method ->:{nameof(getMenuAsync)}: Error -> : {ex.Message}", false, new List<MenuDto>());
            }
        }
    }
}
