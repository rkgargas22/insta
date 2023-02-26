using Microsoft.Extensions.Options;
using Tmf.InstaVerita.Core.Options;
using Tmf.InstaVerita.Core.RequestModels;
using Tmf.InstaVerita.Core.ResponseModels;
using Tmf.InstaVerita.Infrastructure.HttpServices;
using Tmf.InstaVerita.Infrastructure.Interfaces;

namespace Tmf.InstaVerita.Infrastructure.Services;

public class InstaVeritaRepository : IInstaVeritaRepository
{
    private readonly IHttpServices _httpServices;
    private readonly InstaVeritaOptions _options;
    public InstaVeritaRepository(IHttpServices httpServices, IOptions<InstaVeritaOptions> options)
    {
        _httpServices = httpServices;
        _options = options.Value;
    }

    public async Task<List<InstaVeritaResponse>> GetRCDetails(InstaVeritaRequest instaVeritaRequest)
    {
        string url = _options.Url + instaVeritaRequest.RcNumber;
        var result = await _httpServices.GetAsync<List<InstaVeritaResponse>>(url);
        
        if(result.Count == 0)
        {
            return new List<InstaVeritaResponse>();
        }

        return result;
    }
}
