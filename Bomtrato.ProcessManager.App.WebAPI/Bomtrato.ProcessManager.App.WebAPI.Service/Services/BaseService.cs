using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Domain;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Interfaces.Repositories;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Interfaces.Services;

namespace Bomtrato.ProcessManager.App.WebAPI.Service.Services
{
    public abstract class BaseService<T> : IBaseService<T> where T : Entity
    {
        protected readonly IRepository<T> _repository;

        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<bool> Add(T entity)
        {
            var response = await _repository.Add(entity);
            return response;
        }

        public virtual async Task<bool> Delete(Guid id)
        {
            var response = await _repository.Delete(id);
            return response;
        }

        public virtual async Task<List<T>> GetAll()
        {
            var response = await _repository.GetAll();
            return response;
        }

        public virtual async Task<T> Get(Guid id)
        {
            var response = await _repository.Get(id);
            return response;
        }

        public virtual async Task<T> Update(T entity)
        {
            var response = await _repository.Update(entity);
            return response;
        }
    }
}