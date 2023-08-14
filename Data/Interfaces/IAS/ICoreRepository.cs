using Data.Models.IAS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces.IAS
{
    public interface ICoreRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(int companyId);
        Task<T> GetById(int companyId, int Id);
        Task Insert(T model);
        void Update(T model);
        void Delete(T model);
        Task Save();
    }
}
