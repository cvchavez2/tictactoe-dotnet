using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Tictactoe.Service.Services;

namespace Tictactoe.Service
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
            services.AddCors(options => 
            {
              // options.AddPolicy("Policy1", 
              //   builder => 
              //   {
              //     builder.WithOrigins("https.azureweb.com")
              //                           .AllowAnyHeader()
              //                           .AllowAnyMethod();
              //   });
              options.AddDefaultPolicy(options => 
              {
                options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
              });
            });

            services.AddControllers();
            services.AddScoped<IGameService, GameService>();
            services.AddSwaggerGen(c => 
            {
              c.SwaggerDoc("v1", new OpenApiInfo{
                Version = "v1",
                Title = "Game API",
                Contact =  new OpenApiContact
                {
                  Name = "Carlos Chavez",
                  Email = "carlos.chavezvillalobos@cognizant.com"
                }
              });
              // Set the comments path for the Swagger JSON and UI.
              var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
              var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
              c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseCors();

            app.UseSwaggerUI(c => {
              c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
