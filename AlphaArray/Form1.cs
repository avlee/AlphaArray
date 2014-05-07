using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AlphaArray
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            openFileDialog1.Filter = "PNG FILE|*.png";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog(this);
            this.textBox1.Text = this.openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Image image = Bitmap.FromFile(this.textBox1.Text);

            int width = image.Width;
            int height = image.Height;

            Bitmap bitmap = new Bitmap(image);

            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("[{0}][{1}] = ", height, width);
            sb.Append("{");

            for (int y = 0; y < height; y++)
            {
                if (y > 0)
                {
                    sb.Append(",");
                }
                sb.Append("\r\n    { ");
                for (int x = 0; x < width; x++)
                {
                    if (x > 0)
                    {
                        sb.Append(", ");
                    }
                    Color color = bitmap.GetPixel(x, y);
                    sb.Append(color.A);
                }
                sb.Append(" }");
            }
            sb.Append("\r\n}");

            this.textBox2.Text = sb.ToString();

            image.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Image image = Bitmap.FromFile(this.textBox1.Text);

            int width = image.Width;
            int height = image.Height;

            Bitmap bitmap = new Bitmap(image);

            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("[{0}][{1}] = ", height, width);
            sb.Append("{");

            for (int y = 0; y < height; y++)
            {
                if (y > 0)
                {
                    sb.Append(",");
                }
                sb.Append("\r\n    { ");
                for (int x = 0; x < width; x++)
                {
                    if (x > 0)
                    {
                        sb.Append(", ");
                    }
                    if (x < y && x < height && y < width)
                    {
                        Color color = bitmap.GetPixel(y, x);
                        sb.Append(color.A);
                    }
                    else
                    {
                        Color color = bitmap.GetPixel(x, y);
                        sb.Append(color.A);
                    }
                }
                sb.Append(" }");
            }
            sb.Append("\r\n}");

            this.textBox2.Text = sb.ToString();

            image.Dispose();
        }
    }
}
