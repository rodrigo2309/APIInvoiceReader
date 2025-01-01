using System.Text;
using APIInvoiceReader.Model;

namespace APIInvoiceReader.Service
{
  public class ReaderService : IReaderService
  {
    public ReaderResponse Get(ReaderRequest request)
    {
      var response = new ReaderResponse();
      var bytes = Convert.FromBase64String(request.file64);
      var conteudoCsv = Encoding.UTF8.GetString(bytes);

      var conta = new Account() { data = Convert.ToString(DateTime.Now), title = "nubank", valor = 50 };

      response.Add(conta);

      return response;
    }
  }

}