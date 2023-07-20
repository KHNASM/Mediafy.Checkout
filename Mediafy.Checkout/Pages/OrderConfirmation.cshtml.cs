using Mediafy.Checkout.Business.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Checkout.Pages
{
    public class OrderConfirmationModel : PageModel
    {
        
        public OrderResult OrderResult { get; private set; }
        
        
        public IActionResult OnGet()
        {
            var resultJson = (string)TempData[Constants.OrderResultKey];

            OrderResult = System.Text.Json.JsonSerializer.Deserialize<OrderResult>(resultJson);

            if(OrderResult.Success)
            {
                OrderResult.Message = "Your result has been placed successfully. Thank you for your custom.";
            }
            else
            {
                OrderResult.Message ??= "Sorry, but an unexpected error occurred while attempting to place your order.";
            }

            return Page();
        }
    }
}
