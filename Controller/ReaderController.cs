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
  }
}