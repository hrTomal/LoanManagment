using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DTLoanManagment.Areas.Identity.Data;
using DTLoanManagment.Models.DBContext;
using DTLoanManagment.Repository.Interfaces;
using DTLoanManagment.Repository.Gateway.Loan;
using Microsoft.AspNetCore.Builder;
using DTLoanManagment.Repository.Gateway.Report;
using DTLoanManagment.Repository.Gateway.Accounting;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DTLoanManagmentDBContextConnection") ?? throw new InvalidOperationException("Connection string 'DTLoanManagmentDBContextConnection' not found.");

builder.Services.AddDbContext<DTLoanManagmentDBContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<MainDBContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<DTLoanManagmentUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<DTLoanManagmentDBContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<DbContext, MainDBContext>();
builder.Services.AddScoped<ILoanGateway, LoanGateway>();
builder.Services.AddScoped<IReportGateway, ReportGateway>();
builder.Services.AddScoped<IAccountingGateway, AccountingGateway>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

//using (var scope = app.Services.CreateScope())
//{
//    await DBSeeder.SeedRolesAndAdminAsync(scope.ServiceProvider);
//}

app.Run();
