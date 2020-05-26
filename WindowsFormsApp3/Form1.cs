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
        
        
        public string KeyWord { get; set; }
     
        List<Order> orders = new List<Order>();
        public Form1()
        {
            InitializeComponent();


            orderBindingSource.DataSource = OrderService.GetAllOrders();
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
            Form2 form2 = new Form2(ref order);
            if (form2.tag)
            {
                form2.ShowDialog();
                
                    OrderService.AddOrder(order);
                    QueryAll();
                
            }
        }

        private void QueryAll()
        {
            orderBindingSource.DataSource = OrderService.GetAllOrders();
            orderBindingSource.ResetBindings(false);
        }

        private void btnQuery(object sender, EventArgs e)
        {
            try
            {
                switch (comboBox1.Text)
                {
                    case "订单号":
                        orderBindingSource.DataSource = OrderService.QueryOrdersByOrderId(textBox1.Text);
                        break;
                    case "顾客":
                        orderBindingSource.DataSource = OrderService.QueryOrdersByCustomerName(textBox1.Text);
                        break;
                    case "商品名":
                        orderBindingSource.DataSource = OrderService.QueryOrdersByGoodsName(textBox1.Text);
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
            Order order = orderBindingSource.Current as Order;
          
            OrderService.RemoveOrder(order);
            QueryAll();
        }

        private void btnDisplayOrder(object sender, EventArgs e)
        {
            QueryAll();
        }

        private void btnModifyOrder(object sender, EventArgs e)
        {

            Order order = new Order();
            Form2 form2 = new Form2(ref order);
            if (form2.tag)
            {
                form2.ShowDialog();
                
                    Order current = orderBindingSource.Current as Order;
                    OrderService.ModifyOrder(current, order);
                    orderBindingSource.ResetBindings(false);
                
            }
  
        }
    }
}
