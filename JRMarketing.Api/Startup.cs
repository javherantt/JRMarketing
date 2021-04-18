using AutoMapper;
using FluentValidation.AspNetCore;
using JRMarketing.Application.Services;
using JRMarketing.Domain.Interfaces;
using JRMarketing.Infrastructure.Data;
using JRMarketing.Infrastructure.Filters;
using JRMarketing.Infrastructure.Repositories;
using JRMarketing.Domain.ConstraintMap;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Data;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace JRMarketing.Api
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());           
            services.AddControllers(options => options.Filters.Add<GlobalExceptionFilter>());
            services.AddDbContext<JRMarketingContext>(options => options.UseSqlServer(Configuration.GetConnectionString("JRMarketingEF")));
            services.AddScoped(typeof(IRepository<>), typeof(SQLRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IRestauranteServices, RestauranteServicio>();
            services.AddTransient<IEtiquetumService, EtiquetumService>();
            services.AddTransient<IUsuarioServices, UsuarioService>();
            services.AddTransient<IPublicacionService, PublicacionService>();
            services.AddTransient<IRestauranteEtiquetumService, RestuaranteEtiquetumService>();
            services.AddMvc().AddFluentValidation(options => options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();


            app.UseAuthorization();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
               Path.GetFullPath("C:/Users/Javier Hernández/Documents/Universidad/4° Cuatrimestre/Proyecto Integrador/myimages")),
                RequestPath = "/myimages"
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
