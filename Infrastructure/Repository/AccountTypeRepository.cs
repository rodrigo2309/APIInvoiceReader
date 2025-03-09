using Microsoft.EntityFrameworkCore;

public class AccountTypeRepository : BaseRepository<AccountType>, IAccountTypeRepository
{
  private readonly InvoiceReaderDbContext _context;
  public AccountTypeRepository(InvoiceReaderDbContext context) : base(context)
  {
    _context = context;
  }

  public async Task<List<AccountType>> GetByUser(string usuario)
  {
    return await _context.TipoContas.Where(it => it.usuario == usuario).ToListAsync();
  }
  public async Task<AccountType> GetById(int id)
  {
    return await _context.TipoContas.FirstAsync(it => it.id == id);
  }
  public async Task<AccountType> GetByNome(string nome)
  {
    return await _context.TipoContas.FirstAsync(it => it.nome == nome);
  }
}