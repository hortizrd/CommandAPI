using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CommandAPI.Models;
using AutoMapper;


using CommandAPI.Data;
using Newtonsoft.Json.Serialization;

namespace CommandAPI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddDbContext<Data.CommandContext>(options =>
                 options.UseSqlServer(
                     Configuration.GetConnectionString("DefaultConn"),
                     b => b.MigrationsAssembly(typeof(CommandContext).Assembly.FullName)));
            //services.AddScoped<ICommandContext>(provider => provider.GetService<CommandContext>());
            services.AddScoped<ICommandAPIRepo, SqlCommandAPIRepo>();
            services.AddControllers();

            //AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers().AddNewtonsoftJson(s =>
            {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
            //

           // services.AddScoped<ICommandAPIRepo, MockCommandAPIRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllers();
                /*
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Bienvenidos a mi proyecto de API!");
                });
                
                */
            });
        }
    }
}
