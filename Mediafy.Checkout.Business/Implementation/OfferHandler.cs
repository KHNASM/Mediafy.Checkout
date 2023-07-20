using Mediafy.Checkout.Business.Dtos;
using Mediafy.Checkout.Business.Interfaces;
using Mediafy.Checkout.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace Mediafy.Checkout.Business.Implementation
{
    public class OfferHandler : IOfferHandler
    {
        private readonly MediafyInMemoryContext _dbContext;

        public OfferHandler(MediafyInMemoryContext context)
        {
            _dbContext = context;
        }

        public Task<OfferDto[]> GetAllOffersAsync()
        {
            return _dbContext.Offers
                .Include(e => e.Product)
                .Select(e => OfferDto.FromEntity(e))
                .ToArrayAsync();
        }

        public Task<OfferForCheckoutDto> GetOfferForCheckoutAsync(int offerId)
        {
            return _dbContext.Offers
                .Include(e => e.Product)
                .Where(e => e.Id == offerId)
                .Select(e => OfferForCheckoutDto.FromEntity(e))
                .SingleOrDefaultAsync();
        }
    }
}
