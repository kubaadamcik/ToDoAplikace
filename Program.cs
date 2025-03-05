using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ToDoAplikace;
using ToDoAplikace.Components;
using ToDoAplikace.Data;
using ToDoAplikace.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSwaggerGen();

builder.Services.AddServerSideBlazor();

builder.Services.AddControllers();

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlite("Data Source=Data/database.db");
});

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<DatabaseContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication().AddCookie(options =>
{
    // TODO
});

builder.Services.AddAuthorization();



var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapBlazorHub();

app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

