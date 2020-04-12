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
    public partial class Form1 : Form
    {
        
        OrderService orderService = new OrderService();
        public string KeyWord { get; set; }
     
        List<Order> orders = new List<Order>();
        public Form1()
        {
            InitializeComponent();
          
           
            
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AddOrder(object sender, EventArgs e)
        {
            Order order = new Order();
            orderBindingSource.DataSource = orderService.OrderList;
            new Form2(ref order, orderService.sum).ShowDialog();
           
            orderService.AddOrder(order);
            order.Id = orderService.sum;
            orderBindingSource.ResetBindings(false);
        }

        private void btnQuery(object sender, EventArgs e)
        {
            try
            {
                switch (comboBox1.Text)
                {
                    case "订单号":
                        orderBindingSource.DataSource=orderService.InquiryOrder(int.Parse(textBox1.Text));
                        break;
                    case "顾客":
                        orderBindingSource.DataSource = orderService.InquiryOrder(2, textBox1.Text);
                        break;
                    case "商品名":
                        orderBindingSource.DataSource = orderService.InquiryOrder(1, textBox1.Text);
                        break;
                }
            }

            catch (Exception)
            {
                label1.Text = "请输入有效的信息";
            }
        }

        private void btnDeleteOrder(object sender, EventArgs e)
        {
            try
            {
                Order current = orderBindingSource.Current as Order;
                orderService.DeleteOrder(current);
                orderBindingSource.ResetBindings(false);
            }
            catch (Exception)
            {
                label1.Text = "该订单不存在";
            }
        }

        private void btnDisplayOrder(object sender, EventArgs e)
        {
            orderBindingSource.DataSource = orderService.OrderList;
            orderBindingSource.ResetBindings(false);
        }

        private void btnModifyOrder(object sender, EventArgs e)
        {

            Order order = new Order();
            orderBindingSource.DataSource = orderService.OrderList;
            new Form2(ref order, orderService.sum).ShowDialog();
            Order current = orderBindingSource.Current as Order;
            orderService.ModifyOrder(current,order);
            order.Id = orderService.sum;
            orderBindingSource.ResetBindings(false);
        }
    }
}
