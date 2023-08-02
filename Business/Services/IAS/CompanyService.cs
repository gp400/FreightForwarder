using Business.DTOs.IAS;
using Business.Interfaces.IAS;
using Data.Models.IAS;
using Data.Repositories.IAS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.IAS
{
    public class CompanyService : ICoreService<Company, CompanyDto>
    {

        public readonly CompanyRepository repository;

        public CompanyService()
        {
            repository = new CompanyRepository();
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            return await repository.GetAll();
        }

        public async Task<Company> GetById(int Id)
        {
            return await repository.GetById(Id);
        }

        public async Task<dynamic> Insert(CompanyDto model)
        {
            var errors = validator(model);

            if (errors.Any())
                return errors;

            var company = new Company
            {
                Name = model.Name,
                Rnc = model.Rnc,
                Email = model.Email,
                Logo = model.Logo,
                Address = model.Address,
                Phone = model.Phone,
                CreatedBy = model.UserId
            };

            repository.Insert(company);

            repository.Save();

            return company;
        }

        public async Task<dynamic> Update(CompanyDto model)
        {
            var errors = validator(model);

            if (errors.Any())
                return errors;

            var company = await this.GetById(model.Id);

            company.Id = model.Id;
            company.Name = model.Name;
            company.Rnc = model.Rnc;
            company.Email = model.Email;
            company.Logo = model.Logo;
            company.Address = model.Address;
            company.Phone = model.Phone;
            company.UpdatedBy = model.UserId;

            repository.Update(company);

            repository.Save();

            return company;
        }

        public async void Delete(int Id)
        {
            var company = await this.GetById(Id);

            repository.Delete(company);

            repository.Save();
        }

        private List<string> validator(CompanyDto companyDto)
        {
            var errors = new List<string>();

            using (var context = new IasContext())
            {
                if (context.Companies.Any(c => c.Rnc.ToLower() == companyDto.Rnc.ToLower() && c.Active && c.Id != companyDto.Id))
                {
                    errors.Add("Ya existe una empresa con ese RNC");
                }
            }

            return errors;
        }
    }
}
