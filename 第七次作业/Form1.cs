using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp4
{
    public partial class CarleyTree : Form
    {

        private Graphics graphics;
        private double height = 100;
        private double th1 = 20 * Math.PI / 180;
        private double th2 = 30 * Math.PI / 180;
        double per1 = 0.7;
        double per2 = 0.6;
        int depth = 10;
        string color = "黑";

        void drawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1);

            drawCayleyTree(n - 1, x1, y1, per2 * leng, th + th2);
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th - th1);
        }

        void drawLine(double x0, double y0, double x1, double y1)
        {
            Pen pencolor = Pens.Black;
            switch (color)
            {
                case "蓝": pencolor = Pens.Blue; break;
                case "红": pencolor = Pens.Red; break;
                case "绿": pencolor = Pens.Green; break;
                case "黄": pencolor = Pens.Yellow; break;
                case "黑": pencolor = Pens.Black; break;
            }
            graphics.DrawLine(pencolor, (int)x0, (int)y0, (int)x1, (int)y1);
        }

        public CarleyTree()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCreateCayleyTree(object sender, EventArgs e)
        {
            
            if (graphics == null) graphics = panel2.CreateGraphics();
            graphics.Clear(Color.White);
            drawCayleyTree(depth, 300, 300, height, -Math.PI / 2);
        }

        private void lblLeftAngle(object sender, EventArgs e)
        {

        }

        private void lblRightAngle(object sender, EventArgs e)
        {

        }

        private void lblLeftLength(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtChangeLeftAngle(object sender, EventArgs e)
        {

            th1 = InputManagment(0,90,textBox1.Text) * Math.PI / 180; 
        }

        private void txtChangeRightAngle(object sender, EventArgs e)
        {
            th2 = InputManagment(0, 90, textBox4.Text) * Math.PI / 180;
        }

        private void txtChangeLeftLength(object sender, EventArgs e)
        {
            per1 = InputManagment(0, 1, textBox2.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            per2 = InputManagment(0, 1, textBox3.Text);
        }

        private void txtChangeDepth(object sender, EventArgs e)
        {
            depth =(int)InputManagment(0, 15, txtHeight.Text);
        }

        private void pnlOperation(object sender, PaintEventArgs e)
        {

        }

        private void lbldepth(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbChangeColor(object sender, EventArgs e)
        {
            color = comboBox1.Text;
        }

        private void txtChangeHeight(object sender, EventArgs e)
        {
            height = InputManagment(50, 150, textBox5.Text);
        }

        private void lblHeight(object sender, EventArgs e)
        {

        }

        private void pnlPainting(object sender, PaintEventArgs e)
        {

        }

        private void lblColor(object sender, EventArgs e)
        {

        }

        public double InputManagment(double Min, double Max, string input)
        {
            double Input = 0;
            try
            {
                
                if (!double.TryParse(input, out Input))
                    throw new ArgumentException();
                if (Input < Min || Input > Max)
                    throw new Exception();
                label7.Text = "输入合法";
            }
            catch (ArgumentException)
            {
                label7.Text = "请输入数字";
            }
            catch (Exception)
            {
                label7.Text = "请输入合法数字";
            }
            return Input;
        }

        private void lblFlag(object sender, EventArgs e)
        {

        }
    }
}
