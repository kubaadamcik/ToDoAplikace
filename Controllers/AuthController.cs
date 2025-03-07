using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using ToDoAplikace.Data;

namespace ToDoAplikace.Controllers;

[Route("/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private SignInManager<User> _signInManager { get; set; }
    private UserManager<User> _userManager { get; set; }

    public AuthController(SignInManager<User> signInManager, UserManager<User> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [Route("/login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, true, false);

        if (result.Succeeded)
        {
            return Ok();
        }

        return BadRequest();
    }

    [Route("/register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel request)
    {
        var user = new User() { Email = request.Email, UserName = request.Email };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {
            _signInManager.SignInAsync(user, true);
            return Ok();
        }

        return BadRequest();
    }

    [Route("/logout")]
    public async Task<IActionResult> Logout()
    {
        _signInManager.SignOutAsync();
        return Ok();
    }
}