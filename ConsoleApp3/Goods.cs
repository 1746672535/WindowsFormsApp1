using System;

namespace ConsoleApp3
{
    [Serializable]
    public class Goods
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Goods(string name,double price)
        {
            Name = name;Price = price;
        }
        public override string ToString()
        {
            return Name+"  :"+Price;
        }
        public Goods() { }
    }
}

