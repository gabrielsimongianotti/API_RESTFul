using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restudemy.Model.Context;
using Restudemy.Services;
using Restudemy.Services.inplementattions;

namespace Restudemy
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration configuration;
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration["MySqlConnection:MySqlConnectionString"];
            //services.AddDbContext<MySQLContext>(options => options.UseMySql(connection));
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connection));
            services.AddMvc();
            //injeção de dependencias
            services.AddScoped<IPersonService, PersonServiceImpl>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
