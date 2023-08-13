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
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IasContext context;

        public CompanyRepository()
        {
            context = new IasContext();
        }

        public CompanyRepository(IasContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            return await context.Companies.AsNoTracking().Where(c => c.Active).ToListAsync();
        }

        public async Task<Company> GetById(int Id)
        {
            return await context.Companies.AsNoTracking().FirstOrDefaultAsync(c => c.Id == Id && c.Active);
        }

        public async Task Insert(Company model)
        {
            model.CreatedDate = DateTime.Now;
            model.Active = true;
            await context.AddAsync(model);
        }

        public void Update(Company model)
        {
            model.UpdatedDate = DateTime.Now;
            context.Update(model);
        }

        public void Delete(Company model)
        {
            model.Active = false;
            model.UpdatedDate = DateTime.Now;
            context.Update(model);
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}