using AutoMapper;
using BattleRoyaleSolutions.Data;
using BattleRoyaleSolutions.IOC;
using BattleRoyaleSolutions.Web.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BattleRoyaleSolutions.Web
{
    public class Startup
    {
        public static ServiceProvider Provider { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<MachineRemoteControlContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("BattleRoyaleSolutionsContext")));

            services.AddAutoMapper();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            services.AddCors(options => options.AddPolicy("CorsPolicy",
                 builder =>
                 {
                     builder.AllowAnyMethod().AllowAnyHeader()
                            .WithOrigins("http://localhost:60748")
                            .AllowCredentials();
                 }));

            //Add SignalR as part of the middleware pipeline
            services.AddSignalR();

            Provider = services.BuildServiceProvider();

            DependencyInjectionResolver.RegisterServices(services);
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
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseCors(cors =>
            {
                cors.AllowAnyOrigin();
            });

            app.UseSignalR(routes =>
            {
                routes.MapHub<ApplicationHub>("/hub");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
