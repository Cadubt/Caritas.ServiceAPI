using Caritas.ServiceAPI.Context;
using Caritas.ServiceAPI.Models;
using Caritas.ServiceAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.ServiceAPI.Repositories
{
    public class ShelteredRepository : RepositoryBase, IShelteredRepository
    {
        public ShelteredRepository(CaritasContext db) : base(db) { }

        public async Task<List<ShelteredModel>> List()
        {
            return await db.Sheltereds.AsNoTracking().ToListAsync(); ;
        }
    }
}
