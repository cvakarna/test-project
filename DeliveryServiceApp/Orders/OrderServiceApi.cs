using DeliveryServiceApp.Calculations;
using DeliveryServiceApp.Customers;
using DeliveryServiceApp.Model;
using DeliveryServiceApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryServiceApp.Orders
{
    public class OrderServiceApi:IOrderService
    {
        private readonly ICustomer _customer;
        private readonly DeliveryServiceDBContext _context;
        public OrderServiceApi(ICustomer customer, DeliveryServiceDBContext context)
        {
            _customer = customer;
            _context = context;

        }

        public async Task<double> GetProductCostAsync(string custmerId,int distence)
        {

            var customer = await _customer.GetCustomerDetailsAsync(custmerId);
            var totalprice = await CostCalculatorServiceApi.GetProductCostAsync(distence, 0, customer);
            return totalprice;
        }


        public async Task CreateOrderAsync(ProductOrder order)
        {
           
               _context.Orders.Add(order);
               await _context.SaveChangesAsync();
            
        }

    }
}
