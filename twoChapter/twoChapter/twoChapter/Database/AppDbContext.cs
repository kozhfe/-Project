using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;//用于对数据库进行映射
using twoChapter.Model;

namespace twoChapter.Database
{
    public class AppDbContext: DbContext//继承EntityFrameworkCore中的上下文
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)//注入类本身,同时调用父类加载options
        {

        }
        //在上下文关系对象中需要指明那些要映射到数据库中

        //使用Dbset对数据库模型进行映射,相当于数据库的链接器
        public DbSet<TouristRoute> TouristRoutes { get;set; }
        public DbSet<TouristRoutePicture> TouristRoutePictures { get;set; }

        //重写内置函数
        protected override void OnModelCreating(ModelBuilder modelBuilder)//ModelBuilder用于数据模型创建数据表时的补充说明用的
        {
            modelBuilder.Entity<TouristRoute>().HasData(new TouristRoute()
            {
                id = Guid.NewGuid(),
                Title = "ceshititle",
                Description = "shuoming",
                CreateTime = DateTime.UtcNow
            });//提供数据支持
            base.OnModelCreating(modelBuilder); 
        }
    }
}
