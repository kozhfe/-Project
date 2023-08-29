using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Commd
{
    public class FileOperation
    {
        //创建文件夹
        public static bool  CreateFolder(string FolderUrl)
        {
            try
            {
                //没有就创建
                if (!Directory.Exists(FolderUrl))
                {
                    Directory.CreateDirectory(FolderUrl);
                }
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
            
        }

        /// <summary>
        /// 复制文件
        /// </summary>
        /// <param name="SourceFilePath">被复制文件路径</param>
        /// <param name="destinationFolderPath">复制到文件路径</param>
        /// <param name="FileName">复制后文件名称</param>
        /// <returns></returns>
        public static bool CopyFile(string SourceFilePath,string destinationFolderPath,string FileName)
        {
            try
            {
                CreateFolder(destinationFolderPath);
                //string fileName = Path.GetFileName(SourceFilePath); // 获取源文件的文件名
                string destinationFilePath = Path.Combine(destinationFolderPath, FileName); // 构建目标文件的完整路径
                File.Copy(SourceFilePath, destinationFilePath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
