using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Commd;

namespace WindowsFormsApp1
{
    public partial class dialogueFrom : Form
    {
        public dialogueFrom()
        {
            InitializeComponent();
        }

        public static string CMDtext;

        public static string cmdte;

        private void button1_Click(object sender, EventArgs e)
        {
            string text = this.textBox1.Text;
            this.textBox2.Text+= text+"\r\n";
            CMDtext = null;
            this.textBox1.Text = null;
        }

        private void dialogueFrom_Load(object sender, EventArgs e)
        {

        }

        public void DHCMD()
        {
            // 创建一个新的进程对象来执行CMD
            Process process = new Process();

            // 设置进程启动参数
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            // 启动进程
            process.StartInfo = startInfo;
            process.Start();

            // 获取标准输入流和标准输出流
            var inputStream = process.StandardInput;
            var outputStream = process.StandardOutput;

            // 循环与CMD交互
            while (true)
            {
                Console.Write(">> ");
                string input = Console.ReadLine();

                // 发送用户输入的命令给CMD进程
                inputStream.WriteLine(input);

                // 如果输入"exit"，则退出循环
                if (input.ToLower() == "exit")
                {
                    break;
                }

                // 读取CMD进程的输出并打印
                string output = outputStream.ReadLine();
                Console.WriteLine(output);
            }

            // 等待CMD进程退出
            process.WaitForExit();
        }
    }
}
