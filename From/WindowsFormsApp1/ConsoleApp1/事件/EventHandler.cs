using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.事件
{
    public class EventHandler
    {
        /// <summary>
        /// 订阅事件
        /// </summary>
        public EventHandler()
        {
            EventTest +=TestEvenNoe;
            EventTest += TestEvenTwo;
        }

        public void st()
        {
            EventTest.Invoke("测试");
        }

        /// <summary>
        /// 定义委托
        /// </summary>
        /// <param name="Context"></param>
        public delegate void DelegateTest(string Context);

        /// <summary>
        /// 定义事件
        /// </summary>
        public static event DelegateTest EventTest;

        /// <summary>
        /// 事件方法一
        /// </summary>
        /// <param name="Context"></param>
        public void TestEvenNoe(string Context)
        {
            Console.WriteLine(Context);
        }

        /// <summary>
        /// 事件方法二
        /// </summary>
        /// <param name="Context"></param>
        public void TestEvenTwo(string Context)
        {
            Console.WriteLine(Context);
        }
    }
}
