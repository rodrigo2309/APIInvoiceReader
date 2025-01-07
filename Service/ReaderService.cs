using System.Text;
using APIInvoiceReader.Model;

namespace APIInvoiceReader.Service
{
  public class ReaderService : IReaderService
  {
    public ReaderResponse Get(ReaderRequest request)
    {
      var response = new ReaderResponse();

      response = Teste();

      return response;
    }

    public string DesconvertBase64(string base64)
    {
      var bytes = Convert.FromBase64String(base64);
      var conteudoCsv = Encoding.UTF8.GetString(bytes);

      return conteudoCsv;
    }

    public ReaderResponse Teste()
    {
      var response = new ReaderResponse();

      var conta = new Account() { data = Convert.ToString(DateTime.Now), title = "nubank", valor = 50 };

      response.Add(conta);

      return response;
    }
  }

}