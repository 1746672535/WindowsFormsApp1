using System;

namespace ConsoleApp3
{
    [Serializable]
    public class Customer
    {
        public string Name { set; get; }
        public string PhoneNum { set; get; }
        public string Address { set; get; }
        public Customer(string name, string phoneNum, string address)
        {
            Name = name;PhoneNum = phoneNum;Address = address;

        }
        public Customer() { }

        public override string ToString()
        {
            return "Name:" + Name + "   PhoneNum:" + PhoneNum + "   Address:" + Address;
        }
    }
}

