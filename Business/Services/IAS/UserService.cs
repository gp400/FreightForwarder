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
    public class UserService : ICoreService<Usr100, UserDto>
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

        public Task<Usr100> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<dynamic> Insert(UserDto model)
        {
            throw new NotImplementedException();
        }

        public Task<dynamic> Update(UserDto model)
        {
            throw new NotImplementedException();
        }

        public Task<dynamic> Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
