using Mediafy.Checkout.Business.Dtos;
using Mediafy.Checkout.Business.Enums;
using Mediafy.Checkout.Domain.Entities;

namespace Mediafy.Checkout.Business.Mapper
{
    public static class OfferToOfferDtoMapper
    {
        public static OfferDto MapOfferToOfferDto(Offer offer)
        {
            if (offer == null) throw new ArgumentNullException(nameof(offer));

            return new OfferDto()
            {
                Id = offer.Id,
                Name = offer.Name,
                Price = offer.Price,
                Country = (CountryEnum)offer.Country,
                Product = ProductToProductDtoMapper.MapProductToProductDto(offer.Product),
                ProductId = offer.ProductId,
            };
        }
    }
}
