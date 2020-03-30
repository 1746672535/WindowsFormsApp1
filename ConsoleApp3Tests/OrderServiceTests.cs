using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp3.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
     



        [TestMethod()]
        public void DeleteOrderTest()
        {
            OrderService orderService = new OrderService();
            
            Order order1 = new Order();
            Order order=null;
            orderService.DeleteOrder(order);
            orderService.DeleteOrder(null);
            
            orderService.DeleteOrder(order);

            orderService.AddOrder(order1);
            orderService.DeleteOrder(order1);
            Assert.IsNull(orderService.OrderList);


            Assert.Fail();
        }

        [TestMethod()]
        public void AddOrderTest()
        {

            OrderService orderService = new OrderService();
            Customer customer = new Customer("mary","8888888","New York");
            Goods goods = new Goods("bread", 4.0);
            OrderItem orderItem = new OrderItem(goods, 10);
            List<OrderItem> orderItems = new List<OrderItem>();
            orderItems.Add(orderItem);
            Order order1 = new Order(orderItems,customer,1);
            orderService.AddOrder(order1);
            Assert.AreEqual(order1, orderService.OrderList.First());

            Assert.Fail();
        }

        [TestMethod()]
        public void ModifyOrderTest()
        {
            OrderService orderService = new OrderService();

            Customer customer1 = new Customer("jack", "55555555", "Washington");
            Goods goods1 = new Goods("milk", 2.0);
            OrderItem orderItem1 = new OrderItem(goods1, 8);
            List<OrderItem> orderItems1 = new List<OrderItem>();
            orderItems1.Add(orderItem1);
            Order order1 = new Order(orderItems1, customer1, 1);
            
          
            Customer customer2 = new Customer("mary", "8888888", "New York");
            Goods goods2 = new Goods("bread", 4.0);
            OrderItem orderItem2 = new OrderItem(goods2, 10);
            List<OrderItem> orderItems2 = new List<OrderItem>();
            orderItems2.Add(orderItem2);
            Order order2 = new Order(orderItems2, customer2, 2);
            orderService.AddOrder(order1);
            orderService.ModifyOrder(order1, order2);
            Assert.AreEqual(order1.Id, order2.Id);
            Assert.AreEqual(order1.User, order2.User);
            Assert.AreEqual(order1.OrderItems, order2.OrderItems);



            Assert.Fail();
        }

        [TestMethod()]
        public void InquiryOrderTest()
        {
            OrderService orderService = new OrderService();

            Customer customer1 = new Customer("jack", "55555555", "Washington");
            Goods goods1 = new Goods("milk", 2.0);
            OrderItem orderItem1 = new OrderItem(goods1, 8);
            List<OrderItem> orderItems1 = new List<OrderItem>();
            orderItems1.Add(orderItem1);
            Order order1 = new Order(orderItems1, customer1, 1);


            Customer customer2 = new Customer("mary", "8888888", "New York");
            Goods goods2 = new Goods("bread", 4.0);
            OrderItem orderItem2 = new OrderItem(goods2, 10);
            List<OrderItem> orderItems2 = new List<OrderItem>();
            orderItems2.Add(orderItem2);
            Order order2 = new Order(orderItems2, customer2, 2);
            
            orderService.AddOrder(order1);
            orderService.AddOrder(order2);
            Order order3=orderService.InquiryOrder(1);
            Assert.AreEqual(order3, order1);



            Assert.Fail();
        }

        [TestMethod()]
        public void InquiryOrderTest1()
        {
            OrderService orderService = new OrderService();

            Customer customer1 = new Customer("jack", "55555555", "Washington");
            Goods goods1 = new Goods("milk", 2.0);
            OrderItem orderItem1 = new OrderItem(goods1, 8);
            List<OrderItem> orderItems1 = new List<OrderItem>();
            orderItems1.Add(orderItem1);
            Order order1 = new Order(orderItems1, customer1, 1);


            Customer customer2 = new Customer("mary", "8888888", "New York");
            Goods goods2 = new Goods("bread", 4.0);
            OrderItem orderItem2 = new OrderItem(goods2, 10);
            List<OrderItem> orderItems2 = new List<OrderItem>();
            orderItems2.Add(orderItem2);
            Order order2 = new Order(orderItems2, customer2, 2);

            orderService.AddOrder(order1);
            orderService.AddOrder(order2);
            List<Order> orderList1 = orderService.InquiryOrder(1,"bread");
            List<Order> orderList2 = orderService.InquiryOrder(2, "jack");
            Assert.AreEqual(orderList1.First(), order2);
            Assert.AreEqual(orderList2.First(), order1);



            Assert.Fail();
        }

        [TestMethod()]
        public void ExportTest()
        {

            OrderService orderService = new OrderService();

            Customer customer1 = new Customer("jack", "55555555", "Washington");
            Goods goods1 = new Goods("milk", 2.0);
            OrderItem orderItem1 = new OrderItem(goods1, 8);
            List<OrderItem> orderItems1 = new List<OrderItem>();
            orderItems1.Add(orderItem1);
            Order order1 = new Order(orderItems1, customer1, 1);


            Customer customer2 = new Customer("mary", "8888888", "New York");
            Goods goods2 = new Goods("bread", 4.0);
            OrderItem orderItem2 = new OrderItem(goods2, 10);
            List<OrderItem> orderItems2 = new List<OrderItem>();
            orderItems2.Add(orderItem2);
            Order order2 = new Order(orderItems2, customer2, 2);

            orderService.Export("2.xml");

            string test = "Name:jack   PhoneNum:55555555   Address:Washington\n" +
                "Item:milk  :2.0   Amount:8   TotalPrice:16.0\n" +
                "Name:mary   PhoneNum:88888888   Address:New York\n" +
                "Item:bread  :4.0   Amount:10   TotalPrice:40.0";

            Assert.IsTrue(File.Exists("2.xml"));

            Assert.AreEqual(File.ReadAllText("2.xml"),test);

            Assert.Fail();
        }

        [TestMethod()]
        public void ImportTest()
        {
            OrderService orderService = new OrderService();

            

            Customer customer1 = new Customer("jack", "55555555", "Washington");
            Goods goods1 = new Goods("milk", 2.0);
            OrderItem orderItem1 = new OrderItem(goods1, 8);
            List<OrderItem> orderItems1 = new List<OrderItem>();
            orderItems1.Add(orderItem1);
            Order order1 = new Order(orderItems1, customer1, 1);


            Customer customer2 = new Customer("mary", "8888888", "New York");
            Goods goods2 = new Goods("bread", 4.0);
            OrderItem orderItem2 = new OrderItem(goods2, 10);
            List<OrderItem> orderItems2 = new List<OrderItem>();
            orderItems2.Add(orderItem2);
            Order order2 = new Order(orderItems2, customer2, 2);

            orderService.Import("2.xml");

            string test = "Name:jack   PhoneNum:55555555   Address:Washington\n" +
                "Item:milk  :2.0   Amount:8   TotalPrice:16.0\n" +
                "Name:mary   PhoneNum:88888888   Address:New York\n" +
                "Item:bread  :4.0   Amount:10   TotalPrice:40.0";

            orderService.Import(null);
            Assert.Fail();
        }
    }
}