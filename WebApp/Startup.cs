using DataAccess;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UseCases.Books.Commands.CreateBookCommand;
using WebApp.Middleware;

namespace WebApp
{
    public class Startup
    {
        private readonly IConfiguration _conf;
        public Startup(IConfiguration configuration)
        {
            _conf = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateBookRequest).Assembly);
            services.AddControllers();
            services.AddDbContext<ApplicationDBContext>(x =>
            {
                x.UseSqlServer(_conf.GetConnectionString("Default"));
            });
            services.AddSwaggerGen(c => 
            { c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Version = "v1", Title = "API" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseMiddleware<ExceptionHandler>();
            app.UseSwagger(c => c.SerializeAsV2 = true);
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API"));
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}