using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Commd;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        //private bool isSpacePressed = false;
        public Form1() 
        {
            InitializeComponent();
            this.ShowInTaskbar = false;//隐藏任务栏
            this.WindowState = FormWindowState.Minimized;
            this.ControlBox = false;//将右上角的控制按钮都去掉
            //置于桌面最顶层
           // IntPtr handle = this.Handle;
            //Program.SetWindowPos(handle, Program.HWND_BOTTOM, 0, 0, 0, 0, Program.SWP_SHOWWINDOW);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            //CMD.AddPlan("任务测试", @"F:\demo\From\WindowsFormsApp1\WindowsFormsApp1\bin\Debug\WindowsFormsApp1.exe", "DAILY", "17:55");
            //dialogueFrom dialogueFrom = new dialogueFrom();
            //dialogueFrom.Show();
            #region 准时下班
            OnTime();
            #endregion
        }

        
        public void OnTime()
        {
            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    var a = DateTime.Now.ToString("HH:mm");
                    if (a == "18:00")
                    {
                        this.label1.Text = "下班了";
                        this.ControlBox = false;//将右上角的控制按钮都去掉
                        this.WindowState = FormWindowState.Maximized;
                        this.FormBorderStyle = FormBorderStyle.None;//禁用窗体的所有边框以及控制按钮
                        this.TopMost = true;
                        Thread.Sleep(3000);
                        CMD.AllCMD("shutdown -s");
                        return;
                    }
                }
            });
            thread.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            
        }

    }
}
