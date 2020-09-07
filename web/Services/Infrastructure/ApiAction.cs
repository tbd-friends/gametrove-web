using System.Threading.Tasks;
using web.Services.Contracts;

namespace web.Services.Infrastructure
{
    public abstract class ApiAction : IApiAction
    {
        public abstract Task DoAsync(IApiActionService service);
    }

    public abstract class ApiAction<TResult> : IApiAction<TResult>
    {
        public abstract Task<TResult> DoAsync(IApiActionService service);

        Task IApiAction.DoAsync(IApiActionService service)
        {
            return DoAsync(service);
        }
    }
}