using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using web.Services.Contracts;
using web.Services.Infrastructure;
using web.ViewModels;

namespace web.Services.Actions
{
    public class SearchGamesAction : ApiAction<IEnumerable<GameViewModel>>
    {
        private readonly string _searchTerm;

        public SearchGamesAction(string searchTerm)
        {
            _searchTerm = searchTerm;
        }

        public override async Task<IEnumerable<GameViewModel>> DoAsync(IApiActionService service)
        {
            var result = await service.Client.PostAsync("/search/games",
                new StringContent(JsonConvert.SerializeObject(new
                {
                    Text = _searchTerm
                }), Encoding.UTF8, "application/json"));

            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<IEnumerable<GameViewModel>>(content);
            }

            return null;
        }
    }
}