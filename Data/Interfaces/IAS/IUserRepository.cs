using Data.Models.IAS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces.IAS
{
    public interface IUserRepository
    {
        Task<IEnumerable<Usr100>> GetAll(int companyId);
        Task<Usr100> GetById(int Id);
        Task Insert(Usr100 model);
        void Update(Usr100 model);
        void Delete(Usr100 model);
        Task Save();
    }
}
