using AutoMapper;
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
using Online_platform_for_vegetables.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_platform_for_vegetables
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


            services.AddCors(options => options.AddDefaultPolicy(

                builder => builder.WithOrigins("http://localhost:4201").AllowAnyMethod().AllowAnyHeader()));


            services.AddDbContext<DatabaseContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DatabaseContext_1")));
            services.AddIdentity<Admin, IdentityRole>().AddEntityFrameworkStores<DatabaseContext>();
            services.AddIdentity<Farmer, IdentityRole>().AddEntityFrameworkStores<DatabaseContext>();
            services.AddIdentity<Customer, IdentityRole>().AddEntityFrameworkStores<DatabaseContext>();
            services.AddIdentity<Courier, IdentityRole>().AddEntityFrameworkStores<DatabaseContext>();

            var mappingConfig = new MapperConfiguration(c =>
              {
                  c.AddProfile(new Mappingprofile());


              });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
