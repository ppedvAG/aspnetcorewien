using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetcorewien.Models;
using aspnetcorewien.Pages.modul02;
using aspnetcorewien.Pages.Modul05;
using aspnetcorewien.Pages.Modul06;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace aspnetcorewien
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
                options.IdleTimeout = new TimeSpan(0, 0, 10);
            }
            );
            services.AddResponseCaching();

            services.AddMvc(options=>
            {
                options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
            }
            ).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSingleton<requestCountcs>();
            services.AddDbContext<northwindContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("nwConnection"));
                });

            services.AddDbContext<AufgabenContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("AufgabenConnection"));
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            AppDomain.CurrentDomain.SetData("wwwroot", env.ContentRootPath + @"\images\");
            app.Map("/geheim.txt", subapp =>
            {
                subapp.Use(async (context, next) =>
                {
                    if (!context.User.Identity.IsAuthenticated)
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;

                    }
                }

                    );
            });
            app.MapWhen(context => context.Request.Path.ToString().Contains("imageloader.ashx"), subapp =>
              {
                  subapp.UseImageLoader();
              });



      app.UseResponseCaching();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();

            app.UseMvc();
        }
    }
}
