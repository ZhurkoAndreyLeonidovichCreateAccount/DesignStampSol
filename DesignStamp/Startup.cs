using Microsoft.AspNetCore.Builder;
using DataLayer.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuissnesLayer;
using BuissnesLayer.Interfaces;
using BuissnesLayer.Implemetation;

namespace DesignStamp
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
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
               

            })
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders().AddDefaultUI();

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddTransient<IDetailsRepository, EFDetailRepository>();
            services.AddTransient<IAllForcesRepository, EFAllForcesRepository>();
            services.AddTransient<IMatricesRepository, EFMatricesRepository>();
            services.AddTransient<IHoldersRepository, EFHoldersRepository>();
            services.AddTransient<IBottomPlatesRepository, EFBottomPlatesRepository>();
            services.AddTransient<ITopPlatesRepository, EFTopPlatesRepository>();
            services.AddTransient<IPunchMatrixRepository, EFPunchMatrixRepository>();
            services.AddTransient<ISpringsRepository, EFSpringsRepository>();
            services.AddTransient<IPullersRepository, EFPullersRepository>();
            services.AddTransient<IBushingsRepository, EFBushingsRepository>();
            services.AddTransient<IColumnsRepository, EFColumnsRepository>();
            services.AddTransient<IPunchesRepository, EFPunchesRepository>();
            services.AddTransient<IEnlargedPunchesRepository, EFEnlargedPunchesRepository>();
            services.AddTransient<IStampsRepository, EFStampsRepository>();
            services.AddTransient<ICoversRepository, EFCoversRepository>();
            services.AddTransient<IPressesRepository, EFPresesRepository>();
            services.AddTransient<IPunchesIDRepository, EFPunchesIDRepository>();
            services.AddTransient<IEnlargedPunchesIDRepository, EFEnlargedPunchesIDRepository>();
           




            services.AddScoped<DataManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            app.UseDeveloperExceptionPage();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            DbInitializer.Seed(context, userManager, roleManager)
                       .GetAwaiter()
                           .GetResult();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Calculation}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
