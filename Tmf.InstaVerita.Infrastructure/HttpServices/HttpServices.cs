using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text.Json;
using Tmf.InstaVerita.Core.Options;

namespace Tmf.InstaVerita.Infrastructure.HttpServices;

public class HttpServices : IHttpServices
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly InstaVeritaOptions _options;
    public HttpServices(IHttpClientFactory httpClientFactory, IOptions<InstaVeritaOptions> options)
    {
        _httpClientFactory = httpClientFactory;
        _options = options.Value;
    }

    public async Task<TOut> GetAsync<TOut>(string uri)
    {
        var httpClient = _httpClientFactory.CreateClient();

        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        httpClient.DefaultRequestHeaders.Add(_options.ApiTokenType, _options.ApiTokenKey);
        httpClient.DefaultRequestHeaders.Add(_options.SecretKeyType, _options.ApiSecretKey);

        HttpResponseMessage response = await httpClient.GetAsync(uri);
        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadAsStringAsync();

        var jsonSerializerOption = new JsonSerializerOptions() { WriteIndented = true };

        return JsonSerializer.Deserialize<TOut>(result,jsonSerializerOption);

    }
}
