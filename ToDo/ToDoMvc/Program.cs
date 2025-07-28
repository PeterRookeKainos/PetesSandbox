using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Data;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<ToDoContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("ToDoContext") ?? throw new InvalidOperationException("Connection string 'ToDoContext' not found."))
            .LogTo(Console.WriteLine, LogLevel.Information, DbContextLoggerOptions.LocalTime | DbContextLoggerOptions.SingleLine)
        );
        // Uncomment the following line to use MySQL instead - not working yet not able to connect to localhost (might be due to the security on this locked down machine?)
        // options.UseMySQL(builder.Configuration.GetConnectionString("ToDoContext-mysql") ?? throw new InvalidOperationException("Connection string 'ToDoContext' not found.")));
}
else
{
    // For production, use SQL Server currently not setup TODO!
    builder.Services.AddDbContext<ToDoContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionMvcMovieContext")));
}

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));


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

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ToDo}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();

// For integration tests (no idea what this does, but it is needed for the tests to run?)
public partial class Program { }
