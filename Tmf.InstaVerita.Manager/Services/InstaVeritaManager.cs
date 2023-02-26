using Tmf.InstaVerita.Core.RequestModels;
using Tmf.InstaVerita.Core.ResponseModels;
using Tmf.InstaVerita.Infrastructure.Interfaces;
using Tmf.InstaVerita.Manager.Interfaces;

namespace Tmf.InstaVerita.Manager.Services;

public class InstaVeritaManager : IInstaVeritaManager
{
    private readonly IInstaVeritaRepository _instaVeritaRepository;
    public InstaVeritaManager(IInstaVeritaRepository instaVeritaRepository)
    {
        _instaVeritaRepository = instaVeritaRepository;
    }

    public async Task<InstaVeritaResponse> GetRCDetails(InstaVeritaRequest instaVeritaRequest)
    {
        var result = await _instaVeritaRepository.GetRCDetails(instaVeritaRequest);

        InstaVeritaResponse instaVeritaResponse = result[0];

        return instaVeritaResponse;
    }
}
