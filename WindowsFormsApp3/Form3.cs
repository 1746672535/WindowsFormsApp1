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

namespace WindowsFormsApp3
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

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void btnRight(object sender, EventArgs e)
        {

            thisOrderItem.Price = int.Parse(textBox2.Text);
            thisOrderItem.Name = textBox1.Text;
            thisOrderItem.Amount = int.Parse(textBox3.Text);
            thisOrderItem.TotalPrice = thisOrderItem.Price * thisOrderItem.Amount;
            Close();
        }

        private void btnExit(object sender, EventArgs e)
        {
            thisOrderItem.Amount = -1;
            Close();
        }
    }
}
