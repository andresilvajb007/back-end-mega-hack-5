using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using back_end_mega_hack_5.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;

namespace back_end_mega_hack_5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            // Filter out ASP.NET Core infrastructre logs that are Information and below
            .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .WriteTo
            .Console()
            .CreateLogger();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            var conn = $"Host={Environment.GetEnvironmentVariable("HOST_DB")}; Port={Environment.GetEnvironmentVariable("PORT")};Database={Environment.GetEnvironmentVariable("DATABASE")};Username={Environment.GetEnvironmentVariable("USERNAME")};Password={Environment.GetEnvironmentVariable("PASSWORD")};SSL Mode=Require; Trust Server Certificate=true;";
            services.AddDbContext<Context>(options => options.UseNpgsql(conn));


            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Version = "V1", Description = "API de Credito para o APP" });

                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });

                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
            });

            var key = Encoding.ASCII.GetBytes(Settings.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSerilogRequestLogging();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();                
            }
            

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI(v1)");
            }
             );

            //app.UseHttpsRedirection();

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
