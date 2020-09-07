using System.Net.Http;

namespace web.Services.Contracts
{
    public interface IApiActionService
    {
        HttpClient Client { get; }
    }
}