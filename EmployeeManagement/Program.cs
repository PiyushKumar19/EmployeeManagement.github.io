using EmployeeManagement.ApplicationDbContext;
using EmployeeManagement.InterfacesAndSqlRepos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IEmployeeCRUD, SqlEmployeeRepo>();
builder.Services.AddTransient<IEmployeeRegisterCRUD, SqlEmployeeRegisterRepo>();
string cs = "server = LAPTOP-2SDVC21L; database = EmpManageDB; uid = sa; password = Piyush@1529;";
builder.Services.AddDbContextPool<DatabaseContext>(options =>
options.UseSqlServer(cs));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
