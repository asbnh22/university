using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using University.DAL.Repository;
using University.DAL;
using University.Common;
using System.Net;

namespace University
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
            
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddMvc();

            var connectionString = _configuration.GetConnectionString("Default");
            services.AddDbContext<UniversityDBContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Student}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "Create",
                    template: "{controller}/create",
                    defaults: new { controller = "Student", action = "Create" }
                    );

                routes.MapRoute(
                  name: "Update",
                  template: "{controller}/update/{id}",
                  defaults: new { controller = "Student", action = "Update" }
                );


            });
        }
    }
}
