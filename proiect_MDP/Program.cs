using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using proiect_MDP.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
   policy.RequireRole("Admin"));
});

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Zboruri");
    options.Conventions.AllowAnonymousToPage("/Zboruri/Index");
    options.Conventions.AllowAnonymousToPage("/Zboruri/Details");
    options.Conventions.AuthorizeFolder("/Utilizatori", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Terminale");
    options.Conventions.AllowAnonymousToPage("/Terminale/Index");
    options.Conventions.AllowAnonymousToPage("/Terminale/Details");
    options.Conventions.AuthorizeFolder("/Categorii");
    options.Conventions.AllowAnonymousToPage("/Categorii/Index");
    options.Conventions.AllowAnonymousToPage("/Categorii/Details");
    options.Conventions.AuthorizeFolder("/Companii");
    options.Conventions.AllowAnonymousToPage("/Companii/Index");
    options.Conventions.AllowAnonymousToPage("/Companii/Details");

});
builder.Services.AddDbContext<proiect_MDPContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("proiect_MDPContext") ?? throw new InvalidOperationException("Connection string 'proiect_MDPContext' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("proiect_MDPContext") ?? throw new InvalidOperationException("Connection string 'proiect_MDPContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
 .AddRoles<IdentityRole>()
 .AddEntityFrameworkStores<LibraryIdentityContext>();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
