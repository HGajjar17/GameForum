using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GameForum.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<GameForumContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GameForumContext") ?? throw new InvalidOperationException("Connection string 'GameForumContext' not found.")));

// Changed RequireConfirmedAccount to false to allow for easier testing
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<GameForumContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// Added as part of Identity setup
app.MapRazorPages().WithStaticAssets();

app.Run();
