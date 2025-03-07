namespace ToDoAplikace.Data
{
    public class ToDoTask
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? Deadline { get; set; }

    }
}
