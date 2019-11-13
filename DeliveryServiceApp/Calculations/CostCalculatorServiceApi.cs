using DeliveryServiceApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryServiceApp.Calculations
{
    public static class CostCalculatorServiceApi
    {
        private static readonly double _orderbaseCost = 999;
        private static readonly double _orderless10 = 1098.9;
        private static readonly double _morethan50Base = 0.25;

        public static async Task<double> GetProductCostAsync(int distenceIn,int stairs,Customer cus)
        {
            double price = _orderbaseCost;
            if (cus != null&& cus.OrderProducts.Count!=0)//if customer already exists
            {
                if (cus.Golden)
                {
                    price = 899.1;
                }
                else if (cus.Coupan)
                {
                    price = 799.2;
                }
                else
                {
                    if (distenceIn < 10)
                    {
                        price = _orderless10;
                    }
                    else if (distenceIn < 50 && distenceIn > 10)
                    {
                        price = 1248.75;
                    }
                    else if (distenceIn > 50)
                    {
                        price = _orderbaseCost + (distenceIn * _morethan50Base);
                    }
                }
            }
            else if(cus != null && cus.OrderProducts.Count ==0)//if Customer not exists
            {
                price = 849.15;
            }
            
            return price;
        }

    }
}
