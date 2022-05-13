using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderService.GraphQL;

namespace OrderService.Models
{ 
    public class OrderData
    {
        public int? UserId { get; set; }

        public List<OrderDetailData> Details { get; set; }

    }
}
