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


        public async Task Add(ShelteredModel sheltered)
        {
            await db.Sheltereds.AddAsync(sheltered);
        }
        public async Task<List<ShelteredModel>> List()
        {
            return await db.Sheltereds.AsNoTracking().ToListAsync();
        }

        public void Update(ShelteredModel sheltered)
        {
            db.Sheltereds.Update(sheltered);
        }

        public async Task<ShelteredModel> FindShelteredToUpdate(int id)
        {
            return await db.Sheltereds
                .Where(q => q.Id == id)
                .Where(e => e.DeletedAt == null)
                .DefaultIfEmpty()
                .AsNoTracking()
                .FirstAsync();

        }

        public async Task<ShelteredModel> FindShelteredAsync(int id)
        {
            return await db.Sheltereds
                .Where(q => q.Id == id)
                .Where(e => e.DeletedAt == null)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
