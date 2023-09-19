using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Kovacs_Adela_Licenta.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
   policy.RequireRole("Admin"));
});

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/CafeleClienti");
    options.Conventions.AuthorizePage("/Story");
    options.Conventions.AuthorizeFolder("/Clienti", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Marimi", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/TipuriArome", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/TipuriBoabe", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/TipuriCafele", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/TipuriLapte", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/TipuriToppinguri", "AdminPolicy");

});



builder.Services.AddDbContext<Kovacs_Adela_LicentaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Kovacs_Adela_LicentaContext") ?? throw new InvalidOperationException("Connection string 'Kovacs_Adela_LicentaContext' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Kovacs_Adela_LicentaContext") ?? throw new InvalidOperationException("Connectionstring 'Kovacs_Adela_LicentaContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryIdentityContext>();

//// PT AUTENTIFICARE CU FACEBOOK
//builder.Services.AddAuthentication().AddFacebook(option =>
//{
//    option.AppId = "711645244045162";
//    option.AppSecret = "ce18cb09e18f23205f9864f484846816";
//});

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
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
