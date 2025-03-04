using Microsoft.EntityFrameworkCore;
using ToDoAplikace;
using ToDoAplikace.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlite("Data Source=Data/database.db");
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAntiforgery();

app.MapBlazorHub();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

