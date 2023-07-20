using Mediafy.Checkout.Business.Dtos;
using Mediafy.Checkout.Domain.Entities;

namespace Mediafy.Checkout.Business.Mapper
{
    public static class ProductToProductDtoMapper
    {
       public static ProductDto MapProductToProductDto(Product product)
        {
            if (product == null) throw new ArgumentNullException();

            return new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Offers = product.Offers.Select(x => OfferToOfferDtoMapper.MapOfferToOfferDto(x))
            };
        }
    }
}
