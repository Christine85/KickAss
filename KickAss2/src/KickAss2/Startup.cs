using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Entity;
using KickAss2.Models;

namespace KickAss2
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connString = @"Data Source=kickass.database.windows.net;Initial Catalog=KickAssDataBase;Integrated Security=False;User ID=kickass;Password=P@ssword;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            services.AddEntityFramework()
            .AddSqlServer()
            .AddDbContext<KickAssDataBaseContext>(o =>
                o.UseSqlServer(connString));
            services.AddMvc();
            services.AddCaching();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseSession();
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();
            app.UseMvcWithDefaultRoute();
        }

        // Entry point for the application. asgdhagsda
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
