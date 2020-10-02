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

        object GetUser(string nome);

        bool PostUsers(UserModel user);

        UserModel PutUser(UserModel user);

        void DeleteUsers(int id);
    }
}
