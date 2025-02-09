using Microsoft.AspNetCore.Mvc;

[Route("api/TipoContas")]
[ApiController]
public class AccountTypeController : ControllerBase
{
  private readonly IAccountTypeService _accountTypeService;

  public AccountTypeController(IAccountTypeService accountTypeService)
  {
    this._accountTypeService = accountTypeService;
  }

  [HttpGet]
  [Route("GetByUser")]
  public async Task<IActionResult> GetByUser(GetByUserRequest request)
  {
    return Ok(await this._accountTypeService.GetByUser(request).ConfigureAwait(false));
  }

  [HttpPost]
  [Route("Insert")]
  public async Task<IActionResult> Create(CreateRequest request)
  {
    var response = await this._accountTypeService.Create(request).ConfigureAwait(false);

    return Ok(response);
  }

  [HttpPost]
  [Route("Update")]
  public async Task<IActionResult> Update(AccountType request)
  {
    var response = await this._accountTypeService.Update(request).ConfigureAwait(false);

    return Ok(response);
  }

  [HttpPost]
  [Route("Delete")]
  public async Task<IActionResult> Delete(int id)
  {
    var response = await this._accountTypeService.Delete(id).ConfigureAwait(false);

    return Ok(response);
  }

  // [HttpGet]
  // [Route("HealthCheck")]
  // public void HealthChecksBuilderAddCheckExtensions()
  // {
  //   _context.Database.OpenConnection();

  //   try
  //   {
  //     _context.Database.OpenConnection();
  //     Console.WriteLine("Conexão bem-sucedida!");
  //   }
  //   catch (Exception ex)
  //   {
  //     Console.WriteLine($"Erro na conexão: {ex.Message}");
  //   }
  // }
}