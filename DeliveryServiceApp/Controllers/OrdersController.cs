using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DeliveryServiceApp.Model;
using DeliveryServiceApp.Orders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using Serilog.Core;

namespace DeliveryServiceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {

        private readonly IOrderService _orderService;
        public OrdersController(IOrderService order)
        {
            _orderService = order;
        }

        [HttpGet("order-cost")]
        public async Task<double> GetProductCostAsync(string customerId,int distence)
        {
            try
            {
                Log.Information("CustomerId :{0},Distence:{1}",customerId,distence);
                return await _orderService.GetProductCostAsync(customerId, distence);
            }
            catch(Exception ex)
            {
                Log.Error(ex, "CustomerId :{0},Ditence:{1}",customerId,distence);
                throw;
            }
             

        }

        [HttpPost("place-order")]
        public async Task PlaceOrderAsync([FromBody]JObject productOrder)
        {
            try
            {
                if (productOrder != null)
                {
                    var orderObj = productOrder.ToObject<ProductOrder>();
                    await _orderService.CreateOrderAsync(orderObj);
                }
                else
                {
                    throw new Exception("Product Order should not be null");
                }
            }
            catch(Exception ex)
            {
                Log.Error(ex, "ProductOrder:{product}", productOrder);
                throw;
            }
            
           
        }

    }
}