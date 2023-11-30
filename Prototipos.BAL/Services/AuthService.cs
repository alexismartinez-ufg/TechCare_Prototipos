using Microsoft.AspNetCore.Authentication.Cookies;
using Prototipos.BAL.Interfaces;
using Prototipos.DAL.ViewModels;
using System.Security.Claims;

namespace Prototipos.BAL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuariosRepository usuariosRepository;
        public AuthService(IUsuariosRepository _usuariosRepository)
        {
            usuariosRepository = _usuariosRepository;
        }

        public bool TryLogin(LoginViewModel login, out ClaimsPrincipal claimsPrincipal)
        {
            var user = usuariosRepository.CanDoLogin(login);

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role)
                };

                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                claimsPrincipal = new ClaimsPrincipal(claimIdentity);

                return true;
            }

            claimsPrincipal = null;
            return false;
        }
    }
}
