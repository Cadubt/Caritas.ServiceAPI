using Caritas.ServiceAPI.Context.Entities;
using Caritas.ServiceAPI.Repositories.Interfaces;
using Caritas.ServiceAPI.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.ServiceAPI.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepo;

        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepo = menuRepository;
        }

        public async Task<List<Menu>> List(int UserID)
        {
            List<Menu> menus = new List<Menu>();
            menus = await _menuRepo.List(UserID);
            return menus;
        }
    }
}
