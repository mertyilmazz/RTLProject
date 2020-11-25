using Microsoft.Extensions.DependencyInjection;
using RTL.DataAccess.Concrete;
using RTLProject.Business.Abstract;
using RTLProject.Business.Concrete;
using RTLProject.Business.Concrete.Jobs;
using RTLProject.DataAccess.Abstract;
using RTLProject.DataAccess.Concrete;

namespace RTLProject.Business.DependencyResolver
{
    public static class ConfigureServices
    {

        public static void ConfigureBusiness(this IServiceCollection services)
        {
            services.AddTransient<ITvShowService,TvShowManager>();
            services.AddTransient<ITvShowDal, TvShowDal>();           
            services.AddTransient<ICastDal, CastDal>();
            services.AddTransient<ITvMazeHttpClient, TvMazeHttpClient>();
            services.AddTransient<ITvMazeHttpClientService, TvMazeHttpClientManager>();
            services.AddTransient<IUpdateQueueDal, UpdateQueueDal>();

            services.AddHostedService<TimeStampHostedService>();
            services.AddHostedService<GetTvMazeHostedService>();



        }
    }
}
