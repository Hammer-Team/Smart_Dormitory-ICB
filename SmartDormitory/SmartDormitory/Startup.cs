using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartDormitory.Data.Context;
using SmartDormitory.Data.Models;
using SmartDormitory.Data.Repository;
using SmartDormitory.Services.Contracts;
using SmartDormitory.Services;
using SmartDormitory.Web.Providers;
using SmartDormitory.Web.Areas.Identity.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using SmartDormitory.Services.External.Contracts;
using SmartDormitory.Services.External;
using System;
using System.Net.Http;

namespace SmartDormitory
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddTransient<IEmailSender, EmailSender>();
            //services.AddTransient<IEmailSender, YourSmsSender>();

            services.AddDbContext<DormitoryContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<DormitoryContext>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IUserManager<>), typeof(UserManagerWrapper<>));

            services.AddScoped<ISensorService, SensorServices>();

            services.AddHostedService<TimedHostedService>();
            // Services External
            services.AddScoped<HttpClient>();
            services.AddScoped<IRestClientService, RestClientService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

        }

        private int HttpClient()
        {
            throw new NotImplementedException();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "adminArea",
                   template: "{area:exists}/{controller=Users}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
