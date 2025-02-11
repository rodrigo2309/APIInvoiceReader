public interface IAccountTypeRepository : IBaseRepository<AccountType>
{
  Task<List<AccountType>> GetByUser(string user);
  Task<AccountType> GetById(int id);
  Task<AccountType> GetByNome(string nome);
}