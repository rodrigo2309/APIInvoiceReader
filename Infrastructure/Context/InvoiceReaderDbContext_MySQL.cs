using Microsoft.EntityFrameworkCore;

public class InvoiceReaderDbContext_MySQL : DbContext
{
  public InvoiceReaderDbContext_MySQL(DbContextOptions<InvoiceReaderDbContext_MySQL> options) : base(options) { }

  public DbSet<AccountType> TipoContas { get; set; }
}