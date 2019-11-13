using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryServiceApp.Authentication
{
    public interface IAuthenticationService
    {

        Task<string> ValidateCustomerAsync(string email,string password);


    }
}
