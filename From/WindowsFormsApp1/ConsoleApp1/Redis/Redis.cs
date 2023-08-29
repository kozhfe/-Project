using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1.Redis
{
    
    //已被破解次数
    class Redis
    {
        //本机IP,Redis默认端口是6379
        public static void SetRedis()
        {
            // RedisClient client = new RedisClient("127.0.0.1", 6379);
            //client.Password = "123456";
            //List<int> ls = new List<int>();
            //ls.Add(131);
            //ls.Add(2564);
            //ls.Add(5465);
            ////读取
            //string name = client.Get<string>("name");
            //string pwd = client.Get<string>("password");

            //存储
            //client.Set<string>(Guid.NewGuid().ToString(), "11111111111111");
            //client.Set<string>(Guid.NewGuid().ToString(), "22");


            for (int j = 0; j < 1000; j++)
            {
                Thread thread = new Thread(() =>
                {      
                    for (int i = 0; i < 1000; i++)
                    {
                        using (RedisClient client = new RedisClient("127.0.0.1", 6379))
                        {
                            client.Password = "123456";
                            client.Set<string>(Guid.NewGuid().ToString(), $"线程：{j},已运行;{i} 次");
                            string name= client.Get<string>("链接建立次数");
                            string ii = Convert.ToString(Convert.ToInt64(name) + 1);
                            client.Set<string>("链接建立次数", ii);
                        }
                    }
                });
                thread.Start();
            }
            //存list集合
            //client.Set<List<int>>("1", ls);
        }
    }
}
