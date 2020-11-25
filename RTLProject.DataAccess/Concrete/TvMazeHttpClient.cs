using Newtonsoft.Json;
using RTLProject.DataAccess.Abstract;
using RTLProject.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RTLProject.DataAccess.Concrete
{
    public class TvMazeHttpClient  :ITvMazeHttpClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TvMazeHttpClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<TvMazeDTO> GetShowByIdAsync(long showId)
        {
            var tvShowList = new TvMazeDTO();
            using (var httpClient = _httpClientFactory.CreateClient("TvMaze"))
            {
                using (var response = await httpClient.GetAsync($"/shows/{showId}?embed=cast"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    tvShowList = JsonConvert.DeserializeObject<TvMazeDTO>(apiResponse);
                }
            }
            return tvShowList;
        }

        public async Task<Dictionary<string, long>> GetShowTimeStampAsync()
        {
            var timeStampList = new Dictionary<string, long>();
            using (var httpClient = _httpClientFactory.CreateClient("TvMaze"))
            {
                using (var response = await httpClient.GetAsync("/updates/shows"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    timeStampList = JsonConvert.DeserializeObject<Dictionary<string, long>>(apiResponse);
                }
            }
            return timeStampList;
        }
    }
}
