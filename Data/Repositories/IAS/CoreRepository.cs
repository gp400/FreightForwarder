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
    public class CoreRepository<T> : ICoreRepository<T> where T : class
    {
        private readonly IASContext context;

        public CoreRepository()
        {
            context = new IASContext();
        }

        public CoreRepository(IASContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<T>> GetAll(int companyId)
        {
            return await context.Set<T>().AsNoTracking().Where(m => (bool)m.GetType().GetProperty("Active").GetValue(m) == true
                                                                && (int)m.GetType().GetProperty("CompanyId").GetValue(m) == companyId).ToListAsync();
        }

        public async Task<T> GetById(int companyId, int Id)
        {
            return await context.Set<T>().AsNoTracking().FirstOrDefaultAsync(m => (bool)m.GetType().GetProperty("Active").GetValue(m) == true
                                                                            && (int)m.GetType().GetProperty("CompanyId").GetValue(m) == companyId
                                                                            && (int)m.GetType().GetProperty("Id").GetValue(m) == Id);
        }

        public async Task Insert(T model)
        {
            model.GetType().GetProperty("CreatedDate").SetValue(model, DateTime.Now);
            model.GetType().GetProperty("Active").SetValue(model, true);
            await context.Set<T>().AddAsync(model);
        }

        public void Update(T model)
        {
            model.GetType().GetProperty("UpdatedDate").SetValue(model, DateTime.Now);
            context.Update(model);
        }

        public void Delete(T model)
        {
            model.GetType().GetProperty("UpdatedDate").SetValue(model, DateTime.Now);
            model.GetType().GetProperty("Active").SetValue(model, false);
            context.Update(model);
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}
