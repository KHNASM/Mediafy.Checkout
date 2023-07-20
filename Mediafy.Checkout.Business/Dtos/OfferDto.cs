using Mediafy.Checkout.Business.Enums;
using Mediafy.Checkout.Business.Mapper;
using Mediafy.Checkout.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediafy.Checkout.Business.Dtos
{
    public class OfferDto
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; }

        public int ProductId { get; set; }

        public CountryEnum Country { get; set; }

        public ProductDto Product { get; set; }


        public static OfferDto FromEntity(Offer offer)
        {
            return offer is null ? null : new()
            {
                Id = offer.Id,
                Name = offer.Name,
                Price = offer.Price,
                Country = (CountryEnum)offer.Country,
                Product = ProductDto.FromEntity(offer.Product),
                ProductId = offer.ProductId,
            };
        }
    }
}
