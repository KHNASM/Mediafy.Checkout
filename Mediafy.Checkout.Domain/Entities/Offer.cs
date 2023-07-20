using Mediafy.Checkout.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediafy.Checkout.Domain.Entities
{
    public class Offer
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public Country Country { get; set; }
        public Product Product { get; set; }
    }
}
