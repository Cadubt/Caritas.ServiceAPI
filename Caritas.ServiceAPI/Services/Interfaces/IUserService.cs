using Caritas.ServiceAPI.Context.Entities;
using Caritas.ServiceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.ServiceAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> List();

        Task<User> Read(LoginModel loginModel);

        Task<bool> Update(User user);

        Task<bool> Delete(int Id);

    }
}
