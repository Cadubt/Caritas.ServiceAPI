using Caritas.ServiceAPI.Context;
using Caritas.ServiceAPI.Interface;
using Caritas.ServiceAPI.Models;
using Microsoft.EntityFrameworkCore;
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

        public object GetUser(string nome)
        {
            var userFound = from user in _context.Users where user.Name == nome select user;
            return userFound;
        }

        public bool PostUsers(UserModel user)
        {
            if (user == null)
                return false;

            var createdUser = new UserModel
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role
            };

            _context.Users.Update(createdUser);
            _context.SaveChanges();

            return true;
        }

        public UserModel PutUser(UserModel user)
        {
            var userFound = _context.Users.AsNoTracking().FirstOrDefault(
                    u => u.Id == user.Id);

            if (userFound == null)
                return userFound;

            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }

        public void DeleteUsers(int id)
        {
            var user = _context.Users.Where(u => u.Id == id).Single();

            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
