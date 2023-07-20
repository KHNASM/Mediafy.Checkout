using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mediafy.Checkout.Business.Configurations;

public class CountriesConfiguration
{
    private Dictionary<string, string[]> _innerMap = new (StringComparer.InvariantCultureIgnoreCase);

    public Dictionary<string, string[]> OfferingOrderingCountryMap 
    {
        get => _innerMap;
        set => _innerMap = (value ?? new Dictionary<string, string[]>()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value, StringComparer.InvariantCultureIgnoreCase);
    }

    public string[] GetAllowedDestinationCountries(string sourceCountry)
        => _innerMap.ContainsKey(sourceCountry ?? string.Empty) ? _innerMap[sourceCountry] : Array.Empty<string>();
}


