using DeliveryServiceApp.Model;
using DeliveryServiceApp.Persistence;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryServiceApp.Customers
{
    public class CustomerServiceApi : ICustomer
    {
        private readonly string _connectionString;
        private readonly DeliveryServiceDBContext _context;
        string tableName = "Customers";
        public CustomerServiceApi(DeliveryServiceDBContext context)
        {
            this._context = context;
        }
       
        public async Task<Customer> GetCustomerDetailsAsync(string customerId)
        {

            Customer customer = _context.Customers.Where(cus => cus.Id == customerId).Include(op => op.OrderProducts).FirstOrDefault();
            return customer;

        }

        public async Task OnCreateAsync(JObject customer)
        {
            //convert customer to object
             Customer cusObj = customer.ToObject<Customer>();
            _context.Customers.Add(cusObj);
            await _context.SaveChangesAsync();

        }

        public async Task OnDeleteAsync(string customerId)
        {
            var custmer = new Customer { Id = customerId };
            _context.Entry(custmer).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public async Task OnUpdateAsync(JObject customer)
        {
            //convert customer obejct
            var custmer = customer.ToObject<Customer>();
            _context.Customers.Add(custmer);
            _context.Entry(custmer).State = EntityState.Modified;
            _context.SaveChanges();

        }
    }
}
