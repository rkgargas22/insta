namespace Tmf.InstaVerita.Infrastructure.HttpServices;

public interface IHttpServices
{
    Task<TOut> GetAsync<TOut>(string uri);
}
