using Tmf.InstaVerita.Core.RequestModels;
using Tmf.InstaVerita.Core.ResponseModels;

namespace Tmf.InstaVerita.Manager.Interfaces;

public interface IInstaVeritaManager
{
    Task<InstaVeritaResponse> GetRCDetails(InstaVeritaRequest instaVeritaRequest);
}
