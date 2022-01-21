using MarvelShopping.IdentityServer.Configuration;
using MarvelShopping.IdentityServer.DataModel;
using MarvelShopping.IdentityServer.DataModel.Context;
using MarvelShopping.IdentityServer.Initializer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<MySQLContext>(options => options.
    UseMySql(connection,
        new MySqlServerVersion(
            new Version(8, 0, 27))));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().
    AddEntityFrameworkStores<MySQLContext>().
    AddDefaultTokenProviders();

var builder1 = builder.Services.AddIdentityServer(
    options =>
    {
        options.Events.RaiseErrorEvents = true;
        options.Events.RaiseInformationEvents = true;
        options.Events.RaiseFailureEvents = true;
        options.Events.RaiseSuccessEvents = true;
        options.EmitStaticAudienceClaim = true;
    }).AddInMemoryIdentityResources(IdentityConfiguration.IdentityResources).
    AddInMemoryApiScopes(IdentityConfiguration.ApiScopes).
    AddInMemoryClients(IdentityConfiguration.Clients).
    AddAspNetIdentity<ApplicationUser>();

builder.Services.AddScoped<IDbInitializer, DbInitializer>();

builder1.AddDeveloperSigningCredential();

var app = builder.Build();

//IDbInitializer initializer = app.Services.GetRequiredService<IDbInitializer>();

var scope = app.Services.CreateScope();
var initializer = scope.ServiceProvider.GetService<IDbInitializer>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();

app.UseAuthorization();

initializer.Initialize();

app.MapRazorPages();

app.Run();
