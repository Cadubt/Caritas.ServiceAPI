using Caritas.ServiceAPI.Context;
using Caritas.ServiceAPI.Interface;
using Caritas.ServiceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.ServiceAPI.Services
{
    public class UserService : IUserService
    {
        public readonly CaritasContext _context;

        public UserService(CaritasContext context)
        {
            _context = context;
        }

        public List<UserModel> GetUsers()
        {
            List<UserModel> u = new List<UserModel>();
            u = _context.Users.ToList();
            return u;
        }
    }
}
