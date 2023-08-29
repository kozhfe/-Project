using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1.IO操作
{
    public class IO
    {
        /// <summary>
        /// 创建文件
        /// </summary>
        /// <returns></returns>
        public static bool CreateFile(string FileUrl,string FileName,string Context)
        {
            string url = FileUrl + @"\" + FileName;

            //没有文件夹就创建文件夹和文件
            if (!Directory.Exists(FileUrl))
            {
                Directory.CreateDirectory(FileUrl);
                using (StreamWriter writer = new StreamWriter(url))
                {
                    writer.WriteLine(Context);
                }
                return true;
            }
            //没有就加
            if (!File.Exists(url))
            {
                using (StreamWriter writer = new StreamWriter(url))
                {
                    writer.WriteLine(Context);
                }
                return true;
            }
            return true;
        }

        /// <summary>
        /// 向指定文件添加内容
        /// </summary>
        /// <param name="FileUrl"></param>
        /// <param name="FileName"></param>
        /// <param name="Context"></param>
        /// <returns></returns>
        public static  bool AddFile(string FileUrl, string FileName, string Context)
        {
            string url = FileUrl + @"\" + FileName;

            if (!Directory.Exists(FileUrl))
            {
                return false;
            }
            if (!File.Exists(url))
            {
                return false;
            }

            using (StreamWriter writer = new StreamWriter(url,true))
            {
                writer.WriteLine(Context);
            }
            return true;
        }

        /// <summary>
        /// 查询文件夹下的内容
        /// </summary>
        /// <param name="FileUrl"></param>
        /// <returns></returns>
        public static string[] QueryFile(string FileUrl)
        {
            if (!Directory.Exists(FileUrl))
            {
                return new string[0];
            }

            return Directory.GetFiles(FileUrl);
        }
    }
}
