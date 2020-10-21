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
    }
}
