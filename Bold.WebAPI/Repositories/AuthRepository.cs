using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Bold.WebAPI.Repositories
{
    public class AuthRepository : IDisposable
    {
        private readonly AuthContext _authContext;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthRepository()
        {
            _authContext = new AuthContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_authContext));
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            var user = await _userManager.FindAsync(userName, password);
            return user;
        }


        public void Dispose()
        {
            _authContext.Dispose();
            _userManager.Dispose();
        }
    }

    internal class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("AuthContext"){}
    }
}