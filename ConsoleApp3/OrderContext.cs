namespace ConsoleApp3
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class OrderContext : DbContext
    {
       
        public OrderContext():base("OrderDataBase")
            {

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<OrderContext>());
            }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
       

     
    }

 
}