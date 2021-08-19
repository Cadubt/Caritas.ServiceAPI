using Caritas.ServiceAPI.Context;
using Caritas.ServiceAPI.Context.Entities;
using Caritas.ServiceAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.ServiceAPI.Repositories
{
    public class ScheduleSheetRepository : RepositoryBase, IScheduleSheetRepository
    {
        public ScheduleSheetRepository(CaritasContext db) : base(db) { }

        public async Task Add(ScheduleSheet sheltered)
        {
            await db.ScheduleSheets.AddAsync(sheltered);
        }

        public async Task<List<ScheduleSheet>> List()
        {
            return await db.ScheduleSheets
                .AsNoTracking()
                .Where((s => s.DeletedAt == null))
                .ToListAsync();
        }
    }
}
