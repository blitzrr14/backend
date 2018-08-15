using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using service.interfaces;
using service;
using repository.interfaces;
using repository;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using AutoMapper;

namespace webapi
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
            
            services.Configure<IISOptions>(options => 
            {
                options.ForwardClientCertificate = false;
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(jwtBearerOptions =>
                    {
                        jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
                        {
                            ValidateActor = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = Configuration["Issuer"],
                            ValidAudience = Configuration["Audience"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SigningKey"]))
                        };
                    });

            services.AddTransient<IUserLogic,UserLogic>();
            services.AddTransient<IRepository,Repository<UserContext>>();

        //    services.AddDbContext<UserContext>(options =>options.UseSqlServer("Data Source=rafflerdb.cd7bcjuxuj1p.us-east-2.rds.amazonaws.com;Initial Catalog=testEFDB;Persist Security Info=True;User ID=rafflerdb2018;Password=jmkws2018;MultipleActiveResultSets=True", b => b.MigrationsAssembly("webapi")));
            services.AddDbContext<RafflerContext>(options =>options.UseSqlServer("Data Source=rafflerdb.cd7bcjuxuj1p.us-east-2.rds.amazonaws.com;Initial Catalog=RafflerDevDB;Persist Security Info=True;User ID=rafflerdb2018;Password=jmkws2018;MultipleActiveResultSets=True", b => b.MigrationsAssembly("webapi")));
            
            services.AddAutoMapper();
            services.AddMvc();
            services.AddSwaggerGen(i =>
            {
                i.SwaggerDoc("0.1.0", new Info { Title = "webapi", Version = "0.1.0" });
                i.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                i.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer", new string[] { } }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseSwagger();
            app.UseSwaggerUI(i => { i.SwaggerEndpoint("/swagger/0.1.0/swagger.json", "RafflerAPI"); });
            app.UseMvc();
        }
    }
}
