using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp3
{
    public class OrderService
    {
        public List<Order> OrderList { get; set; } = new List<Order>();
        public int sum = 1;

        public OrderService()
        {
            OrderList = new List<Order>();
        }


        public static List<Order> GetAllOrders()
        {
            using (var db = new OrderContext())
            {
                return AllOrders(db).ToList();
            }
        }



        public static void RemoveOrder(Order order1)
        {
            try
            {
                using (var db = new OrderContext())
                {
                    var order = db.Orders.Include("OrderItems").Where(o => o.Id == order1.Id).FirstOrDefault();
                    db.Orders.Remove(order);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                
                throw new ApplicationException($"删除订单错误!");
            }
        }

        public static Order AddOrder(Order order)
        {
            try
            {
                using (var db = new OrderContext())
                {
                    db.Orders.Add(order);
                    db.SaveChanges();
                }
                return order;
            }
            catch (Exception e)
            {
              
                throw new ApplicationException($"添加错误: {e.Message}");
            }
        }



        public static void ModifyOrder(Order o, Order o1)
        {
            RemoveOrder(o);
            AddOrder(o1);
        }

        public static List<Order> QueryOrdersByGoodsName(string goodsName)
        {
            using (var db = new OrderContext())
            {
                var query = AllOrders(db)
                  .Where(o => o.OrderItems.Count(i => i.Name == goodsName) > 0);
                return query.ToList();
            }
        }

        public static List<Order> QueryOrdersByCustomerName(string customerName)
        {
            using (var db = new OrderContext())
            {
                var query = AllOrders(db)
                  .Where(o => o.CustomerName == customerName);
                return query.ToList();
            }
        }

        public static List<Order> QueryOrdersByOrderId(string Id)
        {
            using (var db = new OrderContext())
            {
                var query = AllOrders(db)
                  .Where(o => o.Id == Id);
                return query.ToList();
            }
        }







        public void Export(string filename)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
                using (FileStream fs = new FileStream(filename, FileMode.Create))
                { xmlSerializer.Serialize(fs, OrderList); }
                foreach (Order order in OrderList)
                { Console.WriteLine(order); }
            }
            catch (Exception)
            { Console.WriteLine(@"文件名必须以'.xml'结尾"); }
        }

        public void Import(string filename)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
                Console.WriteLine(File.ReadAllText(filename));
                using (FileStream fs = new FileStream(filename, FileMode.Open))

                {
                    
                    List<Order> orderlist = (List<Order>)xmlSerializer.Deserialize(fs);
                    foreach (Order order in orderlist)
                    { Console.WriteLine(order); }
                }
              
            }
            catch (Exception)
            {
                Console.WriteLine(@"文件名必须以'.xml'结尾");
            }
                    
         }


        private static IQueryable<Order> AllOrders(OrderContext db)
        {
            return db.Orders.Include("OrderItems");
        }
    }
 }
