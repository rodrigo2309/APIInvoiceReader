public class UserService : IUserService
{
  private readonly IUserRepository _userRepository;
  private readonly ITokenService _tokenService;
  public UserService(IUserRepository userRepository, ITokenService tokenService)
  {
    _userRepository = userRepository;
    _tokenService = tokenService;
  }
  public async Task<GenerateTokenResponse> GenerateToken(GenerateTokenRequest request)
  {
    var response = new GenerateTokenResponse();
    var user = await _userRepository.Get(request.Username, request.Password);

    // var users = new List<User>(){
    //   new() { Id = 1, Username = "batman", Password = "batman", Role = "manager" },
    //   new() { Id = 2, Username = "robin", Password = "robin", Role = "employee" }
    // }; 

    if (user == null)
    {
      return null;
    }

    var token = _tokenService.GenerateToken(user);

    user.Password = "";

    response.user = user;
    response.token = token;

    return response;
  }



}