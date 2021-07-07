using Caritas.ServiceAPI.Context;
using Caritas.ServiceAPI.Context.Entities;
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

        public async Task<List<User>> List()
        {
            return await db.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User> Read(LoginModel loginModel)
        {
            return await db.Users.AsNoTracking()
                .Where(e => e.Email == loginModel.Email)
                .Where(e => e.Password == loginModel.Password)
                .DefaultIfEmpty()
                .AsNoTracking()
                .FirstAsync();
        }

        public void Update(User user)
        {
            db.Users.Update(user);
        }
    }
}
