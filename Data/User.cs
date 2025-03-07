using Microsoft.AspNetCore.Identity;

namespace ToDoAplikace.Data
{
    public class User : IdentityUser
    {
        public List<ToDoTask> Tasks { get; set; }
    }
}
