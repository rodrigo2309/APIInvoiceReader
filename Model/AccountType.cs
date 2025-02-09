public class AccountType
{
  public int id { get; set; }
  public string nome { get; set; }
  public string conta { get; set; }
  public bool contem { get; set; }
  public string usuario { get; set; }

  public AccountType(string nome, string conta, bool contem, string usuario)
  {
    this.nome = nome;
    this.conta = conta;
    this.contem = contem;
    this.usuario = usuario;
  }
}
