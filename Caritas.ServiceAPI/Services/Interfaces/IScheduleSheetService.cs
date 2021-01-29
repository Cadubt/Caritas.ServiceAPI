using Caritas.ServiceAPI.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.ServiceAPI.Services.Interfaces
{
    public interface IScheduleSheetService
    {
        Task<List<ScheduleSheet>> List();
    }
}
