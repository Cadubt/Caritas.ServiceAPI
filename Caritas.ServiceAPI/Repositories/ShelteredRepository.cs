using Caritas.ServiceAPI.Context;
using Caritas.ServiceAPI.Context.Entities;
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


        public async Task Add(Sheltered sheltered)
        {
            await db.Sheltereds.AddAsync(sheltered);
        }
        public async Task<List<Sheltered>> List(int status, string approvalStatus)
        {
            return await db.Sheltereds
                .AsNoTracking()
                .Where(s => s.StatusId == status)
                .Where(s => s.DeletedAt == null)
                .Where(s => s.ApprovalStatus.ToUpper() == approvalStatus)
                .ToListAsync();
        }

        public void Update(Sheltered sheltered)
        {
            db.Sheltereds.Update(sheltered);
        }

        public async Task<Sheltered> FindShelteredToUpdate(int id)
        {
            return await db.Sheltereds
                .Where(q => q.Id == id)
                .Where(e => e.DeletedAt == null)
                .DefaultIfEmpty()
                .AsNoTracking()
                .FirstAsync();
        }

        public async Task<Sheltered> FindShelteredAsync(int id)
        {
            return await db.Sheltereds
                .Where(q => q.Id == id)
                .Where(e => e.DeletedAt == null)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
