using System.Net.Http;
using System.Threading.Tasks;
using web.Services.Contracts;

namespace web.Services.Infrastructure
{
    public abstract class ApiActionService : IApiActionService
    {
        public HttpClient Client { get; }

        protected ApiActionService(HttpClient client)
        {
            Client = client;
        }

        public virtual async Task ExecuteAsync<TAction>(TAction action)
            where TAction : IApiAction
        {
            await action.DoAsync(this);
        }

        public virtual async Task<TResult> ExecuteWithResultAsync<TAction, TResult>(TAction action)
            where TAction : IApiAction<TResult>
        {
            return await action.DoAsync(this);
        }
    }
}