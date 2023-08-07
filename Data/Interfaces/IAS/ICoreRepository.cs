using Data.Models.IAS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models.Entities;

namespace Data.Interfaces.IAS
{
    public interface ICoreRepository<T> where T : EntityBase
    {
        Task<IEnumerable<T>> GetAll(int companyId);
        Task<T> GetById(int companyId, int Id);
        void Insert(T model);
        void Update(T model);
        void Delete(T model);
        void Save();
    }
}
