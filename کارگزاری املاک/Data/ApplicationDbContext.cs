using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using کارگزاری_املاک.Models;

namespace کارگزاری_املاک.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserModel> users { get; set; }
        public DbSet<EstateModel> estates { get; set; }
    }
}
