﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System.Text;
using AutoMapper.Extensions.ExpressionMapping;
using FinalCourseAssignment.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using FinalCourseAssignment.Domain;
using FinalCourseAssignment.Data.Repositories;

namespace FinalCourseAssignment.Api.Middleware
{
    public static class ServiceCollectionExtensions
    {
        public static void AddFinalAssignmentSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Event Manager Api", Version = "v1" });
                //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                //    Type = SecuritySchemeType.ApiKey,
                //    BearerFormat = "JWT",
                //    In = ParameterLocation.Header,
                //    Name = "Authorization"
                //});
                //c.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //    {
                //        new OpenApiSecurityScheme
                //        {
                //            Reference = new OpenApiReference
                //            {
                //                Type = ReferenceType.SecurityScheme,
                //                Id = "Bearer"
                //            }
                //        },
                //        new string[]{}
                //    }
                //});
            });
        }

        public static void AddFinalAssignmentRepositories(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void AddFinalAssignmentServices(this IServiceCollection services)
        {
            services.AddAutoMapper(mc =>
            {
                mc.AddExpressionMapping();
                mc.AddProfile(new Data.MapperProfile());
                mc.AddProfile(new Api.MapperProfile());
                mc.AddProfile(new Services.MapperProfile());
            });
        }

        public static void UseCors(this IApplicationBuilder app, CorsSettings corsSettings)
        {
            var defaultValue = new string[] { "*" };

            app.UseCors(x => x
                .WithOrigins(corsSettings?.Origins ?? defaultValue)
                .WithMethods(corsSettings?.Methods ?? defaultValue)
                .WithHeaders(corsSettings?.Headers ?? defaultValue));
        }
    }
}
