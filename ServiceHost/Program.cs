

using Configuration;
using EFcore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var connectionstring = builder.Configuration.GetConnectionString("Shop");
builder.Services.AddDbContext<ShopContext>(option =>
        option.UseSqlServer(connectionstring));

BootStrapper.Configure(builder.Services, connectionstring);

//NOTICE: check you don't build anything after builder.Build() .
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
