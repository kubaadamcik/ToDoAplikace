using System.ComponentModel.DataAnnotations;

namespace ToDoAplikace.Data
{
    public class LoginModel
    {
        public string UserName { get; set; }

        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
