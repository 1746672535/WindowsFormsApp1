using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp3
{
    [Serializable]
    public class OrderItem
    {
        [Key]
        public string NameId { get; set; }
        public double Price { set; get; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public double TotalPrice { get; set; }
       

        public OrderItem(string name,int amount,double price)
        {
            Price = price;
         Amount = amount;
            Name = name;
            TotalPrice = Price * Amount;
        }
        public OrderItem()
        {
        
            NameId = Guid.NewGuid().ToString();
        }

        public override bool Equals(object obj)
        {
            var item = obj as OrderItem;
            return item != null &&
                   
                   Amount == item.Amount &&
                   TotalPrice == item.TotalPrice;
        }

        public override int GetHashCode()
        {
            var hashCode = 122325556;
       
            hashCode = hashCode * -1521134295 + Amount.GetHashCode();
            hashCode = hashCode * -1521134295 + TotalPrice.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "Item:"  + "   Amount:" + Amount + "   TotalPrice:" + TotalPrice;
        }
    }
}

