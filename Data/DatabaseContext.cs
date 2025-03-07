using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ToDoAplikace.Data
{
    public class DatabaseContext(DbContextOptions options) : IdentityDbContext (options)
    {
        public DbSet<User> Users { get; set; }
    }
}
