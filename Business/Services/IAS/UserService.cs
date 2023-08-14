using Business.DTOs.IAS;
using Business.Interfaces.IAS;
using Data.Models.IAS;
using Data.Repositories.IAS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.IAS
{
    public class UserService : IUserService<Usr100, UserDto>
    {
        private readonly UserRepository repository;

        public UserService()
        {
            repository = new UserRepository();
        }

        public async Task<IEnumerable<Usr100>> GetAll(int CompanyId)
        {
            return await repository.GetAll(CompanyId);
        }

        public async Task<Usr100> GetById(int Id)
        {
            return await repository.GetById(Id);
        }

        public async Task<dynamic> Insert(UserDto model)
        {
            var errors = await validator(model);

            if (errors.Any())
                return new { code = 409, response = errors };

            var user = new Usr100
            {
                Name = model.Name,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                Email = model.Email,
                Picture = model.Picture,
                Observations = model.Observations,
                PasswordExpires = model.PasswordExpires,
                CreatedBy = model.UserId
            };

            foreach(var company in model.Companies)
            {
                user.CompanyUsr100s.Add(new CompanyUsr100
                {
                    CompanyId = company,
                    CreatedBy = model.UserId,
                    CreatedDate = DateTime.Now,
                    Active = true
                });
            }

            await repository.Insert(user);

            await repository.Save();

            return new { code = 200, response = user };
        }

        public async Task<dynamic> Update(UserDto model)
        {
            var user = await this.GetById(model.Id);

            if (user == null)
                return new { code = 404, response = new List<string> { "The User was not found" } };

            var errors = await validator(model);

            if (errors.Any())
                return new { code = 409, response = errors };

            user.Id = model.Id;
            user.Name = model.Name;
            user.MiddleName = model.MiddleName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.Picture = model.Picture;
            user.Observations = model.Observations;
            user.PasswordExpires = model.PasswordExpires;
            user.UpdatedBy = model.UserId;

            var companies = user.CompanyUsr100s.Select(c => c.Id).ToList();

            foreach (var company in model.Companies)
            {
                user.CompanyUsr100s.Add(new CompanyUsr100
                {
                    CompanyId = company,
                    CreatedBy = model.UserId,
                    CreatedDate = DateTime.Now,
                    Active = true
                });
            }

            repository.Update(user, companies);

            await repository.Save();

            return new { code = 200, response = user };
        }

        public async Task<dynamic> Delete(int Id)
        {
            var user = await this.GetById(Id);

            if (user == null)
                return new { code = 404, response = new List<string> { "The User was not found" } };

            repository.Delete(user);

            await repository.Save();

            return new { code = 200, response = user };
        }

        private async Task<List<string>> validator(UserDto userDto)
        {
            var errors = new List<string>();

            using (var context = new IASContext())
            {
                var invalid = await context.CompanyUsr100s.Where(u => u.Usr100.Id != userDto.Id && u.Usr100.Email.ToLower() == userDto.Email.ToLower() && u.Active && userDto.Companies.Contains(u.CompanyId))
                                .Select(c => c.CompanyId).ToListAsync();

                if (invalid.Any())
                {
                    errors.Add($"There is these companies: {String.Join(", ", invalid.ToArray())}");
                }
            }

            return errors;
        }
    }
}
