using BlogP.Data.Context;
using BlogP.Data.Extensions;
using BlogP.Entity.Entities;
using BlogP.Service.Extensions;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.LoadDataLayerExtension(builder.Configuration);
builder.Services.LoadServiceLayerExtension();
builder.Services.AddSession();

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Identity
	builder.Services.AddIdentity<AppUser, AppRole>(
		opt =>
		{
			opt.Password.RequireLowercase = false;
			opt.Password.RequireLowercase = false;
			opt.Password.RequireUppercase = false;
		}).AddRoleManager<RoleManager<AppRole>>()
		.AddEntityFrameworkStores<AppDbContext>()
		.AddDefaultTokenProviders();

	builder.Services.ConfigureApplicationCookie(conf => {
		conf.LoginPath = new PathString("/Admin/Auth/Login");
		conf.LogoutPath = new PathString("/Admin/Auth/Logout");
		conf.Cookie = new CookieBuilder
		{
			Name = "Blog",
			HttpOnly = true,
			SameSite = SameSiteMode.Strict,
			SecurePolicy = CookieSecurePolicy.SameAsRequest // Always (sadece https istek al�r)
		};
		conf.SlidingExpiration = true;
		conf.ExpireTimeSpan = TimeSpan.FromDays(7);
		conf.AccessDeniedPath = new PathString("/Admin/Auth/AccessDenied");
	});

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

app.UseSession();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
	endpoints.MapAreaControllerRoute(
		name:"Admin",
		areaName: "Admin",
		pattern:"Admin/{controller=Home}/{action=Index}/{id?}"
		);
	endpoints.MapDefaultControllerRoute();
});

app.Run();
