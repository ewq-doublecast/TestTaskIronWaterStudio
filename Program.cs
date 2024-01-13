using Microsoft.EntityFrameworkCore;
using TestTaskIronWaterStudio.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("TestTaskDbContextConnection") ?? throw new InvalidOperationException("Connection string 'TestTaskDbContextConnection' not found.");

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TestTaskDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:TestTaskDbContextConnection"]);
});

builder.Services.AddDefaultIdentity<IdentityUser>(options => {
    options.SignIn.RequireConfirmedAccount = false;
    options.User.RequireUniqueEmail = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
}).AddEntityFrameworkStores<TestTaskDbContext>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
        await UserInitializer.CreateAdminUser(userManager, builder.Configuration);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error creating admin user: {ex.Message}");
    }
}

app.Run();
