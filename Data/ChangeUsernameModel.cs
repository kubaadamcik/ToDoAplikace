using System.ComponentModel.DataAnnotations;

namespace ToDoAplikace.Data
{
    public class ChangeUsernameModel
    {
        [Required] public string UserName { get; set; }
        [Required] public string UserId { get; set; }
    }
}
