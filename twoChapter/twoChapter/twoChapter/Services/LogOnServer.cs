using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using twoChapter.IServices;

namespace twoChapter.Services
{
    public class LogOnServer : ILogOnRepository
    {
        #region 验证码
        SKSurface Surface;
        SKTypeface EmojiTypeface;
        Random Random1;
        public dynamic VerifyCode()
        {
            #region 随机数
            string Text = RndNum(4).ToString();
            #endregion

            #region 设置字体,解决乱码
            // crate a surface
            var info = new SKImageInfo(100, 35);//长宽

            Surface = SKSurface.Create(info);

            ///设置字体,解决乱码
            var fontManager = SKFontManager.Default;
            EmojiTypeface = fontManager.MatchCharacter('赵');

            Random1 = new Random();
            #endregion

            #region 清除图像,保留背景色
            // 画布和属性
            var canvas = Surface.Canvas;
            // 确保画布是空白的
            canvas.Clear(new SKColor(255, 255, 255));
            #endregion

            #region 写文字
            var xPoint = 6;///x点
            var yPoint = (Surface.Canvas.DeviceClipBounds.Height + 30) / 2; ///y点
            // draw some text
            var paint = new SKPaint
            {
                Color = SKColors.Black,
                IsAntialias = true,
                Style = SKPaintStyle.Fill,
                TextAlign = SKTextAlign.Left,
                TextSize = 30,
                TextEncoding = SKTextEncoding.Utf8,
                Typeface = EmojiTypeface,
                StrokeWidth = 3
                // TextSkewX = 3
            };
            for (int i = 0; i < Text.Length; i++)
            {
                ///偏移
                int xOffset = Random1.Next(-30 * 2 / 10, 1);///x偏移
                int yOffset = Random1.Next(-3, 3);///y偏移
                int angleOffset = Random1.Next(-15, 15);///角度偏移
                paint.Color = RandColoe();///随机颜色

                canvas.RotateDegrees(angleOffset, xPoint + xOffset, yPoint + yOffset);
                canvas.DrawText(Text[i].ToString(), xPoint + xOffset, yPoint + yOffset, paint);

                canvas.RotateDegrees(-angleOffset, xPoint + xOffset, yPoint + yOffset);
                // xPoint = xPoint + xOffset + TextSize;
                xPoint = xPoint + 30 + xOffset;


            }
            #endregion

            #region 混淆

            int Count = 4;

            // the the canvas and properties
            for (int i = 0; i < Count; i++)
            {
                int x = Random1.Next(0, canvas.DeviceClipBounds.Width);
                int y = Random1.Next(0, canvas.DeviceClipBounds.Height);
                int radius = Random1.Next(30, 30 * 2);

                paint = new SKPaint
                {
                    Color = RandColoe(),///随机颜色
                    IsAntialias = true,
                    Style = SKPaintStyle.Stroke,
                    TextAlign = SKTextAlign.Left,
                    TextSize = 30,
                    TextEncoding = SKTextEncoding.Utf8,
                    Typeface = EmojiTypeface,
                    StrokeWidth = 1
                    // TextSkewX = 3
                };


                canvas.DrawCircle(x, y, radius, paint);

            }
            #endregion

            // 获取图片流,png格式
            // save the file
            using (var image = Surface.Snapshot())
            using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
            {

                return "data:image/png;base64," + Convert.ToBase64String(data.ToArray());

            }
        }

        /// <summary>
        /// R限制范围
        /// </summary>
        public (byte begin, byte end, byte length) BoundsR
        {
            get
            {
                return Bounds(185);
            }
        }
        /// <summary>
        /// R限制范围
        /// </summary>
        public (byte begin, byte end, byte length) BoundsG
        {
            get
            {
                return Bounds(185);
            }
        }
        /// <summary>
        /// R限制范围
        /// </summary>
        public (byte begin, byte end, byte length) BoundsB
        {
            get
            {
                return Bounds(185);
            }
        }

        /// <summary>
        /// 颜色取值,限制范围
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        private (byte begin, byte end, byte length) Bounds(byte Value)
        {
            (byte begin, byte end, byte length) res = (0, 0, 0);

            res.begin = (byte)Math.Max(0, Value - 40);
            res.end = (byte)Math.Min(255, Value + 40);
            res.length = (byte)(res.end - res.begin);

            return res;
        }

        /// <summary>
        /// 生成和背景具有区分的随机颜色
        /// </summary>
        /// <returns></returns>
        private SKColor RandColoe()
        {
            ///随机颜色,以背景色为基准,,取随机值,防止靠色
            ///0    128     256

            ///r值
            var r = Random1.Next(0, 255 - BoundsR.length);
            if (r > BoundsR.begin && r < BoundsR.end)
            {
                r = (r + BoundsR.length) % 256;
            }

            ///g值
            var g = (r + Random1.Next(50, 190)) % 256;

            if (g > BoundsG.begin && g < BoundsG.end)
            {
                g = (g + BoundsG.length) % 256;
            }

            ///b值
            var b = (g + Random1.Next(50, 190)) % 256;
            if (b > BoundsB.begin && b < BoundsB.end)
            {
                b = (b + BoundsB.length) % 256;
            }


            return new SKColor((byte)r, (byte)g, (byte)b);
        }

        /// <summary>
        ///随机验证码
        /// </summary>
        /// <param name="VcodeNum"></param>
        /// <returns></returns>
        private static string RndNum(int VcodeNum)
        {
            //验证码可以显示的字符集合  
            string Vchar = "0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,l,m,n,p" +
                ",q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,G,H,I,J,K,L,M,N,P,P,Q" +
                ",R,S,T,U,V,W,X,Y,Z";
            string[] VcArray = Vchar.Split(new Char[] { ',' });//拆分成数组   
            string code = "";//产生的随机数  
            int temp = -1;//记录上次随机数值，尽量避避免生产几个一样的随机数  

            Random rand = new Random();
            //采用一个简单的算法以保证生成随机数的不同  
            for (int i = 1; i < VcodeNum + 1; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));//初始化随机类  
                }
                int t = rand.Next(61);//获取随机数  
                if (temp != -1 && temp == t)
                {
                    return RndNum(VcodeNum);//如果获取的随机数重复，则递归调用  
                }
                temp = t;//把本次产生的随机数记录起来  
                code += VcArray[t];//随机数的位数加一  
            }
            return code;
        }
        #endregion
    }
}
