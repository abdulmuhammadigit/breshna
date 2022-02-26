using System;
using System.IO;
using Pro.DataAccess;
using Pro.IocConfig;
using Pro.IocConfig.Api.Middlewares;
using Pro.IocConfig.Api.Swagger;
using Pro.ViewModels.DynamicAccess;
using Pro.ViewModels.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using ReflectionIT.Mvc.Paging;

using Pro.IocConfig.AutoMapper;

namespace Pro
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IServiceProvider Services { get; }
        private readonly SiteSettings SiteSettings;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            SiteSettings = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
        }
        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<SiteSettings>(Configuration.GetSection(nameof(SiteSettings)));
            services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlServer")));
            services.AddCustomServices();
            services.AddCustomIdentityServices();
            //services.AddScheduler();
            services.AddApiVersioning();
            services.AddSwagger();
            services.AddCustomAuthentication(SiteSettings);
            services.ConfigureWritable<SiteSettings>(Configuration.GetSection("SiteSettings"));
            services.AddControllers().AddNewtonsoftJson();
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            services.AddAuthorization(options =>
            {
                options.AddPolicy(ConstantPolicies.DynamicPermission, policy => policy.Requirements.Add(new DynamicPermissionRequirement()));
            });

            services.AddSingleton<HtmlEncoder>(
             HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.BasicLatin,
                                               UnicodeRanges.Arabic }));
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Admin/Manage/SignIn";
                options.LogoutPath = "/Admin/Manage/SignOut";
                options.AccessDeniedPath = "/Admin/Manage/AccessDenied";

            });
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfiles());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc();

            services.AddPaging(options =>
            {
                options.ViewName = "Bootstrap4";
                options.HtmlIndicatorDown = "<i class='fa fa-sort-amount-down'></i>";
                options.HtmlIndicatorUp = "<i class='fa fa-sort-amount-up'></i>";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var cachePeriod = env.IsDevelopment() ? "600" : "605800";
            app.UseWhen(context => context.Request.Path.StartsWithSegments("/api"), appBuilder =>
            {
                appBuilder.UseCustomExceptionHandler();
            });

            app.UseWhen(context => !context.Request.Path.StartsWithSegments("/api"), appBuilder =>
            {
                if (env.IsDevelopment())
                    appBuilder.UseDeveloperExceptionPage();
                else
                    appBuilder.UseExceptionHandler("/Home/Error");
            });


            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "CacheFiles")),
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Append("Cache-Control", $"public,max-age={cachePeriod}");
                },
                RequestPath = "/CacheFiles",
            });


            app.UseStaticFiles();

            app.UseCustomIdentityServices();

            //var provider = app.ApplicationServices;

            //provider.UseScheduler(scheduler =>
            //{
            //    //scheduler.Schedule<SendWeeklyNewsletter>().EveryMinute();
            //    scheduler.Schedule<SendWeeklyNewsletter>().Cron("29 20 * * 5"); //UTC Time
            //    //scheduler.Schedule<SendWeeklyNewsletter>().Cron("14 15 * * 0"); //UTC Time
            //});

            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404)
                {
                    context.Request.Path = "/home/error404";
                    await next();
                }
            });

            app.UseSwaggerAndUI();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(routes =>
            {
                routes.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
                routes.MapControllerRoute(
                 name: "default",
                 pattern: "{controller=Home}/{action=Index}/{id?}"
               );
            });
        }
    }
}
