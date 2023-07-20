using System;
using System.Linq;

namespace Mediafy.Checkout.Business.Configurations;

public class ValidationRules
{
    public PhoneNumberValidationRule[] PhoneNumberValidations { get; set; } = Array.Empty<PhoneNumberValidationRule>();

    public ZipCodeValidationRule[] ZipCodeValidations { get; set;} = Array.Empty<ZipCodeValidationRule>();

    public PhoneNumberValidationRule GetPhoneNumberValidationRule(string country)
    {
        if (string.IsNullOrWhiteSpace(country))
        {
            throw new ArgumentException($"'{nameof(country)}' cannot be null or whitespace.", nameof(country));
        }

        return PhoneNumberValidations
            .Single(r => string.Equals(r.Country, country, StringComparison.InvariantCultureIgnoreCase));
    }

    public ZipCodeValidationRule GetZipCodeValidationRule(string country)
    {
        if (string.IsNullOrWhiteSpace(country))
        {
            throw new ArgumentException($"'{nameof(country)}' cannot be null or whitespace.", nameof(country));
        }

        return ZipCodeValidations
            .Single(r => string.Equals(r.Country, country, StringComparison.InvariantCultureIgnoreCase));
    }
}

public class PhoneNumberValidationRule
{
    public string Country { get; set; }

    public bool IsRequired { get; set; }
}

public class ZipCodeValidationRule
{
    public string Country { get; set; }

    public string Pattern { get; set; }

    public string ErrorMessage { get; set; }
}
