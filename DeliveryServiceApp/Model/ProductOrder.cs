using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryServiceApp.Model
{

    [Table("siva_orders")]
    public class ProductOrder
    {
        [Key]
        public string OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }
        public string PinCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Name { get; set; }

        [ForeignKey("Customers")]
        public string CustomerId { get; set; }

    }
}
