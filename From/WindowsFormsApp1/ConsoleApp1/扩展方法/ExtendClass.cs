using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.扩展方法
{
    public class ExtendClass
    {
        public string Exe()
        {
            return "测试";
        }
    }


    /// <summary>
    /// 扩展方法类和方法都必须是静态的，并且要和被扩展类在同一个命名空间内
    /// </summary>
    public static class Extend
    {
        public static string Exetendat(this ExtendClass extendClass ,string at)
        {
            return at;
        }
    }
}
