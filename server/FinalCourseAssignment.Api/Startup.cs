using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using FinalCourseAssignment.Api.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using System.Text.Json.Serialization;
using FinalCourseAssignment.Domain;
using FinalCourseAssignment.Data.Repositories;
using FinalCourseAssignment.Services.Services;
using FinalCourseAssignment.Data;

namespace FinalCourseAssignment.Api
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
            services.AddCors();

            services.AddControllers();

            services.AddAutofac();
            services.AddHttpContextAccessor();
            services.AddLogging();

            services.AddFinalAssignmentSwagger();
          
            //services.AddFinalAssignmentAuth(Configuration);
            services.AddFinalAssignmentRepositories(Configuration);
            //services.AddFinalAssignmentServices();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ErrorHandlerMiddleware>();

            //dbcontext.Database.Migrate();

            app.UseRouting();

            app.UseCors(Configuration.GetSection("Cors").Get<CorsSettings>());

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Gateway v1");
            });


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
