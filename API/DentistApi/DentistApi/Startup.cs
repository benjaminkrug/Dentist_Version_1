namespace mainApi
{
    using DentistBuisness.Repositories.Gebiss;
    using DentistBuisness.Termine;
    using DentistDB;
    using DentistDB.Repositories.Arzt;
    using DentistDB.Repositories.Gebiss;
    using DentistDB.Repositories.Termine;
    using DentistDB.Repositories.User;
    using DentistDB.Repositories.Zahn;
    using IdentityServerKoenigsleiten.Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.HttpsPolicy;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration config, IWebHostEnvironment env)
        {
            _config = config;
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = "";
            if (_env.IsDevelopment())
            {
                connectionString = _config.GetConnectionString("DefaultConnection");
            }
            else
            {
                connectionString = _config.GetConnectionString("DefaultConnection");
            }

            services.AddScoped<IGebissRepository, GebissRepository>();
            services.AddScoped<IZahnRepository, ZahnRepository>();
            services.AddScoped<ITermineRepository, TermineRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IArztRepository, ArztRepository>();
            services.AddScoped<IGebissLogic, GebissLogic>();
            services.AddScoped<ITermineLogic, TermineLogic>(); 

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  builder.WithOrigins("http://localhost:8080",
                                      "https://silly-galileo-6b0d56.netlify.app").AllowAnyHeader().AllowAnyMethod().AllowCredentials()
                                  );
            });


            services.AddScoped<IDapper, Dapper>();
            services.AddScoped<DentistDB.Services.IDapper, DentistDB.Services.Dapper>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
