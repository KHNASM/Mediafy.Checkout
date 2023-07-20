using Mediafy.Checkout.Business.Mapper;
using Mediafy.Checkout.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediafy.Checkout.Business.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public virtual IEnumerable<OfferDto> Offers { get; set; }

        public static ProductDto FromEntity(Product entity)
        {

            return entity is null ? null : new ProductDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                ImageUrl = entity.ImageUrl,
                Offers = entity.Offers.Select(x => OfferToOfferDtoMapper.MapOfferToOfferDto(x))
            };
        }
    }
}
