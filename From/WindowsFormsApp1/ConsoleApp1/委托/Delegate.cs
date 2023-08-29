using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.事件
{
    public class Delegate
    {
        #region 带返回值的委托
        //定义一个委托
        delegate string MyDelegate(string Context,string te2);

        //方法
        public void MyTest(string Context)
        {
            Console.WriteLine(Context);
        }

        //有返回值的方法
        public string MyTest(string Context,string conte2)
        {
            return Context;
        }

        //测试委托
        public void DelegateMothe(string Context)
        {
            MyDelegate myDelegate = new MyDelegate(MyTest);
            var at= myDelegate(Context,"测试");
        }
        #endregion

        #region 无返回值的委托
        //定义一个委托
        delegate void MyDelegate2(string Context);

        //方法
        public void MyTest2(string Context)
        {
            Console.WriteLine(Context);
        }

        //有返回值的方法
        public string MyTest2(string Context, string conte2)
        {
            return Context;
        }

        //测试委托
        public void DelegateMothe2(string Context)
        {
            MyDelegate2 myDelegate = new MyDelegate2(MyTest2);
            myDelegate(Context);
        }
        #endregion

    }
}
