using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.静态构造方法
{
   public static  class Class1
    {
        static Class1()
        {
            Console.WriteLine("成功调用了构造方法");
        }


        public static void Cw(string me)
        {
            Console.WriteLine(me);
        }
    }
}
