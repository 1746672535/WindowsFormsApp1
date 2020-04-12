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
    public partial class Form1 : Form
    {

        OrderService orderService = new OrderService();
        public string KeyWord { get; set; }

        public Form1()
        {
            InitializeComponent();
            orderServiceBindingSource3.DataSource = orderService.OrderList;

        }

        private void btnQuery(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDeleteOrder(object sender, EventArgs e)
        {
            try
            {
                Order current = orderServiceBindingSource3.Current as Order;
                orderService.DeleteOrder(current);
                orderServiceBindingSource3.ResetBindings(true);
            }
            catch(Exception)
            {
                label1.Text = "该订单不存在";
            }
        }

        private void btnAddOrder(object sender, EventArgs e)
        {
            Order order = new Order();
            new Form2(ref order , orderService.sum).ShowDialog();
            orderServiceBindingSource3.ResetBindings(true);
            orderService.AddOrder(order);
            order.Id = orderService.sum;
            orderServiceBindingSource3.ResetBindings(true);
        }

        private void btnDisplayAllOrder(object sender, EventArgs e)
        {
            orderServiceBindingSource3.DataSource = orderService.OrderList;
            orderServiceBindingSource3.ResetBindings(true);
        }

        private void cmbQueryKey(object sender, EventArgs e)
        {

        }

        private void txtQueryInfo(object sender, EventArgs e)
        {

        }

        private void lypquerylayer(object sender, PaintEventArgs e)
        {

        }

        private void dgvOrderList(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvOrderItems(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnModifyOrder(object sender, EventArgs e)
        {
            
        }

        private void lblExceptionInfo(object sender, EventArgs e)
        {

        }
    }
}
