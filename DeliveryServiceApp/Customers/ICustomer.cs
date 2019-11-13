using DeliveryServiceApp.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryServiceApp.Customers
{
    public interface ICustomer
    {
        /// <summary>
        /// Create Customer
        /// </summary>
        /// <param name="customer">customer jobject</param>
        /// <returns></returns>
         Task OnCreateAsync(JObject customer);

        /// <summary>
        /// This Method Used to Update The Customer
        /// </summary>
        /// <param name="customer">customer jobj</param>
        /// <returns></returns>
        Task OnUpdateAsync(JObject customer);

        /// <summary>
        /// This Method used to delete the customer 
        /// </summary>
        /// <param name="customerId">customer id</param>
        /// <returns></returns>
         Task OnDeleteAsync(string customerId);

        /// <summary>
        /// Method Used To Get Customer Details Based On Customer Id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<Customer> GetCustomerDetailsAsync(string customerId);

    }
}
