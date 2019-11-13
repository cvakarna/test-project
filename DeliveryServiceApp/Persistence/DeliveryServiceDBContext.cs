using DeliveryServiceApp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryServiceApp.Persistence
{
    public class DeliveryServiceDBContext: DbContext
    {
        public DeliveryServiceDBContext()
        {
        }

        public DeliveryServiceDBContext(DbContextOptions<DeliveryServiceDBContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ProductOrder> Orders { get; set; }

    }
}
