using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNet.Identity.EntityFramework; esto es viejo
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Web1.Data;
using Microsoft.AspNetCore.Identity;
using Web1.Interfaces;
using Web1.Repositorios;

var builder = WebApplication.CreateBuilder(args);
 
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ITareas, RepoTareas>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSql")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=IndexLogin}/{id?}");

app.Run();
