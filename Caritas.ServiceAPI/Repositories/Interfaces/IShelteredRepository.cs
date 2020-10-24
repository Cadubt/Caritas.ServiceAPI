using Caritas.ServiceAPI.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.ServiceAPI.Repositories.Interfaces
{
    public interface IShelteredRepository
    {
        Task Add(Sheltered sheltered);
        Task<List<Sheltered>> List(int status);
        Task<int> Commit();
        void Update(Sheltered sheltered);
        Task<Sheltered> FindShelteredToUpdate(int id);
        Task<Sheltered> FindShelteredAsync(int id);
        Entity SoftDelete<Entity>(Entity entity) where Entity : class;
    }
}
