using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using web.Services.Contracts;
using web.Services.Infrastructure;

namespace web.Services
{
    public class GametroveApiService : ApiActionService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private bool _isInitialized;

        public GametroveApiService(HttpClient client, AuthenticationStateProvider authenticationStateProvider)
            : base(client)
        {
            _authenticationStateProvider = authenticationStateProvider;
            _isInitialized = false;
        }

        public override async Task<TResult> ExecuteWithResultAsync<TAction, TResult>(TAction action)
        {
            if (!_isInitialized)
            {
                var authenticationState = await _authenticationStateProvider.GetAuthenticationStateAsync();

                string token = authenticationState.User.Claims.FirstOrDefault(a => a.Type == "id_token")?.Value;

                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                _isInitialized = true;
            }

            return await base.ExecuteWithResultAsync<TAction, TResult>(action);
        }
    }
}