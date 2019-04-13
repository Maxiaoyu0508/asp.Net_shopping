using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;


namespace shopping
{
    public partial class CreateCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            createCheckCodeImage(generateRadamCode());

        }

        private string generateRadamCode()
        {
            string checkCode = String.Empty;
            char code;
            int number;
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                number = random.Next(0, 51);
                if (number % 26 == 0)
                {
                    code = (char)('A' + (number + 1) / 26);
                }
                else
                {
                    code = (char)('A' + number % 26);
                }
                if (checkCode.Contains(code.ToString()))
                {
                    i--;
                }
                else
                {
                    checkCode += code.ToString();
                }
            }
            Session["CheckCode"] = checkCode;
            return checkCode;
        }

        private void createCheckCodeImage(string checkCode)
        {
            if (checkCode == null || checkCode.Trim() == string.Empty)
            { return; }
            Bitmap image = new Bitmap((int)Math.Ceiling(checkCode.Length * 12.5), 22);
            Graphics g = Graphics.FromImage(image);
            try
            {
                Random random = new Random();
                g.Clear(Color.White);
                for (int i = 0; i < 25; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.GreenYellow), x1, x2, y1, y2);
                }
                Font font = new Font("Verdana", 10, (FontStyle.Bold | FontStyle.Italic));
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
                g.DrawString(checkCode, font, brush, 2, 2);
                for (int i = 0; i < 80; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                g.DrawRectangle(new Pen(Color.Red), 0, 0, image.Width - 1, image.Height - 1);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                image.Save(ms, ImageFormat.Gif);
                Response.ClearContent();
                Response.ContentType = "image/Gif";
                Response.BinaryWrite(ms.ToArray());
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }
    }
}