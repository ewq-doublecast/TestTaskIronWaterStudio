using Microsoft.EntityFrameworkCore;
using TestTaskIronWaterStudio.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TestTaskDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:TestTaskDbContextConnection"]);
});

builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=List}/{id?}");

app.Run();
