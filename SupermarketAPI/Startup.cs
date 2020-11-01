using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using SupermarketAPI.Domain.Persistance;
using SupermarketAPI.Domain.Persistance.Repositories;
using SupermarketAPI.Domain.Services;
using SupermarketAPI.Persistance.Repositories;
using SupermarketAPI.Services;
using System;

namespace SupermarketAPI
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            var server = Configuration["DBServer"] ?? "localhost";
            var user = Configuration["DBUser"] ?? "SA";
            var password = Configuration["DBPassword"] ?? "password";
            var database = Configuration["DBDatabase"] ?? "SupermarketDB";

            services.AddDbContext<AppDbContext>(opt =>
                     opt.UseSqlServer($"Server={server};Initial Catalog={database};User ID={user};Password={password}"));
            // services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("SupermarketConnection")));
            //services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("supermarket-api-in-memory"));
            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson(s => {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            //using (var serviceScope = app.ApplicationServices.CreateScope())
            //{
            //    var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
            //    context.Categories.Add(new Domain.Models.Category() 
            //    {
            //        Id=1,
            //        Name="gonc"
            //    });
            //    context.SaveChanges();
            //    // Seed the database.
            //}

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            PrepDB.UpdateDatabase(app);

        }
    }
}
