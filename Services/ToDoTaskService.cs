using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using ToDoAplikace.Data;

namespace ToDoAplikace.Services
{
    public class ToDoTaskService
    {
        private readonly DatabaseContext _context;

        public ToDoTaskService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<ToDoTask>?> GetTasksByUserIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user is not null)
            {
                var toDoTasks = user.Tasks;

                return toDoTasks.ToList();
            }

            return null;
        }

        public async Task<bool> CreateTaskWithUserIdAsync(int id, ToDoTask task)
        {
            var user = await _context.Users.FindAsync(id);

            if (user is null) return false;
            
            user.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
