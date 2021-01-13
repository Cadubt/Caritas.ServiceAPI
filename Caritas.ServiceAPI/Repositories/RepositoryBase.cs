using Caritas.ServiceAPI.Context;
using Caritas.ServiceAPI.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Caritas.ServiceAPI.Repositories
{
    public class RepositoryBase
    {
        protected readonly CaritasContext db;

        public RepositoryBase(CaritasContext db)
        {
            this.db = db;
        }

        public Task<int> Commit()
        {
            return db.SaveChangesAsync();
        }

        public Entity SoftDelete<Entity>(Entity entity) where Entity : class
        {
            try
            {
                #region O que eu Faria ao invez de Deletar [Descomentar]
                Type entityType = entity.GetType();

                if (entityType.GetProperty("DeletedAt") == null)
                {
                    throw new AppException("The entity has no DeletedAt property");
                }
                else
                {
                    PropertyInfo deletedAt = entityType.GetProperty("DeletedAt");
                    deletedAt.SetValue(entity, DateTime.UtcNow);
                }

                db.Update(entity);
                db.Entry(entity).State = EntityState.Modified;

                if (entityType.GetProperty("CreatedAt") != null)
                {
                    db.Entry(entity).Property(entityType.GetProperty("CreatedAt").Name).IsModified = false;
                }

                if (entityType.GetProperty("UpdatedAt") != null)
                {
                    db.Entry(entity).Property(entityType.GetProperty("UpdatedAt").Name).IsModified = false;
                }

                return entity;
                #endregion

                #region Como foi pedido

                //db.Remove(entity);
                //db.SaveChanges();

                //return entity;

                #endregion
            }
            catch (AppException ex)
            {
                throw ex;
            }
        }
    }
}
