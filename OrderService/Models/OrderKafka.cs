using System;
using System.Collections.Generic;

namespace OrderService.Models
{
    public partial class OrderKafka
    {
        public int Id { get; set; }
        public string OrderCode { get; set; } = null!;
        public string OrderContent { get; set; } = null!;
        public DateTime Created { get; set; }
    }
}
