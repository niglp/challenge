using SiccarCodeTest.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiccarCodeTest.Repositories
{
    public class InMemoryRepo<TData> : IRepository<TData>
    {
        public Dictionary<object, TData> repository;

        public InMemoryRepo()
        {
            repository = new Dictionary<object, TData>();
        }

        public Task InsertOrUpdate(object key, TData data)
        {
            if (!repository.ContainsKey(key))
            {
                repository.Add(key, data);
            }
            else
            {
                repository.Remove(key);
                repository.Add(key, data);
            }

            return Task.CompletedTask;
        }

        public Task<List<TData>> GetAll()
        {
            return Task.FromResult(repository.Values.ToList());
        }

        public Task<TData> GetById(string key)
        {
            if (!repository.ContainsKey(key)) throw new InMemoryRepoException($"Data cannot be retrieved. Key: {key} does not exist in the repository");

            return Task.FromResult(repository[key]);
        }
    }
}
