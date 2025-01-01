using APIInvoiceReader.Service;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet("rota/{file64}")]
    [Route("Read")]
    public ReaderResponse Get(ReaderRequest request)
    {
      return readerService.Get(request);
    }
  }
}