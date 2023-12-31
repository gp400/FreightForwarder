﻿namespace Business.Interfaces.IAS
{
    public interface ICoreService<T, A>
    {
        Task<IEnumerable<T>> GetAll(int CompanyId);
        Task<T> GetById(int CompanyId, int Id);
        Task<dynamic> Insert(A model);
        Task<dynamic> Update(A model);
        Task<dynamic> Delete(int CompanyId, int Id);
    }
}
