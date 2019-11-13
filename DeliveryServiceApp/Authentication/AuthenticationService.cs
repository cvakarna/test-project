using DeliveryServiceApp.Persistence;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryServiceApp.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly DeliveryServiceDBContext _context;
        public AuthenticationService(DeliveryServiceDBContext context)
        {
            _context = context;

        }
        
        public async Task<string> ValidateCustomerAsync(string email, string password)
        {
           var record =  _context.Customers.Where(cus => cus.Email == email && cus.Password == password).FirstOrDefault();
           return record != null ? JsonConvert.SerializeObject(record) : null;
        }
    }
}
