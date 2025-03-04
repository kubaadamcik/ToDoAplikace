using Microsoft.EntityFrameworkCore;
using ToDoAplikace.Models;

namespace ToDoAplikace.Data
{
    public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
    {
        public DbSet<ToDoTask> Tasks { get; set; }
    }


}
