using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoAplikace.Models;

namespace ToDoAplikace.Data
{
    public class DatabaseContext(DbContextOptions<DatabaseContext> options) : IdentityDbContext<User>(options)
    {
        public DbSet<User> Users { get; set; }
    }
}
