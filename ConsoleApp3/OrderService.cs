using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class OrderService
    {
        public List<Order> orderList =new List<Order>();
        public void DeleteOrder(Order o)
        {
            try
            {
                if (o == null)
                    throw new Exception();
                else
                    orderList.Remove(o);
            }
            catch
            {
                Console.WriteLine("该订单不存在！");
            }
        }

        public void AddOrder(Order o)
        {
            try
            {
                if (o == null)
                    throw new Exception();
                else
                    orderList.Add(o);

            }
            catch
            {
                Console.WriteLine("该订单不存在！");
            }

        }

      

        public void ModifyOrder(Order o, Order o1)
        {
            try
            {
                if (o1 == null)
                    throw new Exception();
                else
                {
                    o.User = o1.User;o.OrderItems = o1.OrderItems;o.Total = o1.Total;
                }


            }
            catch
            {
                Console.WriteLine("订单不能为空");
            }
        }

        public List<Order> InquiryOrder(int partern, string information)
        {
            List<Order> order = new List<Order>();
            switch (partern)
            {
                case 1:
                    var query1 = from s in orderList
                                   .Where(x => x.OrderItems.Exists(y => y.goods.Name.Contains(information)))
                                   .OrderByDescending(s => s.Total)
                                 select s;

                    return query1.ToList();
                case 2:
                    var query2 = from s in orderList
                                .Where(x => x.User.Name == information)
                                .OrderByDescending(s => s.Total)
                                 select s;

                    return query2.ToList();
                default: return null;

            }




        }


        public Order InquiryOrder(int id)
        {
            var query = from s in orderList
                        where s.Id == id
                        select s;

            return query.FirstOrDefault(); 



        }

    }
   }
