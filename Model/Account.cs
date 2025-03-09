namespace APIInvoiceReader.Model
{
  public class Account
  {
    public string data { get; set; }
    public string title { get; set; }
    public double value { get; set; }

    public Account(string data, string title, double value)
    {
      this.data = data;
      this.title = title;
      this.value = value;
    }
  }
}