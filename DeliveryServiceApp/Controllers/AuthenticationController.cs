using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryServiceApp.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace DeliveryServiceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authService;
        public AuthenticationController(IAuthenticationService authService)
        {
            this._authService = authService;
        }

        [HttpPost("validate-user")]
        public async Task<string> ValidateCredentialsAsync([FromBody] JObject usercredentials)
        {
            string result = null;
            try
            {
                if (usercredentials != null)
                {
                    string email = usercredentials["email"].ToString();
                    string password = usercredentials["password"].ToString();
                    result = await this._authService.ValidateCustomerAsync(email, password);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            return result;
            
        }
    }
}