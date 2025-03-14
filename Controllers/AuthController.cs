﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using ToDoAplikace.Data;

namespace ToDoAplikace.Controllers;

[Route("/api/auth")]
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

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        if (Regex.IsMatch(request.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is not null)
            {
                var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, true, false);
                
                if (result.Succeeded)
                {
                    return Ok();
                }
            }
        }
        else
        {
            var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, true, false);
            
            if (result.Succeeded)
            {
                return Ok();
            }
        }
        
        return BadRequest();
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel request)
    {
        var user = new User() { Email = request.Email, UserName = request.UserName };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {
            _signInManager.SignInAsync(user, true);
            return Ok();
        }

        return BadRequest();
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return Ok();
    }
}