using TAB.ViewModels.System.Users;

namespace TAB.Admin.Services
{
    public interface InterfaceUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
    }
}
