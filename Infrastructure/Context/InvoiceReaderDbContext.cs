using Microsoft.EntityFrameworkCore;

public class InvoiceReaderDbContext : DbContext
{
  public InvoiceReaderDbContext(DbContextOptions<InvoiceReaderDbContext> options) : base(options) { }

  public DbSet<AccountType> TipoContas { get; set; }
}
