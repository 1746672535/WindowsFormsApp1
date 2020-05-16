using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleApp3;

namespace WindowsFormsApp2
{
    public partial class Form3 : Form
    {
        OrderItem thisOrderItem = null;
        public Form3()
        {
            InitializeComponent();
        }

        public Form3(ref OrderItem orderItem)
        {
            InitializeComponent();
            thisOrderItem = orderItem;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void btnRight(object sender, EventArgs e)
        {
            Goods goods = new Goods(textBox1.Text, double.Parse(textBox2.Text));
            thisOrderItem.goods = goods;
            thisOrderItem.Name = textBox1.Text;
            thisOrderItem.Amount = int.Parse(textBox3.Text);
            thisOrderItem.TotalPrice = goods.Price * thisOrderItem.Amount;
            Close();
            
        }

        private void btnExit(object sender, EventArgs e)
        {
            thisOrderItem.Amount = -1;
            Close();
        }
    }
}
