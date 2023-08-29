using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Commd
{
    public static class CMD
    {
        /// <summary>
        /// 执行CMD命令
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static void  AllCMD( string cmd)
        {
            //创建一个对象用于运行批处理命令
            Process process = new Process();

            //设置属性
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe"; // CMD程序路径
            startInfo.Arguments = "/c " + cmd; // 要执行的CMD命令
            startInfo.RedirectStandardOutput = true; // 重定向输出流
            startInfo.UseShellExecute = false; // 不使用默认的Shell执行
            startInfo.CreateNoWindow = true; // 不创建CMD窗口

            //启动进程
            process.StartInfo = startInfo;
            process.Start();

            string output = process.StandardOutput.ReadToEnd(); // 读取输出

            //等待进程结束
            process.WaitForExit();

        }

        public static void ProsCMD(string cmd)
        { 
            // 创建一个Process对象用于运行批处理命令
            Process process = new Process();

            // 设置ProcessStartInfo对象的属性
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;

            // 启动进程
            process.StartInfo = startInfo;
            process.Start();

            // 获取输入和输出流
            StreamWriter inputWriter = process.StandardInput;
            StreamReader outputReader = process.StandardOutput;

            while (true)
            {
                if (!string.IsNullOrWhiteSpace(dialogueFrom.CMDtext))
                {
                    // 发送用户输入的命令给批处理进程
                    inputWriter.WriteLine(dialogueFrom.CMDtext);
                    inputWriter.Flush();

                    // 读取批处理进程的输出
                    string output = outputReader.ReadLine();
                    while (output != null)
                    {
                        dialogueFrom.cmdte = outputReader.ReadLine();
                        output = null;
                    }
                }
                
            }

            ///string a = outputReader.ReadLine();//输出
             

            // 结束批处理进程
            //process.Close();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="PlanName">任务名称</param>
        /// <param name="PlanUrl">执行路径</param>
        /// <param name="dy">每天</param>
        /// <param name="Time">时间</param>
        /// <returns></returns>
        public static bool AddPlan(string PlanName ,string PlanUrl,string dy, string Time)
        {
            //DAILY：每天
            string cmd = $"schtasks /create /tn \"{PlanName} \" /tr \"{PlanUrl}\" /sc {dy} /st {Time}";
            AllCMD(cmd);
            return true;
        }
    }
}
