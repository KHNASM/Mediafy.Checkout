using Mediafy.Checkout.Business.Dtos;

namespace Mediafy.Checkout.Business.Interfaces;

public interface IOfferHandler
{
    Task<OfferDto[]> GetAllOffersAsync();

    Task<OfferForCheckoutDto> GetOfferForCheckoutAsync(int offerId);
}