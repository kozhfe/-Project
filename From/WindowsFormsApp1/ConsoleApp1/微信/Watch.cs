using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.Input;
using FlaUI.Core.WindowsAPI;
using FlaUI.UIA3;
using FlaUI.UIA3.Identifiers;

namespace ConsoleApp1.微信
{
    public class Watch
    {
        private static Process[] processes = Process.GetProcessesByName("WeChat");//WeChat进程
        public static Window WeChatWindow;//WeChat窗口

        static Watch()
        {
            //将程序附加到微信进程
            using (var app = Application.Attach(processes.First().Id))
            {
                //使用 UIA3Automation 创建 UI Automation 实例
                using (var automation = new UIA3Automation())
                {
                    //获取微信应用程序的主窗口
                    WeChatWindow = app.GetMainWindow(automation);
                }
            }
        }

        public static string GetUserName()
        {
            using (var automation = new UIA3Automation())
            {
                //定位工具栏
                var ToolBarParent = WeChatWindow.FindFirstDescendant(cf => cf.ByLocalizedControlType("工具栏"));
                //获取工具栏下所有子元素的第一个子元素
                var UserNameElement = ToolBarParent.FindAllChildren().FirstOrDefault();
                //判断获取到的值是否有效
                if (!string.IsNullOrEmpty(UserNameElement.Properties.Name.ToString()))
                {
                    Console.WriteLine(UserNameElement.Properties.Name.ToString());
                    return UserNameElement.Properties.Name.ToString();
                }
                else
                {
                    return null;
                }
            }
        }


        public static List<Dictionary<string, string>> GetAllChatRecords()
        {
            List<Dictionary<string, string>> chatRecords = new List<Dictionary<string, string>>();

            using (var automation = new UIA3Automation())
            {
                // 获取聊天记录的父元素对象
                var messageWindowElement = WeChatWindow.FindFirstDescendant(cf => cf.ByName("消息"));
                // 获取聊天记录的列表项元素（消息列表）
                var messageListItems = messageWindowElement.FindAll(TreeScope.Subtree, new PropertyCondition(AutomationObjectIds.ControlTypeProperty, ControlType.ListItem));

                // 遍历聊天记录列表项
                foreach (var messageListItem in messageListItems)
                {
                    // 获取每条聊天记录对应的用户按钮元素
                    var userButtonElements = messageListItem.FindAll(TreeScope.Subtree, new PropertyCondition(AutomationObjectIds.ControlTypeProperty, ControlType.Button));

                    // 创建字典保存聊天记录信息
                    Dictionary<string, string> chatRecord = new Dictionary<string, string>();

                    // 遍历用户按钮元素
                    foreach (var userButtonElement in userButtonElements)
                    {
                        // 只有包含发送者的用户按钮才视为有效聊天记录
                        if (!string.IsNullOrEmpty(userButtonElement.Name))
                        {
                            // 将发送者和聊天信息添加到字典中
                            chatRecord["Sender"] = userButtonElement.Name;
                            chatRecord["Message"] = messageListItem.Name;
                            Console.WriteLine(userButtonElement.Name + ":" + messageListItem.Name);
                        }
                    }

                    // 将聊天记录字典添加到列表中
                    chatRecords.Add(chatRecord);
                }
            }

            return chatRecords;
        }

    }
}

