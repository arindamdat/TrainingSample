using Microsoft.EntityFrameworkCore;
using TrainingSample;

var builder = WebApplication.CreateBuilder(args);

var azureAppConfigConnectionString = "Endpoint=https://ariappconfig.azconfig.io;Id=fZZb-lh-s0:vKd2VqgNzZbxm8z0rkUw;Secret=0BiRfv69E/R0v7vy/aqtAabGnlov0p0sGcqrXgGawB8=";
//builder.Host.ConfigureAppConfiguration(configBuilder =>
//{
//    configBuilder.AddAzureAppConfiguration(azureAppConfigConnectionString, optional: false);
//});
builder.Configuration.AddAzureAppConfiguration(azureAppConfigConnectionString, optional: false);
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TrainingDbContext>(opt => opt.UseSqlServer(builder.Configuration["Training"], sql =>
{
    sql.EnableRetryOnFailure(5);

}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
