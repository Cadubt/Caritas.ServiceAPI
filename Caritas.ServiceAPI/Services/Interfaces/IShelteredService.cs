using Caritas.ServiceAPI.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.ServiceAPI.Services.Interfaces
{
    public interface IShelteredService
    {
        
        Task<bool> Create(Sheltered sheltered);
        Task<bool> Update(Sheltered sheltered);
        Task<bool> Delete(int Id);
        Task<Sheltered> Find(int Id);
        Task<List<Sheltered>> List(int status, string approvalStatus);
        

    }
}
