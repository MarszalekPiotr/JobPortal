using FluentValidation;
using FluentValidation.AspNetCore;
using JobPortal.Application.Interfaces;
using JobPortal.Application.Services;
using JobPortal.Application.ViewModels.CategoryVm;
using JobPortal.Application.ViewModels.JobVM;
using JobPortal.Domain.Interfaces;
using JobPortal.Domain.Model;
using JobPortal.Infrastructure;
using JobPortal.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<Context>();
builder.Services.AddControllersWithViews().AddFluentValidation();

//services
builder.Services.AddTransient<IJobService, JobService>();
builder.Services.AddTransient<IApplicationService, ApplicationService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ITagService, TagService>();
builder.Services.AddTransient<IUserService, UserService>();

//repos
builder.Services.AddTransient<IApplicationRepository, ApplicationRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IJobRepository, JobRepository>();
builder.Services.AddTransient<ITagRepository, TagRepository>();
builder.Services.AddTransient<IJobTagRepository, JobTagRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

//
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


// validators
builder.Services.AddTransient<IValidator<NewCategoryViewModel>, NewCategoryValidator>();
builder.Services.AddTransient<IValidator<NewTagViewModel>, NewTagValidator>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
