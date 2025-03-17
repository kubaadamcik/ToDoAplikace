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
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<ToDoTask>> GetTasksByUserIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new List<ToDoTask>();
            }

            var user = await _context.Users
                .Include(u => u.Tasks)
                .FirstOrDefaultAsync(u => u.Id == id);


            return user?.Tasks?.ToList() ?? new List<ToDoTask>();
        }

        public async Task<bool> CreateTaskWithUserIdAsync(ToDoTask task)
        {
            var user = await _context.Users
                .Include(u => u.Tasks)
                .FirstOrDefaultAsync(u => u.Id == task.UserId);

            if (user is null) return false;

            user.Tasks ??= new List<ToDoTask>();
            user.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> FinishTask(int id, string userId)
        {
            var user = await _context.Users
                .Include(u => u.Tasks)
                .FirstOrDefaultAsync(u => u.Id == userId);

            var tasks = user.Tasks;

            var task = tasks.FirstOrDefault(u => u.Id == id);

            if (task is null)
            {
                return false;
            }
            
            user.Tasks.Remove(task);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}