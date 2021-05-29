using ELibrary.MVC.Extensions;
using ELibrary.Data;
using ELibrary.Models;
using ELibrary.MVC.ExceptionExtension;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ELibrary.Core.Abstractions;
using ELibrary.Core.Implementations;

namespace ELibrary.MVC
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

            services.AddControllersWithViews();

            services.AddJwtAuth(Configuration);
            services.AddDependencyInjection();

            services.AddDbContextPool<ELibraryDbContext>
                (option => option.UseSqlite(Configuration.GetConnectionString("Default")));

            //Identity Setup
            services.AddIdentity<AppUser, IdentityRole>(
                options =>
                {
                    options.Password.RequiredUniqueChars = 0;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredLength = 5;
                    options.Password.RequireLowercase = false;

                }
                ).AddEntityFrameworkStores<ELibraryDbContext>();
            services.AddEmailConfiguration(Configuration);
            services.AddCloudinaryConfiguration(Configuration); 
            services.AddCloudinaryPhotoConfiguration(Configuration);
            services.AddScoped<IEmailServices, EmailServices>();
            services.AddScoped<ICloudinaryServices, CloudinaryServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleWare>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
                
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.ConfigureExceptionHandler();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
