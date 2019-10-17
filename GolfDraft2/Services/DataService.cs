using GolfDraft2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GolfDraft2.Services
{
    public class DataService
    {
        private readonly HttpClient _httpClient;

        public DataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://api.sportsdata.io/golf/v2/json/");
            _httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "2aff2b5ad2c64b51b3aa9196b48a67a3");
        }


        public async Task<IEnumerable<Player>> FetchPlayers()
        {
            var response = await _httpClient.GetAsync("players");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            IEnumerable<Player> players = JsonConvert.DeserializeObject<IEnumerable<Player>>(data);
            return players.Take(50);
        }
    }
}
