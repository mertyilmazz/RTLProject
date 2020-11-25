using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RTLProject.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RTLProject.Business.Concrete.Jobs
{
    public class GetTvMazeHostedService : IHostedService
    {
        private Timer _timer;
        private readonly ILogger<GetTvMazeHostedService> _logger;
        private readonly TvMazeOptions _tvMazeOptions;
        private readonly ITvMazeHttpClientService _tvMazeHttpClientService;

        public GetTvMazeHostedService(ITvMazeHttpClientService tvMazeHttpClientService, IOptions<TvMazeOptions> options, ILogger<GetTvMazeHostedService> logger)
        {
            _tvMazeHttpClientService = tvMazeHttpClientService;
            _tvMazeOptions = options.Value;
            _logger = logger;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(GetShowById, null, 0, _tvMazeOptions.TimeForJob);
            return Task.CompletedTask;
        }

        private void GetShowById(object state)
        {
            _logger.LogInformation("Retrieving GetTvMazeInformation From TvMaze");
            _tvMazeHttpClientService.UpdateTvShows();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
