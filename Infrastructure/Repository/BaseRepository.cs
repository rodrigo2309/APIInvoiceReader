public class BaseRepository<T> : IBaseRepository<T>
{
  private readonly InvoiceReaderDbContext_MySQL _context;

  public BaseRepository(InvoiceReaderDbContext_MySQL context)
  {
    _context = context;
  }
  public virtual async Task<T> Create(T obj)
  {
    if (obj != null)
    {
      await _context.AddAsync(obj);
      await _context.SaveChangesAsync();
    }
    return obj;
  }
  public void Update(T obj)
  {
    try
    {
      if (obj != null)
      {
        _context.Update(obj);
        _context.SaveChangesAsync();
      }
    }
    catch (Exception ex)
    {
      throw new("erro" + ex.Message);
    }
  }
  public void Delete(T obj)
  {
    try
    {
      if (obj != null)
      {
        _context.Remove(obj);

        _context.SaveChangesAsync();

      }
    }
    catch (Exception ex)
    {
      throw new("Erro " + ex.Message);
    }
  }
}