using App.Web.Repositories;
using App.Web.Models.Interfaces;
using App.Web.Business;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using App.Web.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace App.Web
{
    public class Startup
    {

        public IConfiguration Configuration{get;}
        public Startup(IConfiguration configuration )
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("Default");
            services.AddDbContext<ApplicationContext>(
                options
                => options.UseSqlServer(connectionString));

            services.AddIdentity<Usuario, Role>()
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();

            services.AddMvc(p => p.EnableEndpointRouting = false);

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 6;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;

            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            services.AddScoped<IFuncionario, FuncionarioBusiness>();
            services.AddScoped<IAcomodacao, AcomodacaoBusiness>();
            services.AddTransient<IDataService, DataService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapGet("/", async context =>
            //     {
            //         await context.Response.WriteAsync("Hello World!");
            //     });
            // });
            app.UseMvc(
                route => {
                    route.MapRoute(
                        name: "Default",
                        template:"{controller=Account}/{action=Login}/{id?}"
                    );
                }
            );

            serviceProvider.GetService<IDataService>().SeedDatabase();
            CreateRoles(serviceProvider).Wait();
        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<Usuario>>();

            string[] rolesNames = { "Administrador", "Operador", "Usuario" };

            IdentityResult result;

            foreach (var item in rolesNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(item);

                if (!roleExist)
                {
                    result = await roleManager.CreateAsync(new Role { Name = item });
                }
            }
        }

    }
}
