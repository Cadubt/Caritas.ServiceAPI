using Caritas.ServiceAPI.Context.Entities;
using Caritas.ServiceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.ServiceAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> List();

        Task<User> Read(LoginModel loginModel);
    }
}
