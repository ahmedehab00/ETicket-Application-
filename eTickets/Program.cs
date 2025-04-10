using etickets.Service.UnitOfWork;
using eTickets.Data;
using eTickets.Data.Data;
using eTickets.Data.Data.Cart;
using eTickets.Data.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZendeskApi_v2.Models.AccountsAndActivities;
using ZendeskApi_v2.Models.CustomRoles;

namespace eTickets
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);




            // DbContext Configuration
           builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString
                ("DefaultConnectionString"), b => b.MigrationsAssembly("eTickets")));
            //Services Configuration
            //builder.Services.AddScoped<IActorsService, ActorService>();
            //builder.Services.AddScoped<IProducerService, ProducerService>();
            //builder.Services.AddScoped<ICinemaService, CinemaService>();
            //builder.Services.AddScoped<IMoviesService, MovieService>();
            //builder.Services.AddScoped<IOrderService, OrderService>();
            
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));


            //Authentication and authorization
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            builder.Services.AddMemoryCache();
            builder.Services.AddSession();
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            });

            builder.Services.AddControllersWithViews();


            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            //Authentication and authorization
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            //Seed database
            //AppDbInitializer.Seed(app);
            AppDbInitializer.SeedUsersAndRolesAsync(app).Wait();

            app.Run();

        }


    }
}
