using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restudemy.Model.Context;
using Restudemy.Business;
using Restudemy.Business.inplementattions;
using Restudemy.Repository;
using Restudemy.Repository.inplementattions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Restudemy.Repository.Generic;
using Microsoft.Net.Http.Headers;

namespace Restudemy
{
    public class Startup
    {
        private readonly ILogger _logger;
        private IHostingEnvironment _environment { get; }
        public IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration, IHostingEnvironment environment, ILogger<Startup> logger)
        {
            _configuration = configuration;
            _environment = environment;
            _logger = logger;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration["MySqlConnection:MySqlConnectionString"];
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connectionString));

            if (_environment.IsDevelopment())
            {
                try
                {
                    var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);

                    var evolve = new Evolve.Evolve("Evolve.json", evolveConnection, msg => _logger.LogInformation(msg))
                    {
                        Locations = new List<string> { "db/migrations","db/dataset" },
                        IsEraseDisabled = true,
                    };

                    evolve.Migrate();

                }
                catch (Exception ex)
                {
                    _logger.LogCritical("Database migration failed.", ex);
                    throw;
                }
            }


            services.AddMvc(options => 
            {
                options.RespectBrowserAcceptHeader = true;
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("text/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
            }).AddXmlSerializerFormatters();

            services.AddApiVersioning(option => option.ReportApiVersions = true);

            //Dependency Injection
            services.AddScoped<IPersonBusiness, PersonBusinessImpl>();
            services.AddScoped<IBooksBusiness, BookBusinessImpl>();
            services.AddScoped<IPersonRepository, PersonRepositoryImpl>();
            services.AddScoped(typeof(IRepository<>),typeof(GenericRepository<>));

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
