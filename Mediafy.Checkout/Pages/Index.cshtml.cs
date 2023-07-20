using Mediafy.Checkout.Business.Dtos;
using Mediafy.Checkout.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Checkout.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IOfferHandler _offerHandler;

        public IndexModel(IOfferHandler offerHandler)
        {
            _offerHandler = offerHandler;
        }

        public OfferDto[] Offers { get; private set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Offers = await _offerHandler.GetAllOffersAsync();
            return Page();
        }
      
    }
}
