using Tmf.InstaVerita.Core.RequestModels;
using Tmf.InstaVerita.Core.ResponseModels;

namespace Tmf.InstaVerita.Infrastructure.Interfaces;

public interface IInstaVeritaRepository
{
    Task<List<InstaVeritaResponse>> GetRCDetails(InstaVeritaRequest instaVeritaRequest);
}
