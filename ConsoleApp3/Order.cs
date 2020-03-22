using System.Text;
using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    public class Order:IComparable
    {
        public List<OrderItem> OrderItems;
        public Customer User{get;set;}
        public int Id { get; set; }
        public double Total { get; set; }
        public Order(List<OrderItem> orderItems ,Customer user,int id)
        {
            OrderItems = orderItems;User = user;Id = id;
            double sum = 0;
            foreach (OrderItem Item in OrderItems)
            {
                sum += Item.TotalPrice;
            }
            Total = sum;

        }

        public int CompareTo(object obj)
        {
            Order order2 = obj as Order;
            if (order2 == null)
                throw new System.ArgumentException();
            return this.Id.CompareTo(order2.Id);
        }

        public override bool Equals(object obj)
        {
            var order = obj as Order;
            return order != null &&
                   EqualityComparer<List<OrderItem>>.Default.Equals(OrderItems, order.OrderItems) &&
                   EqualityComparer<Customer>.Default.Equals(User, order.User) &&
                   Id == order.Id;
        }

        public override int GetHashCode()
        {
            var hashCode = -1440167598;
            hashCode = hashCode * -1521134295 + EqualityComparer<List<OrderItem>>.Default.GetHashCode(OrderItems);
            hashCode = hashCode * -1521134295 + EqualityComparer<Customer>.Default.GetHashCode(User);
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            StringBuilder a = new StringBuilder();
            a.Append(User.ToString()+"\n");
            foreach (OrderItem item in OrderItems)
                a.Append(item.ToString()+"\n");
            return a.ToString();
        }
    }
}

