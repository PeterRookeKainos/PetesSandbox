using Microsoft.Extensions.Options;
using ReadConfig;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// read the application options from the configuration
builder.Services.Configure<AppOptions>(builder.Configuration.GetSection("AppOptions"));
// register the options as a singleton service
builder.Services.AddSingleton(resolver =>
{
    var options = resolver.GetRequiredService<IOptions<AppOptions>>();
    return options.Value;
});

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

app.Run();
