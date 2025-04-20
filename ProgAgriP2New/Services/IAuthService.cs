namespace ProgAgriP2New.Services
{
    public interface IAuthService
    {
        Task<(bool success, string role, int userId)> ValidateLoginAsync(string email, string password, string userType);
    }
}