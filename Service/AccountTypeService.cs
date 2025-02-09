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
    _accountTypeRepository.Update(obj);

    return await Task.FromResult("Atualizado com sucesso!!");
  }

  public async Task<string> Delete(int id)
  {
    var accountType = await _accountTypeRepository.GetById(id);

    _accountTypeRepository.Delete(accountType);

    return await Task.FromResult("Registro deletado!");
  }



}