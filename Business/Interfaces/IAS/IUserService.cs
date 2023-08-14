namespace Business.Interfaces.IAS
{
    public interface IUserService<T, A>
    {
        Task<IEnumerable<T>> GetAll(int CompanyId);
        Task<T> GetById(int Id);
        Task<dynamic> Insert(A model);
        Task<dynamic> Update(A model);
        Task<dynamic> Delete(int Id);
    }
}
