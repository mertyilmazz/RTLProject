using Newtonsoft.Json;
using RTLProject.DataAccess.Abstract;
using RTLProject.Entities.Concrete;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using RTL.DataAccess.Concrete.EntityFramework.Context;
using RTL.Core.DataAccess;

namespace RTL.DataAccess.Concrete
{
    public class CastDal : EfEntityRepositoryBase<Cast, RTLDbContext>, ICastDal
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CastDal(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Cast>> GetAllTvShowsAsync(int page)
        {
            var tvShowList = new List<Cast>();
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                using (var response = await httpClient.GetAsync("http://api.tvmaze.com/shows?page=1"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    tvShowList = JsonConvert.DeserializeObject<List<Cast>>(apiResponse);
                }
            }
            return tvShowList;
        }
    }
}
