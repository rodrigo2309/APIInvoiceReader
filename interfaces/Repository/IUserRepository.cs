public interface IUserRepository : IBaseRepository<User>
{
  Task<User> Get(string username, string password);
}