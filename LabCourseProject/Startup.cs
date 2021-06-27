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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication;
using LabCourseProject.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using LabCourseProject.Services;
using Microsoft.AspNetCore.Identity;
using LabCourseProject.Data;
using Microsoft.EntityFrameworkCore;

namespace LabCourseProject
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
            services.AddAuthentication()
                    .AddIdentityServerJwt();

            services.AddDbContext<IdentityContext>(opt =>
                opt.UseSqlServer("data source=localhost; database=Tourism; persist security info = True; Integrated Security = SSPI;"));

            //services.AddDbContext<DataContext>(opt =>
            //                                opt.UseInMemoryDatabase("Information"));

            services.AddDbContext<DataContext>(opt =>
                opt.UseSqlServer("data source=localhost; database=Tourism; persist security info = True; Integrated Security = SSPI;"));

            services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<IdentityContext>();

            services.AddScoped<IIdentityService, IdentityService>();

            var jwtSettings = new JwtSettings();
            Configuration.Bind(nameof(jwtSettings), jwtSettings);
            services.AddSingleton(jwtSettings);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
                    ValidateIssuer = false,
                    ValidateAudience = false, 
                    RequireExpirationTime = false,
                    ValidateLifetime = true
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder => builder.AllowAnyOrigin()
                                          .AllowAnyMethod()
                                          .AllowAnyHeader());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

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
