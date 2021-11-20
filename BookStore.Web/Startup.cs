using BookStore.BL.Services;
using BookStore.BL.Services.Interfaces;
using BookStore.DL.Entity;
using BookStore.Web.infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Web
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
            services.AddControllersWithViews();


            services.AddDbContext<StoreContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("AA-DatabaseConnectionString"),
                                                             sqlServerOptionsAction: sqlOptions =>
                                                             {
                                                                 sqlOptions.EnableRetryOnFailure(
                                                                             maxRetryCount: 3,
                                                                             maxRetryDelay: TimeSpan.FromSeconds(30),
                                                                             errorNumbersToAdd: null);
                                                             }).EnableSensitiveDataLogging()
                                                            , ServiceLifetime.Transient);
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IBookService), typeof(BookService));
            services.AddScoped(typeof(IStoreInventoryService), typeof(StoreInventoryService));
            services.AddScoped(typeof(ICustomerService), typeof(CustomerService));
            services.AddScoped(typeof(IOrderHistoryService), typeof(OrderHistoryService));
            services.AddScoped(typeof(ServiceUtility));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
