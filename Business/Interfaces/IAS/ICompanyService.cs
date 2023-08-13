using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.IAS
{
    public interface ICompanyService<T, A>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int Id);
        Task<dynamic> Insert(A model);
        Task<dynamic> Update(A model);
        Task<dynamic> Delete(int Id);
    }
}
