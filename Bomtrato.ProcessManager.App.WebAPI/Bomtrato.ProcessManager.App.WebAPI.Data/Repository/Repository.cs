using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bomtrato.ProcessManager.App.WebAPI.Data.Context;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Domain;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bomtrato.ProcessManager.App.WebAPI.Data.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : Entity, new()
    {
        protected readonly ApplicationDbContext DbContext;
        protected readonly DbSet<T> DbSet;

        public Repository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<T>();
        }

        public virtual async Task<T> Get(Guid id)
        {
           var response = await DbSet.FindAsync(id);
           return response;
        }

        public virtual async Task<List<T>> GetAll()
        {
           var items = await DbSet.ToListAsync();
           return items;           
        }

        public virtual async Task<bool> Add(T entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
            return true;            
        }


        public virtual async Task<bool> Delete(Guid id)
        {
            var entity = new T() { Id = id };
            DbSet.Remove(entity);
            await SaveChanges();
            return true;            
        }      

        public virtual async Task<T> Update(T entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
            return entity;           
        }     
        public async Task<int> SaveChanges() =>
            await DbContext.SaveChangesAsync();
        

        public void Dispose()
        {
            DbContext?.Dispose();
        }        
    }
}