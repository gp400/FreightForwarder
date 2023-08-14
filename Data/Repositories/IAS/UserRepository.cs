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
    public class UserRepository: IUserRepository
    {
        private readonly IASContext context;

        public UserRepository()
        {
            context = new IASContext();
        }

        public UserRepository(IASContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<Usr100>> GetAll(int companyId)
        {
            return await context.CompanyUsr100s.AsNoTracking().Where(c => c.Usr100.Active 
                                                                    && c.Company.Active 
                                                                    && c.CompanyId == companyId)
                                                                    .Include(c => c.Usr100)
                                                                    .Select(c => c.Usr100)
                                                                    .ToListAsync();
        }

        public async Task<Usr100> GetById( int Id)
        {
            return await context.Usr100s.AsNoTracking()
                                        .Include(u => u.CompanyUsr100s.Where(c => c.Active))
                                        .FirstOrDefaultAsync(u => u.Id == Id && u.Active);
        }

        public async Task Insert(Usr100 model)
        {
            model.CreatedDate = DateTime.Now;
            model.Active = true;
            await context.AddAsync(model);
        }

        public void Update(Usr100 model, List<int> companies)
        {
            //Termina esta vaina
            context.RemoveRange(companies);
            model.UpdatedDate = DateTime.Now;
            context.Update(model);
        }

        public void Delete(Usr100 model)
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
