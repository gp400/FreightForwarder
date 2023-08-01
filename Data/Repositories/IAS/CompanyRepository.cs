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
            return await context.Companies.AsNoTracking().ToListAsync();
        }

        public async Task<Company> GetById(int Id)
        {
            return await context.Companies.FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async void Insert(Company model)
        {
            model.CreatedDate = new DateTime();
            model.Active = true;
            await context.AddAsync(model);
        }

        public void Update(Company model)
        {
            model.UpdatedDate = new DateTime();
            context.Update(model);
        }

        public async void Delete(int Id)
        {
            var company = await this.GetById(Id);
            company.Active = false;
            company.UpdatedDate = new DateTime();
        }

        public async void Save()
        {
            await context.SaveChangesAsync();
        }
    }
}
