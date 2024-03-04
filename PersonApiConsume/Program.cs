using PersonApiConsume.Models;
using PersonApiConsume.Services.Implementation;
using PersonApiConsume.Services.Interface;
using PersonMinimalApi.ApiCode.Implementations;
using PersonMinimalApi.ApiCode.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IPersonApiService, PersonApiService>();
builder.Services.AddHttpClient();

builder.Services.AddOptions<PersonApiOptions>().BindConfiguration("PersonApiOptions")
    .ValidateDataAnnotations()
    .ValidateOnStart();


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
