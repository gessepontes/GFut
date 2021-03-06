﻿using GFut.Infra.Data.Context;
using GFut.Infra.IoC;
using GFut.Services.Api.Configurations;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace GFut.Services.Api
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
            services.AddDirectoryBrowser();

            //services.addsingleton<ifileprovider>(
            //    new physicalfileprovider(
            //        path.combine(directory.getcurrentdirectory(), "wwwroot")));


            var config = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(config));

            services.AddMvc();

            services.AddAutoMapperSetup();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "GFut Project",
                    Description = "GFut API Swagger surface",
                    TermsOfService = new Uri("http://www.gfut.com.br")
                });
            });

            // .NET Native DI Abstraction
            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            /*  if (env.IsDevelopment())
              {
                  app.UseDeveloperExceptionPage();
              }

              app.UseStaticFiles(new StaticFileOptions
              {
                  FileProvider = new PhysicalFileProvider(
                      Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "picture")),
                  RequestPath = "/picture"
              });

              loggerFactory.AddConsole(Configuration.GetSection("Logging"));
              loggerFactory.AddFile($"Logs/Api.Log.txt");
              loggerFactory.AddDebug();

              app.UseCors(c =>
              {
                  c.AllowAnyHeader();
                  c.AllowAnyMethod();
                  c.AllowAnyOrigin();
              });

              app.UseMvc();

              app.UseSwagger();
              app.UseSwaggerUI(s =>
              {
                  s.SwaggerEndpoint("/swagger/v1/swagger.json", "GFut API v1.1");
              });
            */

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "GFut API v1.1");
            });

        }

        private static void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            NativeInjectorConfig.RegisterServices(services);
        }
    }
}
