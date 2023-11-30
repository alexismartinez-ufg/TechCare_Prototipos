using Prototipos.DAL.ViewModels;
using System.Security.Claims;

namespace Prototipos.BAL.Interfaces
{
    public interface IAuthService
    {
        bool TryLogin(LoginViewModel login, out ClaimsPrincipal claimsPrincipal);
    }
}
