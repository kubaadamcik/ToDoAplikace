using System.Reflection.Metadata.Ecma335;

namespace ToDoAplikace.Models
{
    public class ToDoTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Completed { get; set; }

        public ToDoTask(string name, DateTime createdAt)
        {
            Name = name;
            CreatedAt = createdAt;
        }
    }

}
