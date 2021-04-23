using System;
using System.Collections.Generic;
using Server.Models;

namespace Server.Controllers
{
    public class OrdersController
    {
        public void GetOrders(Action<OrdersResponse> onResponseHandler)
        {
            //TODO: realize get order from server. TEMP
            var response = new OrdersResponse {Data = new List<OrderData>()};
            onResponseHandler.Invoke(response);
        }

        public void GetReportByCurrentMonth(Action<double> onResponseHandler)
        {
            onResponseHandler.Invoke(0f);
        }

        [Serializable]
        public class OrdersResponse
        {
            public List<OrderData> Data { get; set; }
        }
    }
}
