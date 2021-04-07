using Caritas.ServiceAPI.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.ServiceAPI.Repositories.Interfaces
{
    public interface IScheduleSheetRepository
    {
        Task<List<ScheduleSheet>> List();
        Task Add(ScheduleSheet sheltered);
        Task<int> Commit();
    }
}
