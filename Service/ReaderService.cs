using System.Globalization;
using System.Text;
using APIInvoiceReader.Model;

namespace APIInvoiceReader.Service
{
  public class ReaderService : IReaderService
  {
    public ReaderResponse Get(ReaderRequest request)
    {
      var conteudo = DesconvertBase64(request.file64);

      var response = new ReaderResponse();

      response = ReadFile(conteudo);

      return response;
    }

    public ReaderResponse ReadFile(string conteudo)
    {
      var response = new ReaderResponse();
      List<Account> listaAccount = new List<Account>();

      string[] linhas = conteudo.Split('\n');

      for (int i = 1; i < linhas.Length; i++)
      {
        if (string.IsNullOrWhiteSpace(linhas[i])) continue;

        string[] colunas = linhas[i].Split(',');

        if (double.Parse(colunas[2].Trim(), CultureInfo.InvariantCulture) <= 0)
        {
          continue;
        }

        Account account = new Account(colunas[0].Trim(), colunas[1].Trim(), double.Parse(colunas[2].Trim(), CultureInfo.InvariantCulture));

        listaAccount.Add(account);
      }

      response.AddRange(listaAccount.OrderBy(a => a.title).Select(a => a).ToList());

      return response;
    }

    public string DesconvertBase64(string base64)
    {
      var bytes = Convert.FromBase64String(base64);
      var conteudoCsv = System.Text.Encoding.UTF8.GetString(bytes);

      return conteudoCsv;
    }

    public ReaderResponse Teste()
    {
      var response = new ReaderResponse();

      // var conta = new Account() { data = Convert.ToString(DateTime.Now), title = "nubank", valor = "50" };

      // response.Add(conta);

      return response;
    }
  }

}