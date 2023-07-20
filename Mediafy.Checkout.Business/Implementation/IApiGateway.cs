using Mediafy.Checkout.Business.Dtos;

namespace Mediafy.Checkout.Business.Implementation
{
    public interface IApiGateway
    {
        Task<OrderResult> PlaceOrderAsync(OrderRequestDto orderRequest);
    }
}


