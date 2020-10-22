using Caritas.ServiceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.ServiceAPI.Services.Interfaces
{
    public interface IShelteredService
    {
        
        Task<bool> Create(ShelteredModel sheltered);
        Task<bool> Update(ShelteredModel sheltered);
        Task<bool> Delete(int Id);
        Task<ShelteredModel> Find(int Id);
        Task<List<ShelteredModel>> List(bool aliveOnly, bool activeOnly);
        

    }
}
