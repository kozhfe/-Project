using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using twoChapter.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;//获取appsettings中配置文件对象
using twoChapter.Services;
using twoChapter.IServices;
using AutoMapper;

namespace twoChapter
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        //系统IOC容器
        public void ConfigureServices(IServiceCollection services)//可以注入各种组件服务的依赖（运行时调用）
        {
            services.AddMvc();//注入控制器组件
           
            services.AddTransient<ITouristRouteRepository, TouristRouteRepository>();//注册服务
            services.AddTransient<ILogOnRepository, LogOnServer>();//注册服务

            
            services.AddDbContext<AppDbContext>(option=>
            {
                option.UseSqlServer(Configuration["DbContext:ConnectionString"]);
            });//注入数据库链接器,option配置链接数据库

            //自动扫描程序集里包含映射关系的profile文件，自动加载  （自动寻找项目中的Profiles文件）
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());//实体映射

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)//用于配置系统http请求通道
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(corsConfig =>
            {
                //允许所有域名
                corsConfig.AllowAnyOrigin();
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();    //启用MVC路由映射
            });
        }
    }
}
