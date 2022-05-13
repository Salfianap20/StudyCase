using System;
using System.Collections.Generic;

namespace OrderProcessor.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public int? UserId { get; set; }

        public virtual User? User { get; set; }
    }
}
