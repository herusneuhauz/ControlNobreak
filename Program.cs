using Microsoft.EntityFrameworkCore;
using ControlNobreak.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurando o Entity Framework com SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Nobreaks}/{action=Index}/{id?}");

app.Run();
