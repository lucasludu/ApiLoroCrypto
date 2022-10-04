using ApiLoroCrypto.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiLoroCrypto.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> ops) : base(ops)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
