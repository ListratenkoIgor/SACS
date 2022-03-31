using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SACS_Server.Authentification
{
    public class AuthentificationDbContext : IdentityDbContext
    {
        public AuthentificationDbContext(DbContextOptions<AuthentificationDbContext> options) : base(options)
        {

        }
    }
}