using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllLook.Database;
using AllLook.Database.Interfaces;
using AllLook.Database.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Server.Services;

namespace Server
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
            
            //http clients
            services.AddHttpClient<ISearchCode, SearchCode>(c =>
            {

            });
            services.AddHttpClient<ISearchService, SearchService>(c =>
            {
                c.BaseAddress = new Uri("https://allegro.pl/auth/oauth/token");

            });
            services.AddHttpClient<IAllegroService, AllegroService>(c =>
            {
                c.BaseAddress = new Uri("https://api.allegro.pl");
                c.DefaultRequestHeaders.Add("Accept", "application/vnd.allegro.public.v1+json");
            });

            //json settings
            services.Configure<AllLookDatabaseSettings>(Configuration.GetSection("AllLookDatabaseSettings"));
            services.Configure<ClientSettings>(Configuration.GetSection("Client"));
            //database
            services.AddSingleton<IDatabaseProductService, DatabaseProductService>();
            services.AddSingleton<IDatabaseDeviceFlowAuthorization, DatabaseDeviceFlowAuthorization>();
            services.AddSingleton<IDatabaseTokenService, DatabaseTokenService>();
           
            services.AddControllers();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "Server", Version = "v1"}); });
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Server v1"));
            }
            
            //Cors settings
            app.UseCors(builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });

            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}