using ToDoAplikace.Data;

namespace ToDoAplikace.Services
{
    public interface IToDoTaskService
    {
        Task NewTask(ToDoTask task);
        Task CompleteTask(int id);
    }
}
