using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRegistration.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeRegistration
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(options =>options.UseSqlServer(_config.GetConnectionString("empdbconnection")));

            services.AddIdentity<IdentityUser, IdentityRole>(options => {
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 3;
            }).AddEntityFrameworkStores<AppDbContext>();

            services.Configure<IdentityOptions>(options => {
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 3;
            });

            services.AddMvc(options => {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

                options.Filters.Add(new AuthorizeFilter(policy));
            }).AddXmlSerializerFormatters();
            // services.AddIdentity<IdentityUser, IdentityRole>().AddUserStore<MockEmployeeRepository>();
            services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error/");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }
            app.UseStaticFiles();
            app.UseAuthentication();
            //app.UseMvcWithDefaultRoute();

            app.UseMvc(routes => {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            //app.UseMvc(routes => {
            //    routes.MapRoute("default", "{controller=Home}/{action=Registor}/{id?}");
            //});
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
