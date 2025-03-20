using System.ComponentModel.DataAnnotations;

namespace ToDoAplikace.Data
{
    public class ChangeUsernameModel
    {
        [Required] public required string UserName { get; set; }
        [Required] public required string UserId { get; set; }
    }
}
