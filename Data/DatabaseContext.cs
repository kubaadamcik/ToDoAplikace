using Microsoft.EntityFrameworkCore;
using ToDoAplikace.Models;

namespace ToDoAplikace.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<ToDoTask> Tasks { get; set; }
    }
}
