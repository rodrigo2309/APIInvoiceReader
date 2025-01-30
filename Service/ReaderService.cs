using System.Text;
using APIInvoiceReader.Model;

namespace APIInvoiceReader.Service
{
  public class ReaderService : IReaderService
  {
    public ReaderResponse Get(ReaderRequest request)
    {
      var response = new ReaderResponse();

      response = ReadFile();

      //response = Teste();

      return response;
    }

    public ReaderResponse ReadFile()
    {
      string filePath = "C:/Users/drigo/Downloads/Nubank_2025-01-02.csv";

      var response = new ReaderResponse();

      using (StreamReader reader = new StreamReader(filePath))
      {
        while (!reader.EndOfStream)
        {
          string linha = reader.ReadLine();
          string[] valores = linha.Split(',');

          response.Add(new Account() { data = valores[0], title = valores[1], valor = valores[2] });

          Console.WriteLine(string.Join(" | ", valores));
        }
      }

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

      var conta = new Account() { data = Convert.ToString(DateTime.Now), title = "nubank", valor = "50" };

      response.Add(conta);

      return response;
    }
  }

}