using Mediafy.Checkout.Business.Configurations;
using Mediafy.Checkout.Business.Dtos;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace Mediafy.Checkout.Business.Implementation;

public class ApiGateway : IApiGateway
{
    private readonly ILogger<ApiGateway> _logger;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ExternalApiConfiguration _externalApiConfiguration;

    public ApiGateway(
        ILogger<ApiGateway> logger,
        IHttpClientFactory httpClientFactory,
        IOptionsMonitor<ExternalApiConfiguration> externaApiOptionsMonitor)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
        _externalApiConfiguration = externaApiOptionsMonitor.CurrentValue;
    }

    public async Task<OrderResult> PlaceOrderAsync(OrderRequestDto orderRequest)
    {
        string url = _externalApiConfiguration.OrderEndpoint.EndpointUrl;
        HttpMethod method = new(_externalApiConfiguration.OrderEndpoint.HttpMethod);

        using var httpClient = _httpClientFactory.CreateClient();

        JsonContent content = JsonContent.Create(orderRequest);
        HttpRequestMessage message = new(method, url) { Content = content };

        HttpResponseMessage httpResponseMessage = null;

        try
        {
            httpResponseMessage = await httpClient.SendAsync(message);
            httpResponseMessage.EnsureSuccessStatusCode();

            return new() { Success = true };
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error sending POST request to '{url}'", ex);

            string errorMessage = await TryGetMessage(httpResponseMessage);

            return new() { Success = false, Message = $"Sorry but your order could not be placed at this time. The server said: '{errorMessage}'" };
        }
    }

    private async Task<string> TryGetMessage(HttpResponseMessage response)
    {
        try
        {
            var responseObject = await response?.Content.ReadFromJsonAsync<ApiResponse>();
            return responseObject?.Message;
        }
        catch (Exception)
        {
            return null;
        }
    }
}

public class ApiResponse
{
    public string Message { get; set; }
}