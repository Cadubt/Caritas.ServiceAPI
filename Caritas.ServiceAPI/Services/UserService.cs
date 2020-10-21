using Caritas.ServiceAPI.Context;
using Caritas.ServiceAPI.Models;
using Caritas.ServiceAPI.Repositories.Interfaces;
using Caritas.ServiceAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.ServiceAPI.Services
{
    public class UserService : IUserService
    {
        private IConfiguration _config { get; set; }
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo, IConfiguration config)
        {
            _userRepo = userRepo;
            _config = config;
        }

        public async Task<List<UserModel>> List()
        {
            List<UserModel> u = new List<UserModel>();
            u = await _userRepo.List();
            return u;
        }

        //public object GetUser(string nome)
        //{
        //    var userFound = from user in _context.Users where user.Name == nome select user;
        //    return userFound;
        //}

        //public bool PostUsers(UserModel user)
        //{
        //    if (user == null)
        //        return false;

        //    var createdUser = new UserModel
        //    {
        //        Name = user.Name,
        //        Email = user.Email,
        //        Password = user.Password,
        //        Role = user.Role
        //    };

        //    _context.Users.Update(createdUser);
        //    _context.SaveChanges();

        //    return true;
        //}

        //public UserModel PutUser(UserModel user)
        //{
        //    var userFound = _context.Users.AsNoTracking().FirstOrDefault(
        //            u => u.Id == user.Id);

        //    if (userFound == null)
        //        return userFound;

        //    _context.Users.Update(user);
        //    _context.SaveChanges();
        //    return user;
        //}

        //public void DeleteUsers(int id)
        //{
        //    var user = _context.Users.Where(u => u.Id == id).Single();

        //    _context.Users.Remove(user);
        //    _context.SaveChanges();
        //}
    }
}
