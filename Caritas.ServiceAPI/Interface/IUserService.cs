using Caritas.ServiceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.ServiceAPI.Interface
{
    public interface IUserService
    {
        List<UserModel> GetUsers();
    }
}
