﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Eshop.Domain.Mapping;
using Eshop.Domain.Service;
using Eshop.Domain.Service.BaseService;
using Eshop.Entity.Context;
using Eshop.Entity.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Eshop.API
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
            services.AddDbContext<EshopContext>(options => options.UseSqlite("Data Source=eshop.db"));

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(ProductService<,>), typeof(ProductService<,>));
            services.AddTransient(typeof(ShortProductService<,>), typeof(ShortProductService<,>));
            services.AddTransient(typeof(AnimalCategoryService<,>), typeof(AnimalCategoryService<,>));
            services.AddTransient(typeof(OrderService<,>), typeof(OrderService<,>));

            services.AddTransient(typeof(IBaseService<,>), typeof(BaseService<,>));

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Values Api", Version = "v1" });
                c.AddSecurityDefinition("Bearer",
                       new ApiKeyScheme
                       {
                           In = "header",
                           Name = "Authorization",
                           Type = "apiKey"
                       });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
                    { "Bearer", Enumerable.Empty<string>() },
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
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseMvc();

            //Swagger API documentation
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Values Api V1");
            });

            using (var service = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                service.ServiceProvider.GetService<EshopContext>().Seed();
            }
        }
    }
}
