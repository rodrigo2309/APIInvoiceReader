
public interface IAccountTypeService
{
  Task<CreateResponse> Create(CreateRequest request);
  Task<GetByUserResponse> GetByUser(GetByUserRequest request);
  Task<string> Update(AccountType obj);
  Task<string> Delete(int id);
}