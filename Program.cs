using Microsoft.EntityFrameworkCore;
using PieCodeERP.Repo;
using PieCodeERP.Repo.Interface;
using PieCodeERP.Service;
using PieCodeERP.Service.Interface;
using AutoMapper;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ERPContext>(x => x.UseSqlServer(builder.Configuration["ConnectionStrings:ConnectDb"]));
builder.Services.AddAutoMapper(typeof(MappingConfiguration));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


#region Repository Injection 

builder.Services.AddScoped<IRegionRepository, RegionRepository>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICostCenterRepository, CostCenterRepository>();

#endregion


#region Services Injection
builder.Services.AddScoped<IRegionMasterService, RegionMasterService>();
builder.Services.AddScoped<IBranchMasterService, BranchMasterService>();
builder.Services.AddScoped<IDepartmentMasterService, Departmentmasterservice>();
builder.Services.AddScoped<ICompanyMasterService, CompanyMasterService>();
builder.Services.AddScoped<ICostCenterMasterService, CostCenterService>();

#endregion

var app = builder.Build();

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
    pattern: "{controller=Region}/{action=Index}/{id?}");

app.Run();
