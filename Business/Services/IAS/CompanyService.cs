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
                return new { code = 409, response = errors };

            var company = new Company
            {
                BusinessName = model.BusinessName,
                Tradename = model.Tradename,
                BaseCurrency = model.BaseCurrency,
                DefaultCurrency = model.DefaultCurrency,
                DefaultTaxGroup = model.DefaultTaxGroup,
                DefaultPriceLevel = model.DefaultPriceLevel,
                Rnc = model.Rnc,
                TaxRegime = model.TaxRegime,
                Country = model.Country,
                Phone = model.Phone,
                AltPhone = model.AltPhone,
                Fax = model.Fax,
                Email = model.Email,
                Website = model.Website,
                Facebook = model.Facebook,
                Twitter = model.Twitter,
                YouTube = model.YouTube,
                Instagram = model.Instagram,
                Address = model.Address,
                Address2 = model.Address2,
                City = model.City,
                State = model.State,
                PostalCode = model.PostalCode,
                Logo = model.Logo,
                Slogan = model.Slogan,
                InvoicesNotes = model.InvoicesNotes,
                FirstMonthFiscalYear = model.FirstMonthFiscalYear,
                DateFormat = model.DateFormat,
                TimeZone = model.TimeZone,
                NativePrintFormat = model.NativePrintFormat,
                CreatedBy = model.UserId
            };

            repository.Insert(company);

            repository.Save();

            return new { code = 200, response = company };
        }

        public async Task<dynamic> Update(CompanyDto model)
        {
            var company = await this.GetById(model.Id);

            if (company == null)
                return new { code = 404, response = new List<string> { "The Company was not found" } };

            var errors = validator(model);

            if (errors.Any())
                return new { code = 409, response = errors };

            
            company.Id = model.Id;
            company.BusinessName = model.BusinessName;
            company.Tradename = model.Tradename;
            company.BaseCurrency = model.BaseCurrency;
            company.DefaultCurrency = model.DefaultCurrency;
            company.DefaultTaxGroup = model.DefaultTaxGroup;
            company.DefaultPriceLevel = model.DefaultPriceLevel;
            company.Rnc = model.Rnc;
            company.TaxRegime = model.TaxRegime;
            company.Country = model.Country;
            company.Phone = model.Phone;
            company.AltPhone = model.AltPhone;
            company.Fax = model.Fax;
            company.Email = model.Email;
            company.Website = model.Website;
            company.Facebook = model.Facebook;
            company.Twitter = model.Twitter;
            company.YouTube = model.YouTube;
            company.Instagram = model.Instagram;
            company.Address = model.Address;
            company.Address2 = model.Address2;
            company.City = model.City;
            company.State = model.State;
            company.PostalCode = model.PostalCode;
            company.Logo = model.Logo;
            company.Slogan = model.Slogan;
            company.InvoicesNotes = model.InvoicesNotes;
            company.FirstMonthFiscalYear = model.FirstMonthFiscalYear;
            company.DateFormat = model.DateFormat;
            company.TimeZone = model.TimeZone;
            company.NativePrintFormat = model.NativePrintFormat;
            company.UpdatedBy = model.UserId;

            repository.Update(company);

            repository.Save();

            return new { code = 200, response = company };
        }

        public async Task<dynamic> Delete(int Id)
        {
            var company = await this.GetById(Id);

            if (company == null)
                return new { code = 404, response = new List<string> { "The Company was not found" } };

            repository.Delete(company);

            repository.Save();

            return new { code = 200, response = company };
        }

        private List<string> validator(CompanyDto companyDto)
        {
            var errors = new List<string>();

            using (var context = new IasContext())
            {
                if (context.Companies.Any(c => c.Rnc.ToLower() == companyDto.Rnc.ToLower() && c.Active && c.Id != companyDto.Id))
                {
                    errors.Add("There is a company with that RNC");
                }
                if (context.Companies.Any(c => c.BusinessName.ToLower() == companyDto.BusinessName.ToLower() && c.Active && c.Id != companyDto.Id))
                {
                    errors.Add("There is a company with that Business Name");
                }
            }

            return errors;
        }
    }
}
