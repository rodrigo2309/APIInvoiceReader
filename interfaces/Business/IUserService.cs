public interface IUserService
{
  Task<GenerateTokenResponse> GenerateToken(GenerateTokenRequest request);
}