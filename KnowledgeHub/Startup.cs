using KnowledgeHub.Data;
using KnowledgeHub.Infrastructure;
using KnowledgeHub.Services.Courses;
using KnowledgeHub.Services.Videos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace KnowledgeHub
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            =>  Configuration = configuration;

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContext<KnowledgeHubDbContext>(options => options
                        .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            services
                .AddDatabaseDeveloperPageExceptionFilter();

            services
                .AddDefaultIdentity<IdentityUser>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<KnowledgeHubDbContext>();

            services.AddAutoMapper(typeof(Startup));

            services
                .AddControllersWithViews();

            services
                .AddTransient<ICourseService, CourseService>()
                .AddTransient<IVideoService, VideoService>();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.PrepareDatabase();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
        }
    }
}
