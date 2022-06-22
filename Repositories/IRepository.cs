using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiccarCodeTest.Repositories
{
    public interface IRepository<TData>
    {
        public Task<List<TData>> GetAll();
        public Task<TData> GetById(string id);
        public Task InsertOrUpdate(object key, TData data);
    }
}
