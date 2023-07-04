using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineShop;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Интерфейсы;
using Serilog;
using System;

namespace OnlineShopWebApp
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			//Получаем строку подключения из файла конфигурации 
			string connection = Configuration.GetConnectionString("online_shop");

			//Добавляем контекст DatabaseContext в качество сервиса в приложения
			services.AddDbContext<DatabaseContext>(options =>
				options.UseSqlServer(connection));

			//Добавляем контекст IdentityContext  в качество сервиса  в приложения
			services.AddDbContext<IdentityContext>(options =>
			options.UseSqlServer(connection));

			services.AddIdentity<User, IdentityRole>() //указваем типи пользователя 
				.AddEntityFrameworkStores<IdentityContext>();// устанавливаем тип хранени


			services.ConfigureApplicationCookie(options =>
			{
				options.ExpireTimeSpan = TimeSpan.FromHours(8);
				options.LoginPath = "/Account/Login";
				options.LogoutPath = "/Account/Logout";
				options.Cookie = new CookieBuilder
				{
					IsEssential = true,
				};
			});


			services.AddTransient<IFavorite, FavoriteDbRepozitory>();
			services.AddTransient<IOrderRepozitory, OrderDbRepozitory>();
			services.AddTransient<IProductRepozitory, ProductDbRepozitory>();
			services.AddTransient<ICartRepozitory, CartDbRepozitory>();
			services.AddTransient<IOrderRepozitory, OrderDbRepozitory>();
			services.AddSingleton<IRolesRepozitory, RoleRepozitory>();
			services.AddSingleton<IUsersManager, UserManager>();
			services.AddTransient<ImagesProvider>();
			services.AddTransient<CategoryRepozitory>();




			services.AddControllersWithViews();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseSerilogRequestLogging();

			app.UseRouting();

			app.UseAuthentication();   //Поключения аутенфикации
			app.UseAuthorization();   //Поключения авторизации

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "Area",
					pattern: "{area:exists}/{controller=Home}/{action=Index}/{Id?}");

				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{Id?}");
			});
		}
	}
}
