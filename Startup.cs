using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using UndergroundInnovation.Models;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using UndergroundInnovation.Data;
using Microsoft.EntityFrameworkCore;
using UndergroundInnovation.Services;
using System.Threading.Tasks;
using OpenIddict.Core;
using OpenIddict.Models;
using System.Threading;
using underground_innovation.Middleware;
using Microsoft.AspNetCore.HttpOverrides;
using underground_innovation.Models;
using AspNet.Security.OpenIdConnect.Primitives;

namespace UndergroundInnovation
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services. TODO: Move to mysql
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection"));
                options.UseOpenIddict();
            });

            // Configure Entity Framework Initializer for seeding
            services.AddTransient<IDefaultDbContextInitializer, DefaultDbContextInitializer>();


            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            //.AddJwtBearer(options =>
            //{
            //    options.Authority = "http://localhost:30940/";
            //    options.Audience = "resource-server";
            //    options.RequireHttpsMetadata = false;
            //})

            .AddOAuthValidation();

            // Configure OpenIddict for JSON Web Token (JWT) generation (Ref: http://capesean.co.za/blog/asp-net-5-jwt-tokens/)
            // Register the OpenIddict services.
            // Note: use the generic overload if you need
            // to replace the default OpenIddict entities.
            services.AddOpenIddict(options =>
            {
                // Register the Entity Framework stores.
                options.AddEntityFrameworkCoreStores<ApplicationDbContext>();

                // Register the ASP.NET Core MVC binder used by OpenIddict.
                // Note: if you don't call this method, you won't be able to
                // bind OpenIdConnectRequest or OpenIdConnectResponse parameters.
                options.AddMvcBinders();

                // Enable the token endpoint (required to use the password flow).
                options.EnableTokenEndpoint("/api/auth/login");

                // Allow client applications to use the grant_type=password flow.
                options.AllowPasswordFlow();

                // During development, you can disable the HTTPS requirement.
                options.DisableHttpsRequirement();

                options.AllowRefreshTokenFlow();
                options.UseJsonWebTokens();
                options.AddEphemeralSigningKey();
                options.SetAccessTokenLifetime(TimeSpan.FromDays(1));
            });

            // Don't redirect, we're an API only, just return 401
            services.ConfigureApplicationCookie(options =>
            {
                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                };
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.ClaimsIdentity.UserNameClaimType = OpenIdConnectConstants.Claims.Name;
                options.ClaimsIdentity.UserIdClaimType = OpenIdConnectConstants.Claims.Subject;
                options.ClaimsIdentity.RoleClaimType = OpenIdConnectConstants.Claims.Role;
            });

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IDefaultDbContextInitializer databaseInitializer)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            // Apply any pending migrations
            // Do not call EnsureCreated() b/c it does not log to _EFMigrationsHistory table (Ref: https://github.com/aspnet/EntityFramework/issues/3875)
            databaseInitializer.Migrate();
            databaseInitializer.Seed();

            app.UseAuthentication();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseSpaFallback(new SpaFallbackOptions()
            {
                ApiPathPrefix = "/api",
                RewritePath = "/"
            });

            app.UseStaticFiles();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                // Read and use headers coming from reverse proxy: X-Forwarded-For X-Forwarded-Proto
                // This is particularly important so that HttpContet.Request.Scheme will be correct behind a SSL terminating proxy
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });


            // Register the validation middleware, that is used to decrypt
            // the access tokens and populate the HttpContext.User property.
            // app.UseOAuthValidation();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.Clear();

            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                //routes.MapSpaFallbackRoute(
                //    name: "spa-fallback",
                //    defaults: new { controller = "Home", action = "Index" });
            });

            // app.UseOpenIddict<int>();
        }

        private async Task InitializeAsync(IServiceProvider services, CancellationToken cancellationToken)
        {
            // Create a new service scope to ensure the database context is correctly disposed when this methods returns.
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                await context.Database.EnsureCreatedAsync();

                var manager = scope.ServiceProvider.GetRequiredService<OpenIddictApplicationManager<OpenIddictApplication>>();

                if (await manager.FindByClientIdAsync("underground-innovation", cancellationToken) == null)
                {
                    var descriptor = new OpenIddictApplicationDescriptor
                    {
                        ClientId = "underground-innovation",
                        ClientSecret = "371f8b6e-9b09-408c-8e8b-78c55f7b5420",
                        DisplayName = "Underground Innovation",
                        PostLogoutRedirectUris = { new Uri("http://localhost:53507/signout-callback-oidc") },
                        RedirectUris = { new Uri("http://localhost:53507/signin-oidc") }
                    };

                    await manager.CreateAsync(descriptor, cancellationToken);
                }

                // To test this sample with Postman, use the following settings:
                //
                // * Authorization URL: http://localhost:54540/connect/authorize
                // * Access token URL: http://localhost:54540/connect/token
                // * Client ID: postman
                // * Client secret: [blank] (not used with public clients)
                // * Scope: openid email profile roles
                // * Grant type: authorization code
                // * Request access token locally: yes
                if (await manager.FindByClientIdAsync("postman", cancellationToken) == null)
                {
                    var descriptor = new OpenIddictApplicationDescriptor
                    {
                        ClientId = "postman",
                        DisplayName = "Postman",
                        RedirectUris = { new Uri("https://www.getpostman.com/oauth2/callback") }
                    };

                    await manager.CreateAsync(descriptor, cancellationToken);
                }
            }
        }

    }
}
