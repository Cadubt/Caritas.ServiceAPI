using Caritas.ServiceAPI.Context;
using Caritas.ServiceAPI.Context.Entities;
using Caritas.ServiceAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.ServiceAPI.Repositories
{
    public class MenuRepository : RepositoryBase, IMenuRepository
    {
        public MenuRepository(CaritasContext db): base(db) { }
        public async Task<List<Menu>> List(int UserID)
        {
            IQueryable<Menu> menuInfo = from m in db.Menus
                                        join pm in db.Permission_Menus on m.Id equals pm.MenuId
                                        where pm.PermissionId == UserID
                                        select m;

            return await menuInfo.AsNoTracking().ToListAsync();


        }
    }
}
