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
    public partial class Form2 : Form
    {
        Order thisorder = null;
        public bool tag = true;

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(ref Order order)
        {
            InitializeComponent();
            
            thisorder = order;
            orderItemBindingSource1.DataSource = thisorder.OrderItems;

        }

        private void btnAddOrderItem(object sender, EventArgs e)
        {
            OrderItem orderItem = new OrderItem();
            
            new Form3(ref orderItem).ShowDialog();

            thisorder.addOrderItem(orderItem);
            orderItemBindingSource.ResetBindings(false);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnDeleteOrderItem(object sender, EventArgs e)
        {
            OrderItem current = orderItemBindingSource.Current as OrderItem;
            
            thisorder.deleteOrderItem(current);
            orderItemBindingSource.ResetBindings(false);

        }

        private void btnModifyOrderItem(object sender, EventArgs e)
        {

            OrderItem current = orderItemBindingSource.Current as OrderItem;
            OrderItem orderItem = new OrderItem();
            new Form3(ref orderItem).ShowDialog();
            orderItemBindingSource.ResetBindings(false);
            thisorder.modifyOrderItem(current, orderItem);

        }

        private void btnRight(object sender, EventArgs e)
        {
            thisorder.CustomerName = textBox1.Text;

            thisorder.Total = thisorder.getTotal();


            Close();
        }

        private void btnExit(object sender, EventArgs e)
        {
            tag = false;
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
