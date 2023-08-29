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
using Microsoft.Extensions.Configuration;//��ȡappsettings�������ļ�����
using twoChapter.Services;

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
        public void ConfigureServices(IServiceCollection services)//����ע�����������������������ʱ���ã�
        {
            services.AddMvc();//ע����������
            services.AddTransient<ITouristRouteRepository, TouristRouteRepository>();
            services.AddTransient<ITouristRouteRepository, TouristRouteRepository1>();
            services.AddDbContext<AppDbContext>(option=>
            {
                //option.UseSqlServer(@"server=localhost; Database=FakeXichengDb; User Id=sa; Password=123456;");
                option.UseSqlServer(Configuration["DbContext:ConnectionString"]);
            });//ע�����ݿ�������,option�����������ݿ�
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)//��������ϵͳhttp����ͨ��
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();    //����MVC·��ӳ��
            });
        }
    }
}
