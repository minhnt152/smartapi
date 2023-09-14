using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using smartapi.Data;
using smartapi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace smartapi
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
            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddDbContext<SmAccessParkingContext>(opt => opt.UseLazyLoadingProxies().UseNpgsql(Configuration.GetConnectionString("DBConnection")));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IAccessCtrlrBrandSysRepo, SqlAccessCtrlrBrandsysRepo>();  
            services.AddScoped<IScheduleRepo, SqlScheduleRepo>();  
            services.AddScoped<IAccessCtrlrNetworkRepo, SqlAccessCtrlrNetworkRepo>();      
            services.AddScoped<IDoorRepo, SqlDoorRepo>();    
            services.AddScoped<IAccessEventRepo, SqlAccessEventRepo>(); 
            services.AddScoped<ICardRepo, SqlCardRepo>();    
            services.AddScoped<IAccessRightRepo, SqlAccessRightRepo>();  
            services.AddScoped<ICardHolderRepo, SqlCardHolderRepo>();  
            services.AddScoped<IFacilityRepo, SqlFacilityRepo>(); 
            services.AddScoped<IAccessCtrlrRepo, SqlAccessCtrlrRepo>();  
            services.AddScoped<IAccessCtrlrModelRepo, SqlAccessCtrlrModelRepo>();
            services.AddScoped<ISettingRepo, SqlSettingRepo>();
            services.AddScoped<ITableUpdateRepo, SqlTableUpdateRepo>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SmartAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
