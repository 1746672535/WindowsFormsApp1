using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("欢迎使用本订单系统");
            Console.WriteLine("#########################");
            Console.WriteLine("请选择您要使用的服务：");
            Console.WriteLine("输入1：创建新订单");
            Console.WriteLine("输入2：修改订单");
            Console.WriteLine("输入3：删除订单");
            Console.WriteLine("输入4：查询订单订单");
            Console.WriteLine("输入5：退出系统");
            Console.WriteLine("输入6：将所有的订单序列化");
            Console.WriteLine("输入7：从XML文件中载入订单");
            bool flag = true;
            Dictionary<string, Customer> Users = new Dictionary<string, Customer>();
            int count = 0;

            OrderService orderService = new OrderService();
            orderService.OrderList = new List<Order>();
            do
            {
                Console.WriteLine("请选择您要使用的服务：");
                bool flags = false;
                int i=0;
                do
                {
                    try
                    {
                        
                        i = int.Parse(Console.ReadLine());
                        if(i>0&&i<8)
                        flags = true;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("请给出正确的输入");
                    }
                    } while (!flags);
                switch (i)
                {


                    case 1:
                        count++;
                        List<OrderItem> orderItems=new List<OrderItem>();
                        Console.WriteLine("请输入用户名");
                        string user = Console.ReadLine();
                        if (orderService.OrderList.Count()==0 || Users[user] == null)
                        {
                            Console.WriteLine("请输入电话号码");
                            string phoneNum = Console.ReadLine();
                            Console.WriteLine("请输入地址");
                            string address = Console.ReadLine();
                            Customer customer1 = new Customer(user, phoneNum, address);
                            Users.Add(user, customer1);
                        }
                      
                        Customer customer = Users[user];
                        
                        Console.WriteLine("请以此输入订单项目的名称、单价和数量，并在最后输入“stop”停止");
                        string input = null;
                        do
                        {
                            input = Console.ReadLine();
                            if (input != "stop")
                            {
                                string name = input;
                                int price = int.Parse(Console.ReadLine());
                                int amount = int.Parse(Console.ReadLine());
                                Goods good = new Goods(name, price);
                                OrderItem orderItem = new OrderItem(good, amount);
                                orderItems.Add(orderItem);

                            }

                        } while (input != "stop");
                        Order order = new Order(orderItems, customer, count);
                        orderService.OrderList.Add(order);
                        Console.WriteLine("您已经成功创建订单，订单号为："+count);
                        break;
                    case 2:
                        Console.WriteLine("请选择您要修改的订单号");
                        int ID = int.Parse(Console.ReadLine());
                        if (orderService.InquiryOrder(ID) == null)
                        {
                            Console.WriteLine("该订单不存在。");
                                continue; }

                        List<OrderItem> orderItems1 = new List<OrderItem>();
                        Console.WriteLine("请输入用户名");
                        string user1 = Console.ReadLine();
                        if (orderService.OrderList.Count() == 0 || Users[user1] == null)
                        {
                            Console.WriteLine("请输入电话号码");
                            string phoneNum = Console.ReadLine();
                            Console.WriteLine("请输入地址");
                            string address = Console.ReadLine();
                            Customer customer2 = new Customer(user1, phoneNum, address);
                            Users.Add(user1, customer2);
                        }

                        Customer customer3 = Users[user1];

                        Console.WriteLine("请以此输入订单项目的名称、单价和数量，并在最后输入“stop”停止");
                        string input1 = null;
                        do
                        {
                            input = Console.ReadLine();
                            if (input1 != "stop")
                            {
                                string name = input;
                                int price = int.Parse(Console.ReadLine());
                                int amount = int.Parse(Console.ReadLine());
                                Goods good = new Goods(name, price);
                                OrderItem orderItem = new OrderItem(good, amount);
                                orderItems1.Add(orderItem);

                            }

                        } while (input1 != "stop");
                        Order order1 = new Order(orderItems1, customer3,0);

                        orderService.ModifyOrder(orderService.InquiryOrder(ID), order1);
                        break;
                    case 3:
                        Console.WriteLine("请选择您要删除的订单号");
                        int ID1 = int.Parse(Console.ReadLine());
                        if (orderService.InquiryOrder(ID1) == null)
                        {
                            Console.WriteLine("该订单不存在。");
                            continue;
                        }
                        orderService.DeleteOrder(orderService.InquiryOrder(ID1));
                        break;
                    case 4:
                        Console.WriteLine("请选择您查询的方式：//1：根据订单号查询  //2：根据货物查询  //3：根据用户查询");
                        int partern = int.Parse(Console.ReadLine());
                        switch (partern)
                        {
                            case 1:
                                Console.WriteLine("请输入订单号");
                                int ID3 = int.Parse(Console.ReadLine());
                                if (orderService.InquiryOrder(ID3) == null)
                                {
                                    Console.WriteLine("该订单不存在。");
                                    continue;
                                }
                                Console.WriteLine(orderService.InquiryOrder(ID3).ToString());
                                break;
                             case 2:
                                Console.WriteLine("请输入货物名");
                                string name1 = Console.ReadLine();
                                if (orderService.InquiryOrder(1,name1) == null)
                                {
                                    Console.WriteLine("该订单不存在。");
                                    continue;
                                }

                                foreach (Order order0 in orderService.InquiryOrder(1, name1))
                                    Console.WriteLine(order0.ToString());
                                break;
                            case 3:
                                Console.WriteLine("请输用户名");
                                string name2 = Console.ReadLine();
                                if (orderService.InquiryOrder(2, name2) == null)
                                {
                                    Console.WriteLine("该订单不存在。");
                                    continue;
                                }

                                foreach (Order order0 in orderService.InquiryOrder(2, name2))
                                    Console.WriteLine(order0.ToString());
                                break;


                        }
                        break;



                    case 5:
                        flag = false;break;
                    case 6:
                        Console.WriteLine("输入您要创建的文件名（以.xml结尾）");
                        string filename = Console.ReadLine();
                        orderService.Export(filename);break;
                    case 7:
                        Console.WriteLine("输入您要查找的文件名（以.xml结尾）");
                        string filename1 = Console.ReadLine();
                        orderService.Import(filename1);break;
                    default:
                        break;
                }


            } while (flag);
            Console.WriteLine("感谢您使用此系统，再见qwq");

        }
    }
}

