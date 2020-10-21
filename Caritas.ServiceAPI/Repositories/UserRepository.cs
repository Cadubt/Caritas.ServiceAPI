using Caritas.ServiceAPI.Context;
using Caritas.ServiceAPI.Models;
using Caritas.ServiceAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.ServiceAPI.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public UserRepository(CaritasContext db) : base(db) { }

        public async Task<List<UserModel>> List()
        {            
            return await db.Users.AsNoTracking().ToListAsync(); ;
        }
    }
}
