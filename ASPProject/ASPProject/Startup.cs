using ASPProject.Models;
using ASPProject.Models.Constants;
using ASPProject.Models.Entities;
using ASPProject.Models.OtherServices;
using ASPProject.Repositories;
using ASPProject.Repositories.CrudRepository;
using ASPProject.Seed;
using ASPProject.Services.OtherServices;
using ASPProject.Services.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProject
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ASPProject", Version = "v1" });
            });

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer("Data Source=localhost\\SQLEXPRESS01;Initial Catalog=DAW_Project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                

                
            });

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthorization(options =>
            {
                options.AddPolicy(UserRoleType.Admin, policy => policy.RequireRole(UserRoleType.Admin));
                options.AddPolicy(UserRoleType.User, policy => policy.RequireRole(UserRoleType.User));
            });

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom secret key for auth")),
                    ValidateIssuerSigningKey = true
                };
                options.Events = new JwtBearerEvents()
                {
                    OnTokenValidated = Helpers.SessionTokenValidator.ValidateSessionToken
                };
            });

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderManager, OrderManager>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductManager, ProductManager>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryManager, CategoryManager>();

            services.AddScoped<SeedDb>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, SeedDb seed, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ASPProject v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            try
            {
                seed.SeedRoles().Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
