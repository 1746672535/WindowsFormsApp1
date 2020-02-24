using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a=0;
            double b=0;
            double c = 0;
            string d = comboBox1.Text;
            try
            {
                if (!Double.TryParse(textBox1.Text, out a) || !Double.TryParse(textBox2.Text, out b))
                {
                    throw new ArgumentException();
                }
                if (a < Double.MinValue && a > Double.MaxValue && b < Double.MinValue && b > Double.MaxValue)
                {
                    throw new ArithmeticException();
                }
                switch (d)
                {
                    case "+":
                        c = a + b;
                        break;
                    case "-":
                        c = a - b;
                        break;
                    case "*":
                        c = a * b;
                        break;
                    case "/":
                        if (b != 0)
                            c = a / b;
                        else
                            throw new DivideByZeroException();
                        break;
                }
                textBox3.Text = c + "";
                return;

            }
            catch (ArgumentException)
            {
                label2.Text = "请输入数字";
                return;
            }
            catch (DivideByZeroException)
            {
                label2.Text = "除数不能为0";
                return;
            }
            catch (ArithmeticException)
            {
                label2.Text = "计算发生溢出";
                return;
            }
            
         
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            comboBox1.Text = null;
            label2.Text = "tips";
        }
    }
}
