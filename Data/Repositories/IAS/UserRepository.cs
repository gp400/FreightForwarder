using Data.Interfaces.IAS;
using Data.Models.IAS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IAS
{
    public class UserRepository
    {
        private readonly IasContext context;

        public UserRepository()
        {
            context = new IasContext();
        }

        public UserRepository(IasContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<Usr100>> GetAll(int companyId)
        {
            var users = await context.CompanyUsr100s.AsNoTracking().Where(c => c.Usr100.Active 
                                                                    && c.Company.Active 
                                                                    && c.CompanyId == companyId)
                                                                    .Include(c => c.Usr100)
                                                                    .Select(c => c.Usr100)
                                                                    .ToListAsync();

            return users;
        }

        public Task<Usr100> GetById(int companyId, int Id)
        {
            throw new NotImplementedException();
        }

        public async Task Insert(Usr100 model)
        {
            throw new NotImplementedException();
        }

        public void Update(Usr100 model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Usr100 model)
        {
            throw new NotImplementedException();
        }

        public async Task Save()
        {
            throw new NotImplementedException();
        }
    }
}
