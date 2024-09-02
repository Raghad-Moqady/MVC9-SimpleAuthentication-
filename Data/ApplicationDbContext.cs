using Microsoft.EntityFrameworkCore;
using UserAuthenticationTask.Models;

namespace UserAuthenticationTask.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }

}
