using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    using ConsoleApp1.Redis;
    using ConsoleApp1.验证码;
    using ServiceStack.ServiceInterface.ServiceModel;
    using System.Reflection;

    class Program
    {
        static void Main(string[] args)
        {
            ces ces1 = new ces();
            ces1.cw1 =  1;
            ces1.cw2 = "2";
            ces1.cw3 = "3";
            ces1.cw4 = "4";


            ces ces2 = new ces();
            ces2.cw1 = 1;
            ces2.cw2 = "2";
            ces2.cw3 = "4";
            ces2.cw4 = "4";


            Type objectType = typeof(ces);
            PropertyInfo[] properties = objectType.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object propertyValue1 = property.GetValue(ces1);
                object propertyValue2 = property.GetValue(ces2);
                if (!Equals(propertyValue1, propertyValue2))
                {
                    string propertyName = property.Name;
                    Console.WriteLine("Property {0} is different.", propertyName);
                    Console.WriteLine("Value in ces1: {0}", propertyValue1);
                    Console.WriteLine("Value in ces2: {0}", propertyValue2);
                    Console.WriteLine("--------------------------");
                }
            }

            ImageVerificationCode class1 = new ImageVerificationCode(100,100);

            Console.WriteLine(class1.CreateVerificationImage("测试"));

            Console.ReadLine();
        }
    }

    class ces
    {
        public int cw1 { get; set; }
        public string cw2 { get; set; }
        public string cw3 { get; set; }
        public string cw4 { get; set; }
    }
}

