using _27_FrontToBackSqlConnection.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer("Server=DESKTOP-58DF40O\\SQLEXPRESS;Database=APA103ProniaDB;Trused_Connection=True;TrustServerCertificate=true");
});



var app = builder.Build();

app.UseStaticFiles(); 

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
