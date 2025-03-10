using Microsoft.EntityFrameworkCore;
using ToDoAplikace.Data;

namespace ToDoAplikace.Services
{
    public class ToDoTaskService : IToDoTaskService
    {
        public User User { get; set; }
        public List<ToDoTask> ToDoTasks { get; set; }

        private readonly DatabaseContext _context;

        public ToDoTaskService(DatabaseContext _context)
        {
            
        }

        public async Task NewTask(ToDoTask task)
        {

        }

        public async Task CompleteTask(int id)
        {

        }
    }
}
