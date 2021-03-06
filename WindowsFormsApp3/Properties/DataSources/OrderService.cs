﻿using System;
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
        
        public void DeleteOrder(Order o)
        {
          
                if (o == null||!OrderList.Contains(o))
                    throw new Exception();
                else
                    OrderList.Remove(o);
           
         
        }

        public void AddOrder(Order o)
        {
            sum++;
           
              
                   
            if(o.Id!=-1)  
            OrderList.Add(o);

         

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
                    var query1 = from s in OrderList
                                   .Where(x => x.OrderItems.Exists(y => y.goods.Name.Contains(information)))
                                   .OrderByDescending(s => s.Total)
                                 select s;

                    return query1.ToList();
                case 2:
                    var query2 = from s in OrderList
                                .Where(x => x.User.Name == information)
                                .OrderByDescending(s => s.Total)
                                 select s;

                    return query2.ToList();
                default: return null;

            }




        }


        public Order InquiryOrder(int id)
        {
            var query = from s in OrderList
                        where s.Id == id
                        select s;

            return query.FirstOrDefault(); 



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
    }
   }
