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
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public UserRepository(CaritasContext db) : base(db) { }

        public async Task<List<User>> List()
        {            
            return await db.Users.AsNoTracking().ToListAsync(); ;
        }
    }
}
