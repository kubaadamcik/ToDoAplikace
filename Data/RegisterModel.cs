using System.ComponentModel.DataAnnotations;

namespace ToDoAplikace.Data;

public class RegisterModel
{
    [Required]
    public string UserName { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [StringLength(100, MinimumLength = 6)]
    public string Password { get; set; }
    
    [Required]
    [StringLength(100, MinimumLength = 6)]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; }
}