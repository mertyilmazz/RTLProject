using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RTLProject.Business.Abstract;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RTLProject.Business.Concrete.Jobs
{
    public class TimeStampHostedService : IHostedService
    {
        private Timer _timer;
        private readonly TvMazeOptions _tvMazeOptions;       
        private readonly ITvMazeHttpClientService _tvMazeHttpClientService;

        public TimeStampHostedService(ITvMazeHttpClientService tvMazeHttpClientService,IOptions<TvMazeOptions> options)
        {
            _tvMazeHttpClientService = tvMazeHttpClientService;
            _tvMazeOptions = options.Value;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
           
            _timer = new Timer(ShowTimeStamp, null, 0, _tvMazeOptions.TimeForJob);
            return Task.CompletedTask;
        }

        private void ShowTimeStamp(object state)
        {
            _tvMazeHttpClientService.ShowTimeStampUpdateAndInsert();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
