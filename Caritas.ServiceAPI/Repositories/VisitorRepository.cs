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
    public class VisitorRepository : RepositoryBase, IVisitorRepository
    {
        public VisitorRepository(CaritasContext db) : base(db) { }

        public async Task<List<Visitor>> List()
        {
            return await db.Visitors.AsNoTracking().ToListAsync();
        }

        public async Task<List<Visitor>> ListByDate(string visitDate)
        {
            IQueryable<Visitor> visitors = from v in db.Visitors
                                           where v.VisitDate.ToString("MM/dd/yyyy") == visitDate
                                           select v;

            return await visitors.AsNoTracking().ToListAsync();
        }
    }
}
