using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Radzen;
using Saweat.Application;
using Saweat.Infrastructure;
using Saweat.Persistence;
using Saweat.Persistence.Contexts;
using System;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;

namespace Saweat.Web.Admin
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        partial void OnConfigureServices(IServiceCollection services);

        partial void OnConfiguringServices(IServiceCollection services);

        public void ConfigureServices(IServiceCollection services)
        {
            this.OnConfiguringServices(services);
            services
                .AddAuth0WebAppAuthentication(options =>
                {
                    options.Domain = this.Configuration["Auth0:Domain"];
                    options.ClientId = this.Configuration["Auth0:ClientId"];
                });

            services.AddHttpContextAccessor();
            services.AddScoped<HttpClient>(serviceProvider =>
            {

                var uriHelper = serviceProvider.GetRequiredService<NavigationManager>();

                return new HttpClient
                {
                    BaseAddress = new Uri(uriHelper.BaseUri)
                };
            });

            services.AddHttpClient();

            services.AddRazorPages();
            services.AddServerSideBlazor().AddHubOptions(o =>
            {
                o.MaximumReceiveMessageSize = 10 * 1024 * 1024;
            });

            services.AddScoped<DialogService>();
            services.AddScoped<NotificationService>();
            services.AddScoped<TooltipService>();
            services.AddScoped<ContextMenuService>();

            services.AddInfrastructureServices();

            services.AddPersistenceServices(() =>
            {
#if DEBUG
                return this.Configuration.GetConnectionString("DebugConnectionString");
#endif 
                return this.Configuration.GetConnectionString("SaweatDBConnectionString");
            });

            services.AddApplicationServices();
            this.OnConfigureServices(services);
        }

        partial void OnConfigure(IApplicationBuilder app, IWebHostEnvironment env);
        partial void OnConfiguring(IApplicationBuilder app, IWebHostEnvironment env);

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            this.OnConfiguring(app, env);
            if (env.IsDevelopment())
            {
                Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.Use((ctx, next) =>
                {
                    return next();
                });
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });


            using (var service = app.ApplicationServices.CreateScope())
            {
                using (var appContext = service.ServiceProvider.GetRequiredService<SaweatDbContext>())
                {
                    appContext.Migrate();
                }
            }

            this.OnConfigure(app, env);
        }
    }


}
