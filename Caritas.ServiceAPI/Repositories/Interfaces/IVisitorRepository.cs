using Caritas.ServiceAPI.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.ServiceAPI.Repositories.Interfaces
{
    public interface IVisitorRepository
    {
        Task<List<Visitor>> List();
        Task<List<Visitor>> ListByDate(string visitDate);

        Task Add(Visitor visitor);

        Task<int> Commit();
    }
}
