using RTL.Core.Utilities.Results;
using RTLProject.Business.Abstract;
using RTLProject.DataAccess.Abstract;
using RTLProject.DTO;
using RTLProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTLProject.Business.Concrete
{
    public class TvMazeHttpClientManager : ITvMazeHttpClientService
    {
        private readonly ITvShowService _tvShowService;
        private readonly ITvShowDal _tvShowDal;
        private readonly ITvMazeHttpClient _tvMazeHttpClient;
        private readonly ICastDal _castDal;
        private readonly IUpdateQueueDal _updateQueueDal;

        public TvMazeHttpClientManager(ITvShowService tvShowService, ITvShowDal tvShowDal, ICastDal castDal, ITvMazeHttpClient tvMazeHttpClient, IUpdateQueueDal updateQueueDal)
        {
            _tvShowService = tvShowService;
            _tvShowDal = tvShowDal;
            _castDal = castDal;
            _tvMazeHttpClient = tvMazeHttpClient;
            _updateQueueDal = updateQueueDal;
        }

        public async Task<IDataResult<TvMazeDTO>> UpdateTvShows()
        {
            var model = new TvMazeDTO();
            try
            {
                var updateQueues = _updateQueueDal.GetList();
                if (updateQueues == null)
                {
                    return new ErrorDataResult<TvMazeDTO>("Data is empty");
                }
                foreach (var item in updateQueues)
                {
                    var tvMazeData = await _tvMazeHttpClient.GetShowByIdAsync(item.Id);
                    if (tvMazeData != null)
                    {
                        var tvShowControlData = _tvShowDal.Get(f => f.Id == tvMazeData.Id);
                        if (tvShowControlData != null)
                        {
                            tvShowControlData.TimeStamp = tvMazeData.Updated;
                            tvShowControlData.Language = tvMazeData.Language;
                            tvShowControlData.Name = tvMazeData.Name;
                            tvShowControlData.Status = tvMazeData.Status;
                            await _tvShowDal.UpdateAsync(tvShowControlData);

                            if (tvMazeData.Embedded != null)
                            {
                                if (tvMazeData.Embedded.Cast.Count > 0)
                                    await _tvShowService.AddCast(tvMazeData.Embedded.Cast, tvMazeData.Id);
                            }
                        }
                        else
                        {
                            await _tvShowService.AddTvShow(tvMazeData);
                            if (tvMazeData.Embedded != null)
                                await _tvShowService.AddCast(tvMazeData.Embedded.Cast, tvMazeData.Id);
                        }
                        await _updateQueueDal.DeleteUpdateQueue(item.Id);
                    }
                }


            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return new ErrorDataResult<TvMazeDTO>(err);
            }
            return new SuccessDataResult<TvMazeDTO>(model);
        }

        public async Task<IResult> ShowTimeStampUpdateAndInsert()
        {
            Dictionary<string, long> dataDic;
            try
            {
                dataDic = await _tvMazeHttpClient.GetShowTimeStampAsync();
                if (dataDic == null)
                {
                    return new ErrorResult("data could not be received");
                }
                foreach (var item in dataDic)
                {
                    var tvShow = _tvShowDal.Get(f => f.Id == Convert.ToInt64(item.Key));
                    if (tvShow == null || tvShow.TimeStamp != item.Value)
                    {
                        var updateQueue = new UpdateQueue()
                        {
                            Id = Convert.ToInt64(item.Key),
                            TimeStamp = item.Value
                        };
                        await _updateQueueDal.AddAsync(updateQueue);
                    }
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                //log
                return new ErrorResult(err);
            }
            return new SuccessResult(true, "data has been saved successfully");
        }
    }
}
