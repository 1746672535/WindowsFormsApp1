﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp3
{
    [Serializable]
    public class OrderItem
    {
        [NotMapped]
        public Goods goods { get; set; }
        public string NameId { get; set; }
        public int Amount { get; set; }
        public double TotalPrice { get; set; }

        public int OrderId{ get; set; }
        public Order Order { get; set; }
        public OrderItem(Goods good,int amount)
        {
            goods = good;Amount = amount;
            TotalPrice = goods.Price * Amount;
        }
        public OrderItem()
        {
            goods = new Goods();
        }

        public override bool Equals(object obj)
        {
            var item = obj as OrderItem;
            return item != null &&
                   EqualityComparer<Goods>.Default.Equals(goods, item.goods) &&
                   Amount == item.Amount &&
                   TotalPrice == item.TotalPrice;
        }

        public override int GetHashCode()
        {
            var hashCode = 122325556;
            hashCode = hashCode * -1521134295 + EqualityComparer<Goods>.Default.GetHashCode(goods);
            hashCode = hashCode * -1521134295 + Amount.GetHashCode();
            hashCode = hashCode * -1521134295 + TotalPrice.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "Item:" + goods.ToString() + "   Amount:" + Amount + "   TotalPrice:" + TotalPrice;
        }
    }
}

