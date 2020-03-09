﻿using AspNetCore.RouteAnalyzer;
using Banico.Api;
using Banico.EntityFrameworkCore;
using Banico.Identity;
using Banico.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Banico.Web
{
    public class WebStartup
    {
        private bool developmentEnvironment = false;
        private IWebHostEnvironment CurrentEnvironment{ get; set; } 
        private IdentityStartup identityStartup;
        private DataStartup dataStartup;
        private ApiStartup apiStartup;
        private ServicesStartup servicesStartup;

        public void Init(IConfiguration configuration, IWebHostEnvironment env)
        {
            this.Configuration = configuration;
            this.CurrentEnvironment = env;
 
             if (env.IsDevelopment())
            {
                this.developmentEnvironment = true;
            }

            identityStartup = new IdentityStartup(configuration, this.developmentEnvironment);
            dataStartup = new DataStartup();
            apiStartup = new ApiStartup();
            servicesStartup = new ServicesStartup();
       }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string envName = this.CurrentEnvironment.EnvironmentName;
            Console.WriteLine("Environment is " + envName + ".");
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            Console.WriteLine("ASP.Net Core Environment Variable is is " + env + ".");

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSingleton<IConfiguration>(this.Configuration);
      
            services.Configure<EmailSenderOptions>(this.Configuration.GetSection("EmailSender"));
            //services.AddAntiforgery(opts => opts.HeaderName = "X-XSRF-Token");
            services.AddAntiforgery(opts =>
                {
                    //opts.Cookie.Name = "XSRF-TOKEN";
                    opts.HeaderName = "X-XSRF-TOKEN";
                }
            );

            servicesStartup.ConfigureServices(services);
            identityStartup.ConfigureServices(services);
            dataStartup.ConfigureServices(this.Configuration, services);
            apiStartup.ConfigureServices(services);

            // services.AddMvc(opts =>
            // {
            //     opts.Filters.AddService(typeof(AngularAntiforgeryCookieResultFilter));
            // })
            services.AddMvc(
                options => options.EnableEndpointRouting = false
            )
                .AddFluentValidation(fv => {
                    fv.RegisterValidatorsFromAssemblyContaining<IdentityStartup>();
                    fv.RegisterValidatorsFromAssemblyContaining<Startup>();
                })
                //.SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                .AddApplicationPart(typeof(ApiStartup).Assembly)
                .AddApplicationPart(typeof(IdentityStartup).Assembly);
            // services.AddTransient<AngularAntiforgeryCookieResultFilter>();
            
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddRouteAnalyzer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app, 
            IWebHostEnvironment env, 
            IAntiforgery antiforgery,
            IServiceProvider services)
        {
            dataStartup.Configure(app, env);
            identityStartup.Configure(app, env, services);
            apiStartup.Configure(app, env);

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseAuthentication();            
            app.Use(next => context =>
                {
                    string path = context.Request.Path.Value;
                    
                    if (path.ToLower().Contains("/account")) {
            //         if (
            // string.Equals(path, "/", StringComparison.OrdinalIgnoreCase) ||
            // string.Equals(path, "/index.html", StringComparison.OrdinalIgnoreCase)) {
                        // The request token can be sent as a JavaScript-readable cookie, 
                        // and Angular uses it by default.
                        var tokens = antiforgery.GetAndStoreTokens(context);
                        context.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken, 
                            new CookieOptions() { HttpOnly = false });
                    }

                    return next(context);
                }
            );

            app.UseHttpsRedirection();
            // app.UseMiddleware<AntiForgeryMiddleware>("XSRF-TOKEN");
            app.UseJwtTokenMiddleware();
            app.UseCookiePolicy();
            app.UseGraphiQl();
        }
    }

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseAntiforgeryTokenMiddleware(this IApplicationBuilder builder, string requestTokenCookieName)
        {
            return builder.UseMiddleware<AntiForgeryMiddleware>(requestTokenCookieName);
        }
    }

    public class AntiForgeryMiddleware
    {
        private readonly RequestDelegate next;
        private readonly string requestTokenCookieName;
        private readonly string[] httpVerbs = new string[] { "GET", "HEAD", "OPTIONS", "TRACE" };

        public AntiForgeryMiddleware(RequestDelegate next, string requestTokenCookieName)
        {
            this.next = next;
            this.requestTokenCookieName = requestTokenCookieName;
        }

        public async Task Invoke(HttpContext context, IAntiforgery antiforgery)
        {
            if (httpVerbs.Contains(context.Request.Method, StringComparer.OrdinalIgnoreCase))
            {
                if (context.User.Identity.IsAuthenticated) {
                    var tokens = antiforgery.GetAndStoreTokens(context);
                
                    context.Response.Cookies.Append(requestTokenCookieName, tokens.RequestToken, new CookieOptions()
                    {
                        HttpOnly = false
                    });
                }
            }      

            await next.Invoke(context);
        }
    }
}
