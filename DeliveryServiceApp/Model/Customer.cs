using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryServiceApp.Model
{
    [Table("siva_customers")]
    public class Customer
    {
        [Key]
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public bool Golden { get; set; }
        public bool Coupan { get; set; }
        public string Password { get; set; }
        public ICollection<ProductOrder> OrderProducts { get; set; }

        public Customer(){
            this.OrderProducts = new List<ProductOrder>();
        }
    }
}
