using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using flows.Data;
using flows.Data.Factories;
using flows.Data.Interfaces;
using flows.Domain.Repositories;
using flows.Domain.Repositories.Interfaces;
using flows.Domain.Services;
using flows.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace flows
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => 
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = "ValidIssuer",
                        ValidAudience = "ValidateAudience",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("IssuerSigningSecretKey")),
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IFlowDbContextFactory, FlowDbContextFactory>();
            services.AddScoped<IUserRepository, UserRepository>(provider => new UserRepository(_configuration.GetConnectionString("Database"), provider.GetService<IFlowDbContextFactory>()));
            services.AddScoped<IUserService, UserService>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", context => context.Response.WriteAsync("Hello world"));

                endpoints.MapControllerRoute(
                    name: "DefaultApi",
                    pattern: "api/{controller}/{action}");
                //endpoints.MapFallbackToController("Index", "Home");
            });
        }
    }
}
