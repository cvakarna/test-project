using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryServiceApp.Customers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DeliveryServiceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomer _customer;
        public CustomerController(ICustomer customer)
        {
            _customer = customer;
        }


        [HttpPost]
        public async Task CreateCustomer([FromBody]JObject customer)
        {
            try
            {
               await  _customer.OnCreateAsync(customer);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        [HttpPut]
        public async Task UpdateCustomer([FromBody]JObject customer)
        {
            try
            {
                await _customer.OnUpdateAsync(customer);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            
        }

        [HttpGet]
        public async Task<string> GetCustomer(string customerId)
        {
            string custometr = null;
            try
            {
                var custObj = await _customer.GetCustomerDetailsAsync(customerId);
                custometr = JsonConvert.SerializeObject(custObj);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            return custometr;
        }

        [HttpDelete]
        public async Task DeleteCustomer(string customerId)
        {
            try
            {
                 await _customer.OnDeleteAsync(customerId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
           
        }


    }
}