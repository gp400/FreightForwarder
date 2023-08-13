using Data.Models.IAS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces.IAS
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAll();
        Task<Company> GetById(int Id);
        Task Insert(Company model);
        void Update(Company model);
        void Delete(Company model);
        Task Save();
    }
}