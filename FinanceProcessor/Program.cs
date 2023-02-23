using System.Reflection;

using FinanceProcessor.ApiConsumer;
using FinanceProcessor.Core;
using FinanceProcessor.Core.Aggregates.Customer.Models;
using FinanceProcessor.IEXSharp.Options;
using FinanceProcessor.Infrastructure;
using FinanceProcessor.Infrastructure.Data;
using FinanceProcessor.MongoDB.Core;

using MediatR;

using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Converters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FinanceContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<FinanceUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<FinanceContext>();

builder.Services.Configure<PayPalAuthenticationOptions>(
    builder.Configuration.GetSection(PayPalAuthenticationOptions.SECTION_NAME));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var certPath = "/var/ssl/private/867687DB45596C5CFD5F7CC4FE393B400A6198A6.p12";

/*if (File.Exists(certPath))
{
    var bytes = File.ReadAllBytes(certPath);
    var certificate = new X509Certificate2(bytes);

    builder.Services.AddIdentityServer()
        .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options =>
        {

        })
        .AddSigningCredential(certificate);
}
else
{
    throw new FileNotFoundException($"Certificate path: {certPath}.");
}*/

builder.Services.AddIdentityServer()
    .AddApiAuthorization<FinanceUser, FinanceContext>(options =>
    {
        
    });

builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddCore();
builder.Services.AddMongoCore(builder.Configuration);
builder.Services.AddApiConsumer(builder.Configuration);

builder.Services.AddMediatR(Assembly.GetAssembly(typeof(Program))!);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSwaggerGen();

builder.Services
    .AddControllersWithViews()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.Converters.Add(new StringEnumConverter()));
// order is vital, this *must* be called *after* AddNewtonsoftJson()
builder.Services.AddSwaggerGenNewtonsoftSupport();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(config =>
	{
		config.ConfigObject.AdditionalItems["syntaxHighlight"] = new Dictionary<string, object>
		{
			["activated"] = false
		};
	});
	app.UseMigrationsEndPoint();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseIdentityServer();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");
app.MapRazorPages();

app.MapFallbackToFile("index.html");

app.Run();
