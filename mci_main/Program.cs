using mci_main.Data;
using mci_main.Repository;
using mci_main.Repository.Implementation;
using Microsoft.EntityFrameworkCore;

// BEGIN Builder.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MciContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MciContext") ?? throw new InvalidOperationException("Connection string 'MciContext' not found.")));

builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<ISearchRepository, SearchRepository>();
builder.Services.AddTransient<IPractitionerRepository, PractitionerRepository>();

// END builder, create the webapp instance...
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialise(services);
}

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

