using Microsoft.EntityFrameworkCore;

public class UserRepository : BaseRepository<User>, IUserRepository
{
  private readonly InvoiceReaderDbContext _context;
  public UserRepository(InvoiceReaderDbContext context) : base(context)
  {
    _context = context;
  }
  public async Task<User> Get(string username, string password)
  {
    return await _context.Users.FirstOrDefaultAsync(it => it.Username == username && it.Password == password);
  }
}