namespace Mediafy.Checkout.Business.Configurations;

public class ExternalApiConfiguration
{
    public ApiEndpoint OrderEndpoint { get; set; }
}


public class ApiEndpoint
{
    public string EndpointUrl { get; set; }

    public string HttpMethod { get; set; }
}