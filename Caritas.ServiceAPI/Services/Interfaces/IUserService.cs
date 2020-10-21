using Caritas.ServiceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.ServiceAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserModel>> List();

    }
}
