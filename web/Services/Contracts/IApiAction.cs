using System.Threading.Tasks;

namespace web.Services.Contracts
{
    public interface IApiAction
    {
        Task DoAsync(IApiActionService service);
    }
    public interface IApiAction<TResult> : IApiAction
    {
        new Task<TResult> DoAsync(IApiActionService service);
    }
}