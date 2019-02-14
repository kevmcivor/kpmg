using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using News.Domain.Interfaces;
using News.Infrastructure.Repositories;
using News.Infrastructure;
using Microsoft.EntityFrameworkCore;
using NJsonSchema;
using NSwag.AspNetCore;
using System.IdentityModel.Tokens.Jwt;
using FluentValidation.AspNetCore;
using FluentValidation;
using News.API.Models;
using News.API.Validators;

namespace News.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddFluentValidation();

            services.AddMvcCore()
                .AddAuthorization(options => options.AddPolicy("Admin", policy => policy.RequireClaim("Role", "Admin")))
                .AddAuthorization(options => options.AddPolicy("Employee", policy => policy.RequireClaim("Role", "Employee")))
                .AddJsonFormatters();

            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
            });

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "http://localhost:5000";
                    options.RequireHttpsMetadata = false;
                    options.Audience = "api1";
                });

            services.AddCors(options =>
            {
                options.AddPolicy("default", policy =>
                {
                    policy.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.AddAutoMapper();
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Title = "News API";
                    document.Info.Description = "Pressford Consulting News API";
                };
            });

            services.AddSingleton<IValidator<ArticleCreateDto>, ArticleCreateValidator>();
            services.AddTransient<IArticleRepository, ArticleRepository>();

            //connection should be environment variable
            services.AddDbContext<NewsContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
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
                //app.UseExceptionHandler();
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUi3();

            app.UseHttpsRedirection();
            app.UseCors("default");
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
