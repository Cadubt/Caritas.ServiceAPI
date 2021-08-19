using Caritas.ServiceAPI.Context;
using Caritas.ServiceAPI.Context.Entities;
using Caritas.ServiceAPI.Helper;
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

        public async Task<List<User>> List()
        {
            List<User> u = new List<User>();
            u = await _userRepo.List();
            return u;
        }

        public async Task<bool> Update(User user)
        {
            try
            {
                _userRepo.Update(user);
                int changed = await _userRepo.Commit();

                if (changed > 0)
                    return true;

                return false;
            }
            catch (AppException ex)
            {
                throw new AppException(ex.Message, ex.Code);
            }
        }

        public async Task<User> Read(LoginModel loginModel)
        {
            User u = new User();
            u = await _userRepo.Read(loginModel);
            return u;
        }

        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUser(int Id)
        {
            User u = new User();
            u = await _userRepo.GetUser(Id);
            return u;
        }
    }
}
