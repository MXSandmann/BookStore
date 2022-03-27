using DataAccess;
using Infrastructure.JwtToken;
using Infrastructure.UserProvider;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
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
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Version = "v1", Title = "API" });
                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
                {
                    Description = "BearerAuth",
                    Name = "Authorization",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
                {
                    { new OpenApiSecurityScheme
                        {
                            Reference = new Microsoft.OpenApi.Models.OpenApiReference()
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]
                        {

                        }
                    }
                });
                
            });

            var jwtOptions = _conf.GetSection(nameof(JwtOptions)).Get<JwtOptions>();
            services.AddSingleton(jwtOptions);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = jwtOptions.GetKey(),
                        ValidateIssuer = true,
                        ValidIssuer = jwtOptions.Issuer,
                        ValidateAudience = true,
                        ValidAudience = jwtOptions.Audience
                    };
                });
            services.AddSingleton<IJwtTokenProvider, JwtTokenProvider>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ICurrentUserProvider, CurrentUserProvider>();
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
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
