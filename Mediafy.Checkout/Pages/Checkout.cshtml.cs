using Mediafy.Checkout.Business.Configurations;
using Mediafy.Checkout.Business.Dtos;
using Mediafy.Checkout.Business.Implementation;
using Mediafy.Checkout.Business.Interfaces;
using Mediafy.Checkout.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Checkout.Pages
{
    public class CheckoutModel : PageModel
    {
        private readonly IOfferHandler _offerHandler;
        private readonly IApiGateway _apiGateway;
        private readonly CountriesConfiguration _contriesConfigMap;
        private readonly ValidationRules _validationRules;


        public CheckoutModel(
            IOfferHandler offerHandler,
            IApiGateway apiGateway,
            IOptionsMonitor<CountriesConfiguration> countriesMapOptionMonitor,
            IOptionsMonitor<ValidationRules> validationRulesOptionMonitor)
        {
            _offerHandler = offerHandler;
            _apiGateway = apiGateway;
            _contriesConfigMap = countriesMapOptionMonitor.CurrentValue;
            _validationRules = validationRulesOptionMonitor.CurrentValue;
        }

        [BindProperty]
        public OrderRequestDto OrderRequest { get; set; }

        public OfferForCheckoutDto CheckoutDto { get; private set; }

        public bool IsPhoneNumberRequired { get; private set; }

        public SelectList SelectableCountries { get; private set; }

        public async Task<IActionResult> OnGetAsync(int offerId)
        {
            await PreparePageDataAsync(offerId);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int offerId)
        {
            if (OrderRequest.OfferId != offerId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                await PreparePageDataAsync(offerId);
                return Page();
            }

            string country = OrderRequest.Country?.ToString();
            var phoneValidationRule = _validationRules.GetPhoneNumberValidationRule(country);
            var zipValidationRule = _validationRules.GetZipCodeValidationRule(country);

            if (phoneValidationRule.IsRequired && string.IsNullOrWhiteSpace(OrderRequest.Telephone))
            {
                ModelState.AddModelError($"{nameof(OrderRequest)}.{nameof(OrderRequest.Telephone)}", "Telephone number is required.");
            }

            if (!Regex.IsMatch(OrderRequest.ZipCode, zipValidationRule.Pattern))
            {
                ModelState.AddModelError($"{nameof(OrderRequest)}.{nameof(OrderRequest.ZipCode)}", zipValidationRule.ErrorMessage);
            }

            if (!ModelState.IsValid)
            {
                await PreparePageDataAsync(offerId);
                return Page();
            }

            var result = await _apiGateway.PlaceOrderAsync(OrderRequest);

            TempData[Constants.OrderResultKey] = System.Text.Json.JsonSerializer.Serialize(result);

            return RedirectToPage("OrderConfirmation");
        }

        private async Task PreparePageDataAsync(int offerId)
        {
            CheckoutDto = await _offerHandler.GetOfferForCheckoutAsync(offerId);
            OrderRequest = new() { OfferId = offerId };
            IsPhoneNumberRequired = _validationRules.GetPhoneNumberValidationRule(CheckoutDto.Country.ToString()).IsRequired;

            var selectableCountries = _contriesConfigMap.GetAllowedDestinationCountries(CheckoutDto.Country.ToString())
                .OrderBy(c => c, StringComparer.InvariantCultureIgnoreCase)
                .Select(c => new { Value = Enum.Parse<Country>(c), Text = c });

            SelectableCountries = new(selectableCountries, "Value", "Text", selectableCountries?.First()?.Value);
        }
    }
}

