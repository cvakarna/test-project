using DeliveryServiceApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryServiceApp.Orders
{
    public interface IOrderService
    {

         Task CreateOrderAsync(ProductOrder productOrder);

        Task<double> GetProductCostAsync(string custmerId, int distence);


    }
}
