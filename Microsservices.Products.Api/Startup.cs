using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsservices.Products.Api.AutoMapper;
using Microsservices.Products.Application.App;
using Microsservices.Products.Application.Services;
using Microsservices.Products.Domain.Contracts.Application;
using Microsservices.Products.Domain.Contracts.Repositories;
using Microsservices.Products.Domain.Contracts.Services;
using Microsservices.Products.Infra.Context;
using Microsservices.Products.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsservices.Products.Api
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

            //AutoMapper

            services.AddAutoMapper(typeof(MapperSetup));
            services.AddDbContext<ProductDataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ProductDB")));

            //Injeção de Dependecia
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductApplication, ProductApplication>();
            services.AddScoped<IProductService, ProductService>();

            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
