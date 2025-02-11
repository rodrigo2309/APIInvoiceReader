public class AccountTypeService : IAccountTypeService
{
  private readonly IAccountTypeRepository _accountTypeRepository;
  public AccountTypeService(IAccountTypeRepository accountTypeRepository)
  {
    _accountTypeRepository = accountTypeRepository;
  }
  public async Task<CreateResponse> Create(CreateRequest request)
  {
    var response = new CreateResponse();

    var accountType = new AccountType(request.nome, request.conta, request.contem, request.usuario);

    await _accountTypeRepository.Create(accountType);

    response.id = accountType.id;

    return response;
  }

  public async Task<GetByUserResponse> GetByUser(GetByUserRequest request)
  {
    var response = new GetByUserResponse();

    response.AddRange(await _accountTypeRepository.GetByUser(request.usuario));

    return await Task.FromResult(response);
  }

  public async Task<string> Update(AccountType obj)
  {
    var existingUser = await _accountTypeRepository.GetById(obj.id);

    if (existingUser != null)
    {
      existingUser.nome = obj.nome;
      existingUser.conta = obj.conta;
      existingUser.contem = obj.contem;
      existingUser.usuario = obj.usuario;

      //return NotFound(new { message = "Usuário não encontrado." });
      _accountTypeRepository.Update(existingUser);
    }

    return await Task.FromResult("Atualizado com sucesso!!");
  }

  public async Task<DeleteResponse> Delete(DeleteRequest request)
  {
    var response = new DeleteResponse();

    var accountType = await _accountTypeRepository.GetByNome(request.nome);

    _accountTypeRepository.Delete(accountType);

    response.mensagem = "Registro deletado!";

    return response;
  }



}