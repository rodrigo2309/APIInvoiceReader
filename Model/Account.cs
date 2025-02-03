namespace APIInvoiceReader.Model
{
  public class Account
  {
    public string data { get; set; }
    public string title { get; set; }
    public string valor { get; set; }

    public Account(string data, string title, string valor)
    {
      this.data = data;
      this.title = title;
      this.valor = valor;
    }
  }
}