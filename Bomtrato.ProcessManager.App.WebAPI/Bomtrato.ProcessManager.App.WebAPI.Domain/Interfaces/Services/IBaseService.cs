using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Domain;

namespace Bomtrato.ProcessManager.App.WebAPI.Domain.Interfaces.Services
{
    public interface IBaseService<T> where T : Entity
    {
         Task<bool> Add(T entity);
         Task<T> Get(Guid id);
         Task<List<T>> GetAll();
         Task<bool> Delete(Guid id);
         Task<T> Update(T entity);
    }
}