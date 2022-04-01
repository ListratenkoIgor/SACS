using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SACS_Server.Data;
using SACS_Server.Authentification;
using Microsoft.AspNetCore.Identity;

namespace SACS_Server
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
            //services.AddDbContextFactory<ApplicationDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("LocalDB")));
            //services.AddDbContextFactory<AuthentificationDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("AuthDB")));
            services.AddDbContext<ApplicationDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("LocalDB")));
            services.AddDbContext<AuthentificationDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("AuthDB")));
            services.AddIdentity<IdentityUser, IdentityRole>(opts => {
                opts.Password.RequireNonAlphanumeric = false;   // требуются ли не алфавитно-цифровые символы
                opts.Password.RequireLowercase = false; // требуются ли символы в нижнем регистре
                opts.Password.RequireUppercase = false; // требуются ли символы в верхнем регистре
                opts.Password.RequireDigit = false; // требуются ли цифры
            }).AddEntityFrameworkStores<AuthentificationDbContext>();
            
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddScoped<CommonDataUnit>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceScopeFactory serviceScopeFactory)
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var appDbContext = scope.ServiceProvider.GetService<ApplicationDbContext>();
                //appDbContext.Database.Migrate();
                var AuthDbContext = scope.ServiceProvider.GetService<AuthentificationDbContext>();
                //AuthDbContext.Database.Migrate();
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");

            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
