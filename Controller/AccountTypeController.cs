using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/TipoContas")]
[ApiController]
public class AccountTypeController : ControllerBase
{
  private readonly InvoiceReaderDbContext _context;

  public AccountTypeController(InvoiceReaderDbContext context)
  {
    _context = context;
  }

  [HttpGet]
  [Route("GetByUser")]
  public async Task<IActionResult> GetByUser(GetByUserRequest request)
  {
    GetByUserResponse response = [.. await _context.TipoContas.Where(it => it.usuario == request.usuario).ToListAsync()];

    return Ok(response);
  }

  [HttpGet]
  [Route("HealthCheck")]
  public void HealthChecksBuilderAddCheckExtensions()
  {
    _context.Database.OpenConnection();

    try
    {
      _context.Database.OpenConnection();
      Console.WriteLine("Conexão bem-sucedida!");
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Erro na conexão: {ex.Message}");
    }
  }
}