using Caritas.ServiceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.ServiceAPI.Repositories.Interfaces
{
    public interface IShelteredRepository
    {
        Task Add(ShelteredModel sheltered);
        Task<List<ShelteredModel>> List();
        Task<int> Commit();
        void Update(ShelteredModel sheltered);
        Task<ShelteredModel> FindShelteredToUpdate(int id);
        Task<ShelteredModel> FindShelteredAsync(int id);
        Entity SoftDelete<Entity>(Entity entity) where Entity : class;
    }
}
