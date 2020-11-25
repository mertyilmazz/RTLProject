using RTLProject.Business.Abstract;
using RTLProject.DataAccess.Abstract;
using RTLProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RTLProject.DTO;
using RTL.Core.Utilities.Results;
using System.Linq;

namespace RTLProject.Business.Concrete
{
    public class TvShowManager : ITvShowService
    {
        private readonly ITvShowDal _tvShowDal;
        private readonly ITvMazeHttpClient _tvMazeHttpClient;
        private readonly ICastDal _castDal;
        public TvShowManager(ITvShowDal tvShowDal, ICastDal castDal, ITvMazeHttpClient tvMazeHttpClient)
        {
            _tvShowDal = tvShowDal;
            _castDal = castDal;
            _tvMazeHttpClient = tvMazeHttpClient;
        }


        public IDataResult<List<TvShow>> GetTvShowFromDb()
        {
            try
            {
                var data = _tvShowDal.GetList().ToList();
                return new SuccessDataResult<List<TvShow>>(data);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return new ErrorDataResult<List<TvShow>>(err);
            }

        }

        public async Task AddCast(List<TvMazeDTO.Cast> castModel, long tvShowId)
        {
            foreach (var item in castModel)
            {
                var cast = new Cast()
                {
                    Birthday =Convert.ToDateTime(item.Person.Birthday),
                    Id = item.Person.Id,
                    Name = item.Person.Name,
                    TvShowId = tvShowId
                };
                await _castDal.AddAsync(cast);
            }
        }

        public async Task AddTvShow(TvMazeDTO tvShowModel)
        {
            var tvshow = new TvShow()
            {
                Id = tvShowModel.Id,
                Name = tvShowModel.Name,
                Language = tvShowModel.Language,
                Status = tvShowModel.Status,
                TimeStamp = tvShowModel.Updated
            };
            await _tvShowDal.AddAsync(tvshow);
        }

        public IDataResult<List<TvShowMainDTO>> GetTvShow(int page, int pageSize)
        {
            try
            {
                var tvShows = _tvShowDal.GetTvShowWithCast(page, pageSize).ToList();
                if (tvShows != null)
                    return new SuccessDataResult<List<TvShowMainDTO>>(tvShows.ToList());
                else
                    return new ErrorDataResult<List<TvShowMainDTO>>("Data not found");
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return new ErrorDataResult<List<TvShowMainDTO>>(err);
            }

        }


    }
}
