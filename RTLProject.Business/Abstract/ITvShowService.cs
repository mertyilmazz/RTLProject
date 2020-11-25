using RTLProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RTLProject.DTO;
using RTL.Core.Utilities.Results;

namespace RTLProject.Business.Abstract
{
    public interface ITvShowService
    {  

        IDataResult<List<TvShowMainDTO>> GetTvShow(int page, int pageSize);

        IDataResult<List<TvShow>> GetTvShowFromDb();

        Task AddCast(List<TvMazeDTO.Cast> castModel, long tvShowId);
        Task AddTvShow(TvMazeDTO tvShowModel);
    }
}
