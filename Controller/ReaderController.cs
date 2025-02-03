using APIInvoiceReader.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace APIInvoiceReader.Controller
{
  [ApiController]
  [Route("v1")]
  public class ReaderController : ControllerBase
  {
    private readonly IReaderService readerService;

    public ReaderController(IReaderService readerService)
    {
      this.readerService = readerService;
    }

    [HttpPost]
    [Route("Read")]
    public ReaderResponse Get([FromBody] ReaderRequest request)
    {
      return readerService.Get(request);
    }

    [HttpPost]
    [Route("Insert")]
    public ReaderResponse Insert([FromBody] ReaderRequest request)
    {
      return readerService.Get(request);
    }

    [HttpGet]
    [Route("HealthCheck")]
    public void HealthChecksBuilderAddCheckExtensions()
    {
      string connectionString = "Server=tcp:invoicereader.database.windows.net;Database=InvoiceReader;User Id=rodrigo.mori;Password=EsCova2309*;";

      // Se estiver usando autenticação do Windows, remova User Id e Password:
      // string connectionString = "Server=SERVIDOR;Database=MEUBANCO;Integrated Security=True;";

      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        try
        {
          connection.Open();
          Console.WriteLine("Conexão bem-sucedida!");
        }
        catch (Exception ex)
        {
          Console.WriteLine($"Erro na conexão: {ex.Message}");
        }
      }
    }
  }
}