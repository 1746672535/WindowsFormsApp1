using System.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp3
{
    [Serializable]
    public class Order : IComparable
    {
        
        public List<OrderItem> OrderItems { get; set; }
        [NotMapped]
        public Customer User { get; set; }

        public string CustomerName { get; set; }

        public int OrderId { get; set; }

        public double Total { get; set; }


        public Order(List<OrderItem> orderItems, Customer user, int id,string customer)
        {
            OrderItems = orderItems; User = user; OrderId = id;
            double sum = 0;
            foreach (OrderItem Item in OrderItems)
            {
                sum += Item.TotalPrice;
            }
            Total = sum;

        }

        public Order()
        {
            this.OrderItems = new List<OrderItem>();
            User = new Customer();
        }

        public int CompareTo(object obj)
        {
            Order order2 = obj as Order;
            if (order2 == null)
                throw new System.ArgumentException();
            return this.OrderId.CompareTo(order2.OrderId);

        }

        public override bool Equals(object obj)
        {
            var order = obj as Order;
            return order != null &&
                   EqualityComparer<List<OrderItem>>.Default.Equals(OrderItems, order.OrderItems) &&
                   EqualityComparer<Customer>.Default.Equals(User, order.User) &&
                   OrderId == order.OrderId;
        }

        public override int GetHashCode()
        {
            var hashCode = -1440167598;
            hashCode = hashCode * -1521134295 + EqualityComparer<List<OrderItem>>.Default.GetHashCode(OrderItems);
            hashCode = hashCode * -1521134295 + EqualityComparer<Customer>.Default.GetHashCode(User);
            hashCode = hashCode * -1521134295 + OrderId.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            StringBuilder a = new StringBuilder();
            a.Append(User.ToString() + "\n");
            foreach (OrderItem item in OrderItems)
                a.Append(item.ToString() + "\n");
            return a.ToString();
        }

        public void addOrderItem(OrderItem orderItem)
        {
            if (orderItem.Amount != -1)
                this.OrderItems.Add(orderItem);
            using (var db = new OrderContext()) {
                db.OrderItems.Add(orderItem);
                db.SaveChanges();
            }
        }

        public void deleteOrderItem(OrderItem orderItem)
        {
            this.OrderItems.Remove(orderItem);
            using (var context = new OrderContext())
            {
                context.OrderItems.Remove(orderItem);
                context.SaveChanges();

            }
        }

        public void modifyOrderItem(OrderItem orderItem1, OrderItem orderItem2)
        {
            if (orderItem2.Amount != -1)
            {
                using (var context = new OrderContext())
                {
                    orderItem1.Amount = orderItem2.Amount;
                    orderItem1.TotalPrice = orderItem2.TotalPrice;
                    orderItem1.NameId = orderItem2.NameId;
                    context.SaveChanges();

                }
               
            }
        }

        public double getTotal()
        {
            double sum = 0;
            foreach (OrderItem Item in OrderItems)
            {
                sum += Item.TotalPrice;
            }
            return sum;
        }
       

    }
}

