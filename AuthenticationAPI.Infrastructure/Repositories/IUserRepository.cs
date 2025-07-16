namespace AuthenticationAPI.Infrastructure
{
    public interface IUserRepository
    {
        Task<bool> ValidateUser(string email, string password);
    }
}
