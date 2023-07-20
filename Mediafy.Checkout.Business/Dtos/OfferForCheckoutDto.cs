using Mediafy.Checkout.Domain.Entities;
using Mediafy.Checkout.Domain.Enums;

namespace Mediafy.Checkout.Business.Dtos;

public class OfferForCheckoutDto
{
    public int OfferId { get; set; }

    public Country Country { get; set; }

    public string ImageUrl { get; set; }

    public static OfferForCheckoutDto FromEntity(Offer entity)
    {
        return new()
        {
            OfferId = entity.Id,
            Country = entity.Country,
            ImageUrl = entity.Product.ImageUrl
        };
    }
}
